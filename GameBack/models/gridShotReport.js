const mongoose = require("mongoose");
const GridShotReportSchema = new mongoose.Schema({
  userId: {
    type: String,
    required: true,
  },
  precision: {
    type: Number,
    required: true,
  },
  score: {
    type: Number,
    required: true,
  },
  shots: {
    type: Number,
    required: true,
  },
  hits: {
    type: Number,
    required: true,
  },
  ttk: {
    type: Number,
    required: true,
  },
  kps: {
    type: Number,
    required: true,
  },
  date: {
    type: Date,
    default: Date.now,
  },
  type: {
    type: String,
  },
});
const GridShotReport = mongoose.model("GridShotReport", GridShotReportSchema);

module.exports = GridShotReport;
