const express = require("express");
const mongoose = require("mongoose");
const router = express.Router();
const app = express();
const expressEjsLayout = require("express-ejs-layouts");
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
  .connect(
    "mongodb+srv://paxtel:Rafa2307@cluster0.gwizf.mongodb.net/TicGame?retryWrites=true&w=majority",
    {
      useNewUrlParser: true,
      useUnifiedTopology: true,
    }
  )
  .then(() => console.log("connected"))
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
app.use((req, res, next) => {
  res.locals.success_msg = req.flash("success_msg");
  res.locals.error_msg = req.flash("error_msg");
  res.locals.error = req.flash("error");
  next();
});
//Routes
app.use("/", require("./routes/index"));
app.use("/users", require("./routes/users"));
app.use("/checks", require("./routes/checks"));
http.createServer(app);
app.listen(8080, function () {
  console.log("Server aberto");
});
