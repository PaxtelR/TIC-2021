const express = require("express");
const jwt = require("jsonwebtoken");
const router = express.Router();
require("dotenv-safe").config();
const ReportGridShot = require("../controllers/Reports/ReportGridShot");

router.post("/reportGridShot", verifyJWT, ReportGridShot.reportGridShot);

function verifyJWT(req, res, next) {
  const token = req.headers["x-access-token"];
  if (!token)
    return res.status(401).json({ auth: false, msg: "No token provided." });

  jwt.verify(token, process.env.SECRET, function (err, decoded) {
    if (err)
      return res
        .status(500)
        .json({ auth: false, msg: "Failed to authenticate token." });
    req.decoded = decoded;
    req.userId = decoded.id;
    next();
  });
}
module.exports = router;
