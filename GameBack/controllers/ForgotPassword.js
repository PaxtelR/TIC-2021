const ForgetPassword = require("../models/forgotPass");
const User = require("../models/user");
const bcrypt = require("bcrypt");
const Email = require("../config/email");
require("dotenv-safe").config();

async function findUser(req) {
  //Procura por email
  let user = await User.findOne({ email: req.body.email });
  try {
    if (user) {
      return { success: true, user: user };
    } else {
      return { success: false, msg: "Usuário não encontrado." };
    }
  } catch (error) {
    console.log(error);
  }
}

async function saveCode(user, code, res) {
  async function saveCodeDB() {
    const newForgotPassword = await new ForgetPassword({
      email: user.email,
      code: code,
      valid: true,
    });

    newForgotPassword
      .save()
      .then((value) => {
        return { ok: true, msg: "Sucesso" };
      })
      .catch((value) => console.log(value));
  }

  try {
    let userReged = await ForgetPassword.findOne({ email: user.email });
    if (userReged) {
      await userReged.deleteOne();
      await saveCodeDB();
    } else {
      await saveCodeDB();
    }
  } catch (error) {
    console.log(error);
    return res.status(500).json({ msg: "Erro ao salvar código!" });
  }
}

function generateCode() {
  const chars =
    "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890@!.";
  const codeSize = 30;
  let code = "";

  while (code.length < codeSize) {
    // length of the code.
    let index = Math.floor(Math.random() * chars.length);
    code += chars[index];
  }
  return code;
}

module.exports = {
  async forgotPassword(req, res) {
    if (req.body.email) {
      const userSearch = await findUser(req);
      if (userSearch ? userSearch.success : false) {
        const code = generateCode();
        await saveCode(userSearch.user, code, res); // Tratar resposta se falhar
        const emailResponse = await Email.ForgotPass(userSearch.user, code); // Tratar resposta se falhar
        if (emailResponse.messageId) {
          return res.json({
            success: true,
            msg: "E-mail com link para alterar a senha foi enviado",
          });
        } else {
          res.status(500).json({ msg: "Erro ao enviar e-mail" });
        }
      }
      res.status(500).json({ msg: userSearch ? userSearch.msg : "Erro" });
    } else {
      res.status(500).json({ msg: "Nescessário informar um e-mail" });
    }
  },

  async forgotPasswordSave(req, res) {
    const { code, password, password2 } = req.body;
    let errors = [];
    let user = await ForgetPassword.findOne({ code: code });
    if (user) {
      if (user.valid == false) {
        errors.push({
          msg: "Url invalido, por favor, solicitar um novo esqueci a senha.",
        });
        return res.status(500).json({ errors: errors });
      }

      if (!password || !password2) {
        errors.push({ msg: "Todos os campos precisam ser preencidos." });
      }
      if (password !== password2) {
        errors.push({ msg: "As senhas não conferem." });
      }
      //check if password is more than 6 characters
      if (password.length < 6) {
        errors.push({ msg: "Senha tem que ter no minimo 8 caracteres." });
      }
      if (errors.length > 0) {
        return res.status(500).json({ errors: errors });
      } else {
        bcrypt.genSalt(10, (err, salt) =>
          bcrypt.hash(password, salt, (err, hash) => {
            if (err) throw err;
            //save pass to hash
            let newPass = hash;
            //save user
            User.findOneAndUpdate(
              { email: user.email },
              { password: newPass }
            ).then(
              ForgetPassword.findOneAndUpdate(
                { code: code },
                { valid: false }
              ).then(console.log(""))
            );
          })
        );
      }
    } else {
      return res.status(500).json({
        msg:
          "Erro ao encontrar usuário. Por favor solicitar alteração de senha novamente.",
      });
    }
    return res.render("forgotPasswordSave", { code: req.query.code });
  },
};
