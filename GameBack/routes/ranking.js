const express = require("express");
const jwt = require("jsonwebtoken");
const router = express.Router();
const Login = require("../controllers/Login");
const Register = require("../controllers/Register");
const ForgotPassword = require("../controllers/Users/ForgotPassword");
require("dotenv-safe").config();

router.get("/loginToken", verifyJWT, Login.loginToken);

router.get("/logout", (req, res) => {
  res.json({ auth: false, token: null });
});

//Exemplo request com auth
//router.get('/clientes', verifyJWT, (req, res, next) => {
//  console.log("Retornou todos clientes!");
//  res.json([{id:1,nome:'luiz'}]);
//})

function verifyJWT(req, res, next) {
  const token = req.headers["x-access-token"];
  if (!token) return res.status(401).json({ msg: "No token provided." });

  jwt.verify(token, process.env.SECRET, function (err, decoded) {
    if (err)
      return res.status(500).json({ msg: "Failed to authenticate token." });

    // se tudo estiver ok, salva no request para uso posterior
    req.userId = decoded.id;
    next();
  });
}
module.exports = router;
