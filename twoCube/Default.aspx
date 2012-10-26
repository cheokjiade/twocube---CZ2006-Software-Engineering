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

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
	<script src="js/slides.min.jquery.js"></script>

    <script>       
     $(function () {
            $('#slides').slides({
                preload: true,
                preloadImage: 'img/loading.gif',
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
        <div id="menu" class="ddsmoothmenu">
        </div> <!-- end of menu -->
        <div class="cleaner"></div>
    </div> <!-- end of header -->
    <div id="middle">
     <!-- Start Top -->
        <div id="container">
		<div id="example">
			<img src="images/new-ribbon.png" width="112" height="112" alt="New Ribbon" id="ribbon"/>
           <div id="slides">
				<div class="slides_container">
					<div class="slide">
						<img src="images/slide-1.jpg" width="570" height="270" alt="Slide 1"/>
						<div class="caption" style="bottom:0">
							<p>test1</p>
						</div>
					</div>
					<div class="slide">
						<img src="images/slide-2.jpg" width="570" height="270" alt="Slide 2"/>
						<div class="caption">
							<p>test2</p>
						</div>
					</div>
					<div class="slide">
						<img src="images/slide-3.jpg" width="570" height="270" alt="Slide 3"/>
						<div class="caption">
							<p>test3</p>
						</div>
					</div>
					<div class="slide">
						<img src="images/slide-4.jpg" width="570" height="270" alt="Slide 4"/>
						<div class="caption">
							<p>test4</p>
						</div>
					</div>
					<div class="slide">
						<img src="images/slide-5.jpg" width="570" height="270" alt="Slide 5" />
						<div class="caption">
							<p>test4</p>
						</div>
					</div>
					<div class="slide">
						<img src="images/slide-6.jpg" width="570" height="270" alt="Slide 6" />
						<div class="caption">
							<p>test5</p>
						</div>
					</div>
					<div class="slide">
						<a href="http://www.flickr.com/photos/aftab/3152515428/" title="Save my love for loneliness | Flickr - Photo Sharing!" target="_blank"><img src="images/slide-7.jpg" width="570" height="270" alt="Slide 7"></a>
						<div class="caption">
							<p>test6</p>
						</div>
					</div>
				</div>
				<a href="#" class="prev"><img src="images/arrow-prev.png" width="24" height="43" alt="Arrow Prev"/></a>
				<a href="#" class="next"><img src="images/arrow-next.png" width="24" height="43" alt="Arrow Next"/></a>
			</div>
			<img src="images/example-frame.png" width="739" height="341" alt="Example Frame" id="frame" />
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