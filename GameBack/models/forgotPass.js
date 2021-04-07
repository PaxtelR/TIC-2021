const mongoose = require("mongoose");
const ForgotPassSchema = new mongoose.Schema({
  email: {
    type: String,
    required: true,
  },
  code: {
    type: String,
    required: true,
  },
  valid: {
    type: Boolean,
    required: true,
    default: true,
  },
  date: {
    type: Date,
    default: Date.now,
  },
});
const ForgetPassword = mongoose.model("ForgetPassword", ForgotPassSchema);

module.exports = ForgetPassword;
