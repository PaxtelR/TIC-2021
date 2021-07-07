const User = require("../models/user");
const bcrypt = require("bcrypt");
const jwt = require("jsonwebtoken");
require("dotenv-safe").config();

// Se possivel o Ip do ultimo login

async function findUser(req) {
  //Procura por email
  let user = await User.findOne({ email: req.body.email });
  try {
    if (user) {
      //Compara senha
      let isMatch = await bcrypt.compare(req.body.password, user.password);
      if (isMatch && !user.banned) {
        user.lastLogin = Date.now();
        user.save();
        return {
          success: true,
          msg: "Sucesso",
          id: user._id,
          username: user.username,
        };
      } else if (user.banned) {
        var msg;
        if (user.banEndDate) {
          msg = `Usuário banido até ${new Date(
            user.banEndDate
          ).toLocaleDateString()}`;
        } else {
          msg = "Usuário banido permanentemente!!";
        }
        return { success: false, msg: msg, type: 403 };
      } else {
        return { success: false, msg: "Usuário ou Senha incorreta", type: 403 };
      }
    } else {
      return { success: false, msg: "Usuário ou Senha incorreta", type: 403 };
    }
  } catch (error) {
    console.log(error);
  }
}

module.exports = {
  async login(req, res) {
    const userSearch = await findUser(req);
    if (userSearch ? userSearch.success : false) {
      //auth ok
      const id = userSearch.id;
      const token = jwt.sign({ id }, process.env.SECRET, {
        expiresIn: "1d", // expires in 1dia
      });
      return res.json({
        auth: true,
        token: token,
        username: userSearch.username,
      });
    }
    if (userSearch.type) {
      res
        .status(userSearch.type)
        .json({ msg: userSearch ? userSearch.msg : "Erro" });
    } else {
      res.status(500).json({ msg: userSearch ? userSearch.msg : "Erro" });
    }
  },

  async loginToken(req, res) {
    const userSearch = await User.findOne({ _id: req.userId });
    if (userSearch) {
      //auth ok
      const id = userSearch.id;
      const token = jwt.sign({ id }, process.env.SECRET, {
        expiresIn: "1d", // expires in 5min
      });
      return res.json({
        auth: true,
        token: token,
        username: userSearch.username,
      });
    }
    res.status(500).json({ msg: userSearch ? userSearch.msg : "Erro" });
  },
};
