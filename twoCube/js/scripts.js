function onload(){
	loadMenu();
	loadFooter();
}
function loadMenu(){
	var menu = "<ul>\
                <li><a href='./'>Home</a></li>\
                <li><a href='index.html'>Create Survey</a></li>\
                <li><a href='#'>About twoCube</a></li>\
				<li><a href='./Login.htm'>Login</a></li>\
            </ul>\
            <br style='clear: left' />";
			
	document.getElementById('menu').innerHTML = menu;
}
function loadFooter(){
	document.getElementById('footer').innerHTML = "Copyright © 2013 twoCube<div class='cleaner'></div>";
}