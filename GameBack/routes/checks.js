const express = require("express");
const jwt = require("jsonwebtoken");
const router = express.Router();
require("dotenv-safe").config();

router.post("/checkToken", verifyJWT, (req, res, next) => {
  res.json(req.decoded);
});

//Exemplo request com auth
//router.get('/clientes', verifyJWT, (req, res, next) => {
//  console.log("Retornou todos clientes!");
//  res.json([{id:1,nome:'luiz'}]);
//})

function verifyJWT(req, res, next) {
  const token = req.headers["x-access-token"];
  if (!token)
    return res.status(401).json({ auth: false, msg: "No token provided." });

  jwt.verify(token, process.env.SECRET, function (err, decoded) {
    if (err)
      return res
        .status(500)
        .json({ auth: false, msg: "Failed to authenticate token." });

    // se tudo estiver ok, salva no request para uso posterior
    // Token dura 1 dia, se faltar menos de 1 hora, ele recomenda fazer login de novo.
    // O que pode ser feito?
    // - Criar um novo token que demore 1 dia para expirar, se ele tiver um token valido salvo no computador;
    // - Forçar ele fazer login toda vez;
    // - Recomendar ele fazer login de novo quando o token faltar menos de 1 hora para expirar;
    if (decoded.exp - Math.floor(new Date().getTime() / 1000.0) <= 3600) {
      decoded = { ...decoded, msg: "need new token" };
    }
    req.decoded = decoded;
    req.userId = decoded.id;
    next();
  });
}
module.exports = router;
