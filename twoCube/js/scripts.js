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
    if (window.location.href.indexOf("dosurvey") == -1)
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
        document.getElementById('nav1').innerHTML = menu;
    else
        document.getElementById('nav1').innerHTML = loginedmenu;
}
function loadFooter() {
    document.getElementById('footer').innerHTML = "Copyright © 2013 twoCube<div class='cleaner'></div>";
}
function logout() {
    localStorage.clear();
    $(location).attr('href', './');
}
function register() {
    $.colorbox({ href: "../register.html", open: true, iframe: true, width: "80%", height: "80%" });
}
function login() {
    $.colorbox({ href: "../Login.htm", open: true, iframe: true, width: "80%", height: "80%" });
}
$(document).bind('cbox_closed', function () {
    //$.colorbox.remove();
    //alert('closing');
    data = localStorage.getItem("twocubeSSO") || 0;
    if (data != 0)
        if (window.location.href.indexOf("createsurvey") == -1) $(location).attr('href', "./");
        else save_form_data();
});