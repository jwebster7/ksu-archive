const parseBody = require('../lib/parse-body');
const db = require('../data/user-database');
const newRole = require('../src/new-role');

function updateRole(req, res) {
  parseBody(req, res, (req, res) => {
    updateUserRole(req, res);
  });
}

function updateUserRole(req, res) {
  db.get("SELECT username FROM users WHERE username = ?", req.body.username, (err, row) => {
    if(err) return failure(req, res, err);
    if(!row) return failure(req, res, "No user record found!");
    
    db.run("UPDATE users SET role = ? WHERE username = ?", req.body.role, req.body.username,
      (err) => {
        if(err) failure(req, res, err);
        else success(req, res);
      }
    );
  });
}

function success(req, res) {
  newRole(req, res, "Successfully updated: " + req.body.username);
}

function failure(req, res, errorMessage) {
  if(!errorMessage) errorMessage = "There was a problem updating the user role. Please try again.";
  newRole(req, res, errorMessage);
}

module.exports = updateRole;