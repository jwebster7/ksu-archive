const serve401 = require('../src/serve401');

function newRole(req, res, err) {
  if(!req.user){
    res.setHeader("Location", "/signin");
    res.statusCode = 302;
    res.end();    
    return;
  }
  else if(req.user.role != 'A'){
    return serve401(req, res);
  }
  
  if (!err) err = "";
  var nav = res.templates.render("_nav.html", {url: req.url});
  var footer = res.templates.render("_footer.html", {});
  var content = res.templates.render("update-role.html", {errorMessage: err});
  var html = res.templates.render("_page.html", {
    page: "Change User Role",
    navigation: nav,
    content: content,
    footer: footer
  });
  res.setHeader("Content-Type", "text/html");
  res.end(html);  
}

module.exports = newRole;