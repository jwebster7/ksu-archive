const serve500 = require('./serve500');
const db = require('../data/database');

function modArrangements(req, res, err) {
  if (!req.user){
    res.setHeader("Location", "/signin");
    res.statusCode = 302;
    res.end();
    return;
  }
  console.log(err);
  if (!err) err = "";
  db.arrangements.getAll((err, arrangements) => {
    if(err) {
      console.log("Couldn't find any arrangments!");
      serve500(req, res);
      return;
    }
    
    var findArrangement = db.arrangements.find;
    if(!err) err = "";
    var nav = res.templates.render("_nav.html", {url: req.url});
    var footer = res.templates.render("_footer.html", {});
    var content = res.templates.render("update-arrangement.html", {errorMessage: err, arrangements: arrangements});
    var html = res.templates.render("_page.html", {
      page: "Update Arrangement",
      navigation: nav,
      content: content,
      footer: footer
    });
    res.setHeader("Content-Type", "text/html");
    res.end(html);    
  })
}

module.exports = modArrangements;