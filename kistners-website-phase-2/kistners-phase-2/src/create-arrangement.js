const parseBody = require('../lib/parse-body');
const db = require('../data/database');
const newArrangement = require('../src/new-arrangement');

/** @module createUser 
 * POST enpiont for creating a user 
 */
module.exports = createArrangement;

/** @function createArrangment
 * Starts the process of creating a user from the POSTed form data
 * @param {http.incomingMessage} req - the request object 
 * @param {http.serverResponse} res - the response object 
 */
function createArrangement(req, res) {
  parseBody(req, res, (req, res) => {
    console.log("Req.body: " + req.body.toString());
    if (typeof req.body.name !== "string")
      return newArrangement(req, res, "Invalid arrangement name!");
    if (typeof req.body.description !== "string")
      return newArrangement(req, res, "Invalid arrangment description!");

    db.arrangements.create(req.body, (err) => {
      if(err) return serve500(req, res);
      newArrangement(req, res, "Arrangement Successfully Created!");
    })
  });
}