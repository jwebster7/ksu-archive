const bcrypt = require('bcrypt');
const templates = require('../lib/templates');
const parseBody = require('../lib/parse-body');
const db = require('../data/user-database');
//const serve500 = require('../src/serve500');
//const serveHome = require('../src/serve-home');
//const sessions = require('../lib/sessions');
const newPassword = require('../src/new-password');

const ENCRYPTION_PASSES = 10;

/** @module createUser 
 * POST enpiont for creating a user 
 */
module.exports = updateUser;

/** @function updateUser 
 * Starts the process of creating a user from the POSTed form data
 * @param {http.incomingMessage} req - the request object 
 * @param {http.serverResponse} res - the response object 
 */
function updateUser(req, res) {
    console.log(req.user.username.toString());
    parseBody(req, res, (req, res) => {
        validateUser(req, res);
    });
}

/** @function validateUser 
 * Validates the provided user and invokes createPasswordHash()
 * or failure().
 * @param {http.incomingMessage} req - the request object 
 * @param {http.serverResponse} res - the response object 
 * @param {object} user - the user to validate
 */
function validateUser(req, res) { 
  //console.log("User.username: " + req.user.username.toString());
  //console.log("User.username: " + user.username.toString());
  //console.log("Req.user: " + req.user.toString());

  db.get("SELECT cryptedPassword FROM users WHERE username = ?", req.user.username, (err, row) => {
      if(err) failure(req, res, err);
      bcrypt.compare(req.body.currentPassword, row.cryptedPassword, (err, valid) => {
        /* Check for errors */
        if(err) return failure(req, res, err);
        if(!valid) return failure(req, res, "Incorrect password!");
        
        /* store the users new password and password confirmation in a variable;. */
        var newPassword = req.body.newPassword;
        var newPasswordConfirmation = req.body.newPasswordConfirmation;

        /* validate new password meets minimum requirements. */
        if(typeof newPassword !== "string" || newPassword.length < 10)
          return failure(req, res, "Password must be at least ten characters in length");
        if(newPassword !== newPasswordConfirmation)
          return failure(req, res, "New Password and New Password Confirmation must match");
        req.user.password = newPassword;
        createPasswordHash(req, res, req.user);
    });    
  });
}

/** @function createPasswordHash
 * Creates a hashed version of the user password and invokes
 * saveUser() or failure().
 * @param {http.incomingMessage} req - the request object 
 * @param {http.serverResponse} res - the response object 
 * @param {object} user - the user to create a hash for
 */
function createPasswordHash(req, res, user) {
  bcrypt.hash(user.password, ENCRYPTION_PASSES, (err, hash) => {
    if(err) return failure(req, res);
    user.cryptedPassword = hash;
    updatePassword(req, res, user);
  });
}

/** @function saveUser 
 * Saves the provided user to the database and invokes createPasswordHash()
 * or failure().
 * @param {http.incomingMessage} req - the request object 
 * @param {http.serverResponse} res - the response object 
 * @param {object} user - the user to validate
 */
function updatePassword(req, res, user) {   
  db.run("UPDATE users SET cryptedPassword = ? WHERE username = ?",
    user.cryptedPassword,
    user.username,
    (err) => {
      if(err) failure(req, res, err);
      else success(req, res, user);
    }
  ); 
}

/** @function success 
 * Creates a session for the newly created user and 
 * redirects them to the home page.
 * @param {http.incomingMessage} req - the request object 
 * @param {http.serverResponse} res - the response object
 * @param {Object} user - the user this session belongs to 
 */
function success(req, res, user) {
  newPassword(req, res, "Your password has been successfully updated!");
  res.end();
}

/** @function failure
 * Enpoint that renders the sign up form on a failure with an optional message.
 * @param {http.incomingMessage} req - the request object 
 * @param {http.serverResponse} res - the response object 
 * @param {string} errorMessage (optional) - an error message to display 
 */
function failure(req, res, errorMessage) {
  if(!errorMessage) errorMessage = "There was a problem updating your password! Please try again.";
  newPassword(req, res, errorMessage);
  res.end();
}