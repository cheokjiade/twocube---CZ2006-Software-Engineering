<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>twoCube - Home</title>
    <link rel="stylesheet" href="http://www.jacklmoore.com/colorbox/example1/colorbox.css" /> 
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://www.jacklmoore.com/colorbox/colorbox/jquery.colorbox.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <script type="text/javascript" src="https://raw.github.com/SamWM/jQuery-Plugins/master/numeric/jquery.numeric.js"></script>
    <script type="text/javascript" src="https://raw.github.com/maxatwork/form2js/master/src/form2js.js"></script>
    <link rel="stylesheet" type="text/css" href="css/ddsmoothmenu.css" />
    <script type="text/javascript" src="Scripts/json2.js"></script>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/ddsmoothmenu.css" />
    <script type="text/javascript">
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
    </script>  
</head>
<body onload="onload()">

<div id="wrapper">
	<div id="header">
        <div id="site_title"><h1><a href="#"></a></h1></div>
        <div id="menu" class="ddsmoothmenu">
        </div> <!-- end of menu -->
        <div class="cleaner"></div>
    </div> <!-- end of header -->
    
     <div id="middle">
     <!-- Start Top -->
		<div id="mid_title">Welcome to twoCube</div>
        <p><a class='iframe' href="http://threadless.com">Outside Webpage (Iframe)</a></p>
            <p>twoCube is a free survey creation service offered in a shallow attempt to get better marks on our CZ2006 project.</p>
            <div id="learn_more"><a href="#">Learn More</a></div>
    <!-- End Top -->
    <div class="cleaner"></div>
	</div> <!-- end of middle -->
    
    <!-- end of main -->
</div> <!-- wrapper -->

<div id="footer_wrapper">
	<div id="footer"></div>
</div>

</body>
</html>