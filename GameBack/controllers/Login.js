const User = require("../models/user");
const bcrypt = require("bcrypt");
const jwt = require("jsonwebtoken");
require("dotenv-safe").config();

// Add data e hora ultimo login
// Se possivel o Ip do ultimo login

async function findUser(req) {
  //Procura por email
  let user = await User.findOne({ email: req.body.email });
  try {
    if (user) {
      //Compara senha
      let isMatch = await bcrypt.compare(req.body.password, user.password);
      if (isMatch) {
        return {
          success: true,
          msg: "Sucesso",
          id: user._id,
          username: user.username,
        };
      } else {
        return { success: false, msg: "Senha incorreta" };
      }
    } else {
      return { success: false, msg: "E-mail não registrado" };
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
