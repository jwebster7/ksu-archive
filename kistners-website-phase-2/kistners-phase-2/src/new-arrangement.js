function newArrangement(req, res, err) {
  if(!req.user){
    res.setHeader("Location", "/signin");
    res.statusCode = 302;
    res.end();    
    return;
  }
  
  if (!err) err = "";
  var nav = res.templates.render("_nav.html", {url: req.url});
  var footer = res.templates.render("_footer.html", {});
  var content = res.templates.render("create-arrangement.html", {errorMessage: err});
  var html = res.templates.render("_page.html", {
    page: "Create Arrangement",
    navigation: nav,
    content: content,
    footer: footer
  });
  res.setHeader("Content-Type", "text/html");
  res.end(html);  
}

module.exports = newArrangement;