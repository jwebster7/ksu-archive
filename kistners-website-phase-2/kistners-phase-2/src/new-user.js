const serve401 = require('../src/serve401');

function serveNewUser(req, res, err) {
  /*
   * admins {
   *  user: admin
   *  pass: password01,
   * 
   *  user: jwebster7
   *  pass: password01
   * }
   * */
  
  if(!req.user){
    res.setHeader("Location", "/signin");
    res.statusCode = 302;
    res.end();    
    return;
  }
  else if(req.user.role != 'A'){
    serve401(req, res);
    return;
  }
  
  console.log(req.user)
  if (!err) err = "";
  var nav = res.templates.render("_nav.html", {url: req.url});
  var footer = res.templates.render("_footer.html", {});
  var content = res.templates.render("create-user.html", {errorMessage: err});
  var html = res.templates.render("_page.html", {
    page: "Sign-Up",
    navigation: nav,
    content: content,
    footer: footer
  });
  res.setHeader("Content-Type", "text/html");
  res.end(html);
}

module.exports = serveNewUser;

/*
module.exports = function(req, res) {
    
  res.setHeader("Content-Type", "text/html");
  res.end(res.templates.render("signup.html", {errorMessage: ""}));
}
*/