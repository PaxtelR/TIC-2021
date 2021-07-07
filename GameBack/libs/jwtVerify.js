const jwt = require("jsonwebtoken");

function verifyJWT(req, res, next) {
  const token = req.headers["x-access-token"];
  if (!token)
    return res.status(401).json({ auth: false, msg: "No token provided." });

  jwt.verify(token, process.env.SECRET, function (err, decoded) {
    if (err)
      return res
        .status(500)
        .json({ auth: false, msg: "Failed to authenticate token." });

    //Se faltar menos de 1 hora, ele avisa que tem que fazer login dnv.
    if (decoded.exp - Math.floor(new Date().getTime() / 1000.0) <= 3600) {
      decoded = { ...decoded, msg: "need new token" };
    }
    req.decoded = decoded;
    req.userId = decoded.id;
    next(req, res);
  });
}

module.exports = { verifyJWT };
