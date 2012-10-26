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
    <script type="text/javascript" src="js/scripts.js"></script>
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
        <script>
            window.session = {
                options: { enable_location: true, ipinfodb_key: "ae861b1dae2bb20d727d1f6b6d3a3b19cec65d6cb2ae436a7225fb39ff8ac1e8", gapi_location: true },
                // Async API (use with location)
                start: function (session) { // also can use as a global
                    alert('Hi again from ' + session.location.countryCode + '.');
                    if (session.original_session.visits > 1) {
                        if (session.location) { alert('Hi again from ' + session.location.countryCode + '.'); }
                        else { alert('Welcome back!'); }
                    } else {
                        if (session.contains(session.current_session.referrer_info.host, 'facebook.com')) {
                            //alert('Hi there from ' + session.location.address.city + '. How about liking us on facebook?');
                        } else if (session.contains(session.current_session.referrer_info.host, 'github.com')) {
                            alert('How about watching us on github?');
                        } else if (session.contains(session.current_session.referrer_info.host, 'twitter.com')) {
                            alert('Hi there from twitter!');
                        } else if (session.current_session.search.engine) {
                            alert('Did you find what you were looking for from ' + session.current_session.search.engine + '?');
                        }
                    }
                    if (session.locale.lang !== 'en') {
                        var translate_url = 'http://translate.google.com/translate?sl=auto&tl=' + session.locale.lang + '&js=n&prev=_t&hl=en&ie=UTF-8&layout=2&eotf=1&u=' + escape(session.current_session.url);
                        add_msg('Need a <a href="' + translate_url + '">translation</a>?');
                    }
                }
            };
        </script>
        <script type="text/javascript" src="http://codejoust.github.com/session.js/session-0.4.js"></script>
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