const modArrangement = require('../src/modify-arrangement');
const db = require('../data/database');
const parseBody = require('../lib/parse-body');

function updateArrangement(req, res) {
  parseBody(req, res, (req, res) => {
    validateUpdate(req, res);
  });
}


function validateUpdate(req, res) {
  if(typeof req.body.name !== "string"|| req.body.name == "") return failure(req, res, "Invalid name!");
  if(typeof req.body.description !== "string" || req.body.description == "") return failure(req, res, "Invalid description!");
  
  db.arrangements.update(req.body, (err) => {
    if(err) return failure(req, res, "There was an error when updating this arrangement.\n Please try again!");
    return success(req, res);
  });
}

function success(req, res) {
  modArrangement(req, res, "Successfully updated: " + req.body.name);
}

function failure(req, res, error) {
  if(!error) error = "There was a problem updating the user role. Please try again.";
  modArrangement(req, res, error);
}

module.exports = updateArrangement;