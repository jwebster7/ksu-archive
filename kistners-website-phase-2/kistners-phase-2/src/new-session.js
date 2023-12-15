// const templates = require('../lib/templates');

/** @function newSession
 * Endpoint for rendering a sign in form.
 * @param {http.incomingMessage} req - the request object 
 * @param {http.serverResponse} res - the response object 
 */
function serveNewSession(req, res, err) {
    if (!err) err = "";
    var nav = res.templates.render("_nav.html", {url: req.url});
    var footer = res.templates.render("_footer.html", {});
    var content = res.templates.render("signin.html", {errorMessage: err});
    var html = res.templates.render("_page.html", {
      page: "Sign-In",
      navigation: nav,
      content: content,
      footer: footer
    });
  res.setHeader("Content-Type", "text/html");
  res.end(html);
}

module.exports = serveNewSession;