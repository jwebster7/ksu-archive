const admin = require('../src/serve-admin');
const createUser = require('../src/create-user');
const updatePassword = require('./update-password');
const parseBody = require('../lib/parse-body');
const db = require('../data/user-database');


function createNewUser(req, res) {
    createUser(req, res);
    updatePassword(req, res);
    parseBody
}