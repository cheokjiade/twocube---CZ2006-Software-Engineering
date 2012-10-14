var data = localStorage.getItem("twocubeSSO") || 0;
$.urlParam = function (name) {
    var results = new RegExp('[\\?&]' + name + '=([^&#]*)').exec(window.location.href);
    return results[1] || 0;
}
$(document).bind('cbox_closed', function () {
    if (data != 0) $(location).attr('href', './');
});
function onload() {
    loadMenu();
    loadFooter();
    if ($.urlParam('s') != 0) window.location = "./dosurvey.html?s=" + $.urlParam('s');
}
function loadMenu() {



    var menu = "<ul>\
                <li><a href='./'>Home</a></li>\
                <li><a href='./createsurvey.html'>Create Survey</a></li>\
                <li><a href='#' onclick='register();'>Register</a></li>\
				<li><a href='#' onclick='login();'>Login</a></li>\
            </ul>\
            <br style='clear: left' />";

    var loginedmenu = "<ul>\
                <li><a href='./'>Home</a></li>\
                <li><a href='./createsurvey.html'>Create Survey</a></li>\
                <li><a href='./EditUserDetails.htm'>Account</a></li>\
                <li><a href='./viewsurveylist.htm'>View Created Surveys</a></li>\
				<li><a href='#' onclick='logout();'>Logout</a></li>\
            </ul>\
            <br style='clear: left' />";

    if (data == 0)
        document.getElementById('menu').innerHTML = menu;
    else
        document.getElementById('menu').innerHTML = loginedmenu;
}
function loadFooter() {
    document.getElementById('footer').innerHTML = "Copyright © 2013 twoCube<div class='cleaner'></div>";
}
function logout() {
    localStorage.clear();
    $(location).attr('href', './');
}
function register() {
    $.colorbox({ href: "../register.html" });
}
function login() {
    $.colorbox({ href: "../Login.htm" });
}