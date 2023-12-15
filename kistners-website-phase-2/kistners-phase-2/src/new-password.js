function newPassword(req, res, err) {
    if (!err) err = "";
    var nav = res.templates.render("_nav.html", {url: req.url});
    var footer = res.templates.render("_footer.html", {});
    var content = res.templates.render("update-password.html", {errorMessage: err});
    var html = res.templates.render("_page.html", {
      page: "Update Password",
      navigation: nav,
      content: content,
      footer: footer
    });
  res.setHeader("Content-Type", "text/html");
  res.end(html);
}

module.exports = newPassword;