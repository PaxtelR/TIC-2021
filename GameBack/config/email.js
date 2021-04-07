const nodemailer = require("nodemailer");
const { emailTemplate } = require("./emailTemplate");

const auth = {
  user: "rafaelteste23Em@gmail.com",
  pass: "Rafa1357",
};

async function ForgotPass(user, code) {
  let transporter = await nodemailer.createTransport({
    host: "smtp.gmail.com",
    port: 587,
    secure: false, // true for 465, false for other ports
    auth: auth,
  });

  let mail = await transporter.sendMail({
    from: auth.user, // sender address
    to: user.email, // list of receivers
    subject: "Esqueci a senha - TreinoMira", // Subject line
    //text: `Olá, ${user.username} \n Esse é o seu link para mudar sua senha: http://45.235.55.126:3000/users/forgotPassword?code=${code}`,
    html: emailTemplate(code, user),
  });

  return mail;
}

module.exports = {
  ForgotPass,
};
