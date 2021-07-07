const mongoose = require("mongoose");
const UserSchema = new mongoose.Schema({
  username: {
    type: String,
    required: true,
  },
  email: {
    type: String,
    required: true,
  },
  password: {
    type: String,
    required: true,
  },
  date: {
    type: Date,
    default: Date.now,
  },
  lastLogin: {
    type: Date,
  },
  banned: {
    type: Boolean,
    default: false,
  },
  banEndDate: {
    type: Date,
  },
});
const User = mongoose.model("User", UserSchema);

module.exports = User;
