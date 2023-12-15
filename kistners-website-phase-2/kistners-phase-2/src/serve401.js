/** @function serve401
  * Endpoint serving 401 errors 
  * @param {http.IncomingMessage} req - the request object
  * @param {http.ServerResponse} res - the response object
  */
function serve401(req, res) {
  // Log the 404 error
  // console.error(`401 Error: Unable to serve ${req.url}`);
  // Set the status code & message
  res.statusCode = 401;
  res.statusMessage = "Unauthorized";
  // Render a pretty error page
  var html = res.templates.render('401.html',{});
  res.setHeader("Content-Type", "text/html");
  res.end(html);
}

module.exports = serve401;