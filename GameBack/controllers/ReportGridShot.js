const GridShotReport = require("../models/gridShotReport");
const JWT = require("../libs/jwtVerify");
require("dotenv-safe").config();

// Add data e hora ultimo login
// Se possivel o Ip do ultimo login

module.exports = {
  async reportGridShot(req, res) {
    JWT.verifyJWT(req, res, async (req, res) => {
      const GridRegister = await new GridShotReport({
        userId: req.userId,
        precision: req.body.precision,
        score: req.body.score,
        shots: req.body.shots,
        hits: req.body.hits,
        ttk: req.body.ttk,
        kps: req.body.kps,
        date: Date.now(),
        type: req.body.type,
      });
      GridRegister.save()
        .then((value) => {
          return res.json({ ok: true, msg: "Sucesso" });
        })
        .catch((value) => console.log(value));
    });
  },
};
