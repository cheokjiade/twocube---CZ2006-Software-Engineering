var data = localStorage.getItem("twocubeSSO") || 0;
$.urlParam = function (name) {
    var results = new RegExp('[\\?&]' + name + '=([^&#]*)').exec(window.location.href);
    return results[1] || 0;
}
$(document).bind('cbox_closed', function () {
    if (data != 0) $(location).attr('href', './');
});

(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
} (document));

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
        document.getElementById('menu').innerHTML = menu;
    else
        document.getElementById('menu').innerHTML = loginedmenu;
}
function loadFooter() {
    document.getElementById('footer').innerHTML = "Copyright © 2013 twoCube<div class='cleaner'></div>";
}
function logout() {
    logoutFacebook();
    localStorage.clear();
    $(location).attr('href', './');
}
function logoutFacebook() {
    window.fbAsyncInit = function () {
        FB.init({
            appId: '201735599959082', 
            cookie: true,
            status: true, 
            xfbml: true
        });

        FB.getLoginStatus(handleSessionResponse);
//    FB.logout(function () {
//        // Reload the same page after logout
//        window.location.reload();
//    });
    }
}
function handleSessionResponse(response) {
    //if we dont have a session (which means the user has been logged out, redirect the user)
    if (!response.authResponse) {
        return;
    }

    //if we do have a non-null response.session, call FB.logout(),
    //the JS method will log the user out of Facebook and remove any authorization cookies
    FB.logout(response.authResponse);
}
function register() {
    $.colorbox({ href: "../register.html", open: true, iframe: true, width: "70%", height: "55%" });
}
function login() {
    $.colorbox({ href: "../Login.htm", open: true, iframe: true, width: "55%", height: "65%" });
}
$(document).bind('cbox_closed', function () {
    //$.colorbox.remove();
    //alert('closing');
    data = localStorage.getItem("twocubeSSO") || 0;
    if (data != 0)
        if (window.location.href.indexOf("createsurvey") == -1) $(location).attr('href', "./");
        else save_form_data();
});