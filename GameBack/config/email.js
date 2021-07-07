const nodemailer = require("nodemailer");
const { emailTemplate } = require("./emailTemplate");
require("dotenv-safe").config();

const auth = {
  user: process.env.E_EMAIL,
  pass: process.env.E_PASS,
};

async function ForgotPass(user, code) {
  let transporter = await nodemailer.createTransport({
    host: process.env.E_HOST,
    port: process.env.E_PORT,
    secure: false, // true for 465, false for other ports
    auth: auth,
  });

  let mail = await transporter.sendMail({
    from: auth.user, // sender address
    to: user.email, // list of receivers
    subject: "Esqueci a senha - MAI", // Subject line
    html: emailTemplate(code, user),
  });

  return mail;
}

module.exports = {
  ForgotPass,
};
