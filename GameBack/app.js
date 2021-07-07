const express = require("express");
const mongoose = require("mongoose");
const router = express.Router();
const app = express();
var http = require("http");
var https = require("https");
const flash = require("connect-flash");
const session = require("express-session");
const rateLimit = require("express-rate-limit");
require("dotenv-safe").config();

const limiter = rateLimit({
  windowMs: 5 * 60 * 1000, // 5 minutes
  max: 100, // limit each IP to 100 requests per windowMs
});

//mongoose
mongoose
  .connect(process.env.BD_URL, {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  })
  .then(() => console.log("Conectou ao BD"))
  .catch((err) => console.log(err));
mongoose.set("useFindAndModify", false);
//EJS
app.use(express.static("views/public"));
app.set("view engine", "ejs");
//app.use(expressEjsLayout);
//BodyParser
app.use(express.json());
//app.use(express.urlencoded({ extended: false }));
//express session
app.set("trust proxy", 1);
app.use(limiter);
app.use(
  session({
    secret: "secret",
    resave: true,
    saveUninitialized: true,
  })
);
//use flash
app.use(flash());
//Routes
app.use("/users", require("./routes/users"));
app.use("/report", require("./routes/report"));
http.createServer(app);
app.listen(8080, function () {
  console.log("Server aberto");
});
