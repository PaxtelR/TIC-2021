const bcrypt = require("bcrypt");
const User = require("../models/user");
const Isemail = require("isemail");

module.exports = {
  async register(req, res) {
    const { username, email, password, password2 } = req.body;
    let errors = [];

    if (!username || !email || !password || !password2) {
      errors.push({ msg: "Todos os campos precisam ser preencidos." });
    }
    if (Isemail.validate(email, { errorLevel: true }) >= 10) {
      errors.push({ msg: "E-mail invalido" });
    }
    //check if match
    if (password !== password2) {
      errors.push({ msg: "As senhas não são iguais" });
    }

    //check if password is more than 6 characters
    if (password.length < 8) {
      errors.push({ msg: "Senha tem que ter no minimo 8 caracteres" });
    }
    if (errors.length > 0) {
      return res.status(500).json({ errors: errors });
    } else {
      //validation passed
      let userEmail = await User.findOne({
        email: {
          $regex: new RegExp(email, "i"),
        },
      });

      let user = await User.findOne({
        username: {
          $regex: new RegExp(username, "i"),
        },
      });
      if (user || userEmail) {
        if (user) {
          return res.status(500).json({ msg: "Username já registrado" });
        } else if (userEmail) {
          return res.status(500).json({ msg: "E-mail já registrado" });
        } else {
          return res.status(500).json({ msg: "Usuário já registrado" });
        }
      } else {
        const newUser = await new User({
          username: username,
          email: email,
          password: password,
        });

        //hash password
        bcrypt.genSalt(10, (err, salt) =>
          bcrypt.hash(newUser.password, salt, (err, hash) => {
            if (err) throw err;
            //save pass to hash
            newUser.password = hash;
            //save user
            newUser
              .save()
              .then((value) => {
                return res.json({ ok: true, msg: "Sucesso" });
              })
              .catch((value) => console.log(value));
          })
        );
      }
    }
  },
};
