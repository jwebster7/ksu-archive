var http = require('http');
const Router = require('./lib/router');
const Templates = require('./lib/templates');
const serveFile = require('./src/serve-file');
const serveHome = require('./src/serve-home');
const serveAnniversary = require('./src/serve-anniversary');
const serveBaby = require('./src/serve-baby');
const serveBirthday = require('./src/serve-birthday');
const serveProm = require('./src/serve-prom');
const serveSororitySisterhood = require('./src/serve-sorority-sisterhood');
const serveSympathy = require('./src/serve-sympathy');
const serveWedding = require('./src/serve-wedding');
const serveArrangement = require('./src/serve-arrangement');
const serveArrangementImage = require('./src/serve-arrangement-image');
const serve404 = require('./src/serve404');
const loadSession = require('./lib/load-session');

/* serve a 401 if unauthorized access attempts are made. */
//const serve401 = require('./src/serve401');

/* Files for creating a signing up as a new user and signing in. */
const newUser = require('./src/new-user');
const createUser = require('./src/create-user');
const newSession = require('./src/new-session');
const createSession = require('./src/create-session');

/* Serve the new-password and update-password pages. */
const newPassword = require('./src/new-password');
const updatePassword = require('./src/update-password');

/* Serve the admin page. */
const serveAdminPage = require('./src/serve-admin');
const postAdminChanges = require('./src/admin-changes');

/* Serve form for updating a user role. */
const serveUpdateRole = require('./src/update-role');
const serveNewRole = require('./src/new-role');

/* Serve the create arrangment page. */
const serveNewArrangement = require('./src/new-arrangement');
const postAddArrangement = require('./src/create-arrangement');

/* Serve forms for updating an arrangement. */
const serveModArrangement = require('./src/modify-arrangement');
const postUpdateArrangement = require('./src/update-arrangement');

const PORT = 3000;

var router = new Router(serve404);
var templates = new Templates("./templates");

router.addRoute("GET", "/static/:filename", serveFile);
router.addRoute("GET", "/", serveHome);
router.addRoute("GET", "/index", serveHome);
router.addRoute("GET", "/index.html", serveHome);
router.addRoute("GET", "/anniversary", serveAnniversary);
router.addRoute("GET", "/baby", serveBaby);
router.addRoute("GET", "/birthday", serveBirthday);
router.addRoute("GET", "/prom", serveProm);
router.addRoute("GET", "/sorority-sisterhood", serveSororitySisterhood);
router.addRoute("GET", "/sympathy", serveSympathy);
router.addRoute("GET", "/weddings", serveWedding);
router.addRoute("GET", "/arrangements/:id", serveArrangement);
router.addRoute("GET", "/arrangement-images/:id", serveArrangementImage);

/* Adding the routes with their respective POST/GET requests for signing up/signing in. */
router.addRoute("GET", "/create-user", newUser);
router.addRoute("POST", "/create-user", createUser);
router.addRoute("GET", "/signin", newSession);
router.addRoute("POST", "/signin", createSession);

/* Adding the routes for updating the password. */
router.addRoute("GET", "/update-password", newPassword);
router.addRoute("POST", "/update-password", updatePassword);

/* Adding the routes for serving admin pages. */
router.addRoute("GET", "/admin", serveAdminPage);
router.addRoute("POST", "/admin", postAdminChanges);

/* Adding the routes for creating a new arrangements. */
router.addRoute("GET", "/create-arrangement", serveNewArrangement);
router.addRoute("POST", "/create-arrangement", postAddArrangement);

/* Adding the routes for updating an arrangement. */
router.addRoute("GET", "/update-arrangement", serveModArrangement);
router.addRoute("POST", "/update-arrangement", postUpdateArrangement);

/* Adding the routes to the router for updating user role. */
router.addRoute("GET", "/update-role", serveNewRole);
router.addRoute("POST", "/update-role", serveUpdateRole);

// Setup http server
var server = http.createServer((req, res) => {
    loadSession(req, res, (req, res) => {
        // Attach the template library to the response
        res.templates = templates;
        // TODO: Attach the database to the response
        router.route(req, res);       
    });
});

// Begin listening for requests
server.listen(PORT, () => {
  console.log(`Server listening on port ${PORT}`);
});
