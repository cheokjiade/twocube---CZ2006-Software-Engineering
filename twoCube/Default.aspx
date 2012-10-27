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
	<script type="text/javascript" src="js/slides.min.jquery.js"></script>
    <style type="text/css">
        #container {
	        width:860px;
	        padding:10px;
	        margin:0 auto;
	        position:relative;
	        z-index:0;
        }

        #example {
	        width:860px;
	        height:470px;
	        position:relative;
        }

        #ribbon {
	        position:absolute;
	        top:-3px;
	        left:-15px;
	        z-index:500;
        }

        #frame {
	        position:absolute;
	        z-index:0;
	        width:1100px;
	        height:500px;
	        top:-5px;
	        left:-120px;
        }

        /*
	        Slideshow
        */

        #slides {
	        position:absolute;
	        top:15px;
	        left:4px;
	        z-index:100;
        }

        /*
	        Slides container
	        Important:
	        Set the width of your slides container
	        Set to display none, prevents content flash
        */

        .slides_container {
	        width:850px;
	        overflow:hidden;
	        position:relative;
	        display:none;
        }

        /*
	        Each slide
	        Important:
	        Set the width of your slides
	        If height not specified height will be set by the slide content
	        Set to display block
        */

        .slides_container div.slide {
	        width:850px;
	        height:405px;
	        display:block;
        }


        /*
	        Next/prev buttons
        */

        #slides .next,#slides .prev {
	        position:absolute;
	        top:107px;
	        left:-39px;
	        width:24px;
	        height:43px;
	        display:block;
	        z-index:101;
        }

        #slides .next {
	        left:585px;
        }

        /*
	        Pagination
        */

        .pagination {
	        margin:26px auto 0;
	        width:100px;
        }

        .pagination li {
	        float:left;
	        margin:0 1px;
	        list-style:none;
        }

        .pagination li a {
	        display:block;
	        width:12px;
	        height:0;
	        padding-top:12px;
	        background-image:url(./images/pagination.png);
	        background-position:0 0;
	        float:left;
	        overflow:hidden;
        }

        .pagination li.current a {
	        background-position:0 -12px;
        }

        /*
	        Caption
        */

        .caption {
	        z-index:500;
	        position:absolute;
	        bottom:-35px;
	        left:0;
	        height:30px;
	        padding:5px 20px 0 20px;
	        background:#000;
	        background:rgba(0,0,0,.5);
	        width:850px;
	        font-size:1.3em;
	        line-height:1.33;
	        color:#fff;
	        border-top:1px solid #000;
	        text-shadow:none;
        }

        /*
	        Footer
        */

        #footer {
	        text-align:center;
	        width:580px;
	        margin-top:9px;
	        padding:4.5px 0 18px;
	        border-top:1px solid #dfdfdf;
        }

        #footer p {
	        margin:4.5px 0;
	        font-size:1.0em;
        }

        /*
	        Anchors
        */

        a:link,a:visited {
	        color:#599100;
	        text-decoration:none;
        }

        a:hover,a:active {
	        color:#599100;
	        text-decoration:underline;
        }
    </style>
    <script>       
     $(function () {
            $('#slides').slides({
                preload: true,
                preloadImage: 'images/loading.gif',
                play: 5000,
                pause: 2500,
                hoverPause: true,
                animationStart: function (current) {
                    $('.caption').animate({
                        bottom: -35
                    }, 100);
                    if (window.console && console.log) {
                        // example return of current slide number
                        console.log('animationStart on slide: ', current);
                    };
                },
                animationComplete: function (current) {
                    $('.caption').animate({
                        bottom: 0
                    }, 200);
                    if (window.console && console.log) {
                        // example return of current slide number
                        console.log('animationComplete on slide: ', current);
                    };
                },
                slidesLoaded: function () {
                    $('.caption').animate({
                        bottom: 0
                    }, 200);
                }
            });
        });
        </script>

</head>
<body onload="onload()">

<div id="wrapper">
	<div id="header">
        <div id="site_title"><h1><a href="#"></a></h1></div>
        
        <div class="cleaner"></div>
    </div> <!-- end of header -->
    
    <div id="middle"><div id="menu" class="ddsmoothmenu">
        </div> <!-- end of menu -->
    <div id="fb-root"></div>
<script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>
    <div class="fb-like" data-href="http://twocube1.elasticbeanstalk.com" data-send="true" data-width="450" data-show-faces="false" data-font="lucida grande"></div>
     <!-- Start Top -->
        <div id="container">
		<div id="example">
			<!--<img src="images/new-ribbon.png" width="112" height="112" alt="New Ribbon" id="ribbon"/>-->
           <div id="slides">
				<div class="slides_container">
					<div class="slide">
						<img src="http://profile.ak.fbcdn.net/hprofile-ak-ash4/371504_652201722_326593817_n.jpg" width="850" height="405" alt="Slide 1"/>
						<div class="caption" style="bottom:0">
							<p>June</p>
						</div>
					</div>
					<div class="slide">
						<img src="http://profile.ak.fbcdn.net/hprofile-ak-prn1/49499_100001074800572_1286678510_n.jpg" width="850" height="405" alt="Slide 2"/>
						<div class="caption">
							<p>Star</p>
						</div>
					</div>
					<div class="slide">
						<img src="images/slide-3.jpg" width="570" height="570" alt="Slide 3"/>
						<div class="caption">
							<p>test3</p>
						</div>
					</div>
					<div class="slide">
						<img src="images/slide-4.jpg" width="570" height="570" alt="Slide 4"/>
						<div class="caption">
							<p>test4</p>
						</div>
					</div>
					<div class="slide">
						<img src="images/slide-5.jpg" width="570" height="570" alt="Slide 5" />
						<div class="caption">
							<p>test4</p>
						</div>
					</div>
					<div class="slide">
						<img src="images/slide-6.jpg" width="570" height="570" alt="Slide 6" />
						<div class="caption">
							<p>test5</p>
						</div>
					</div>
					<div class="slide">
						<a href="http://www.flickr.com/photos/aftab/3152515428/" title="Save my love for loneliness | Flickr - Photo Sharing!" target="_blank"><img src="images/slide-7.jpg" width="570" height="570" alt="Slide 7"></a>
						<div class="caption">
							<p>test6</p>
						</div>
					</div>
				</div>
				<!--<a href="#" class="prev"><img src="images/arrow-prev.png" width="24" height="43" alt="Arrow Prev"/></a>
				<a href="#" class="next"><img src="images/arrow-next.png" width="24" height="43" alt="Arrow Next"/></a>-->
			</div>
			<img src="images/example-frame.png" width="739" height="641" alt="Example Frame" id="frame" />
		</div></div></div>
    <!-- End Top -->
    <div class="cleaner"></div>
 <!-- end of middle -->
    
    <!-- end of main -->
     <!-- wrapper --></div>
     
<div id="footer_wrapper">
	<div id="footer"></div>
</div>

</body>



</html>