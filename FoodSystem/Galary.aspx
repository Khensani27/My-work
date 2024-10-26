<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Galary.aspx.cs" Inherits="FinalYearWeb.Galary" %>

<!doctype html>
<html lang="en">

<!-- Mirrored from preview.colorlib.com/theme/meal2/gallery.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 26 Jul 2023 15:13:42 GMT -->
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<meta name="description" content="" />
<meta name="keywords" content="" />
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;700&amp;family=Playfair+Display:wght@400;700&amp;display=swap" rel="stylesheet">
<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/animate.min.css">
<link rel="stylesheet" href="css/owl.carousel.min.css">
<link rel="stylesheet" href="css/owl.theme.default.min.css">
<link rel="stylesheet" href="css/jquery.fancybox.min.css">
<link rel="stylesheet" href="fonts/icomoon/style.css">
<link rel="stylesheet" href="fonts/flaticon/font/flaticon.css">
<link rel="stylesheet" href="css/aos.css">
<link rel="stylesheet" href="css/style.css">
<title>Oino's Website</title>
<script nonce="e63beabf-79bd-493a-8d83-39f40ae7bb8c">(function(w,d){!function(j,k,l,m){j[l]=j[l]||{};j[l].executed=[];j.zaraz={deferred:[],listeners:[]};j.zaraz.q=[];j.zaraz._f=function(n){return function(){var o=Array.prototype.slice.call(arguments);j.zaraz.q.push({m:n,a:o})}};for(const p of["track","set","debug"])j.zaraz[p]=j.zaraz._f(p);j.zaraz.init=()=>{var q=k.getElementsByTagName(m)[0],r=k.createElement(m),s=k.getElementsByTagName("title")[0];s&&(j[l].t=k.getElementsByTagName("title")[0].text);j[l].x=Math.random();j[l].w=j.screen.width;j[l].h=j.screen.height;j[l].j=j.innerHeight;j[l].e=j.innerWidth;j[l].l=j.location.href;j[l].r=k.referrer;j[l].k=j.screen.colorDepth;j[l].n=k.characterSet;j[l].o=(new Date).getTimezoneOffset();if(j.dataLayer)for(const w of Object.entries(Object.entries(dataLayer).reduce(((x,y)=>({...x[1],...y[1]})),{})))zaraz.set(w[0],w[1],{scope:"page"});j[l].q=[];for(;j.zaraz.q.length;){const z=j.zaraz.q.shift();j[l].q.push(z)}r.defer=!0;for(const A of[localStorage,sessionStorage])Object.keys(A||{}).filter((C=>C.startsWith("_zaraz_"))).forEach((B=>{try{j[l]["z_"+B.slice(7)]=JSON.parse(A.getItem(B))}catch{j[l]["z_"+B.slice(7)]=A.getItem(B)}}));r.referrerPolicy="origin";r.src="../../cdn-cgi/zaraz/sd0d9.js?z="+btoa(encodeURIComponent(JSON.stringify(j[l])));q.parentNode.insertBefore(r,q)};["complete","interactive"].includes(k.readyState)?zaraz.init():j.addEventListener("DOMContentLoaded",zaraz.init)}(w,d,"zarazData","script");})(window,document);</script></head>
<body>
<div class="site-mobile-menu">
<div class="site-mobile-menu-header">
<div class="site-mobile-menu-close">
<span class="icofont-close js-menu-toggle"></span>
</div>
</div>
<div class="site-mobile-menu-body"></div>
</div>
<nav class="site-nav mb-5">
<div class="container-fluid">
<div class="site-navigation text-center">
<a href="CustomerHome.aspx" class="logo menu-absolute m-0">Pino's<span class="text-primary">.</span></a>
<ul class="js-clone-nav d-none d-lg-inline-block site-menu">
<li class="has-children">
<a href="CustomerHome.aspx">Menu</a>

</li>
<li><a href="events.html">Events</a></li>
<li class="active"><a href="Cart.aspx">Cart</a></li>
<li><a href="about.html">About</a></li>
<li><a href="contact.html">Contact</a></li>
</ul>
<a href="Login.aspx" class="btn-book btn btn-primary btn-sm menu-absolute">Log Out</a>
<a href="#" class="burger ml-auto float-right site-menu-toggle js-menu-toggle d-inline-block d-lg-none light" data-toggle="collapse" data-target="#main-navbar">
<span></span>
</a>
</div>
</div>
</nav>
<div class="untree_co-hero overlay" style="background-image: url('images/hero_bg.jpg');">
<div class="container">
<div class="row align-items-center justify-content-center">
<div class="col-12">
<div class="row justify-content-center">
<div class="col-lg-6 text-center">
<span class="caption" data-aos="fade-up" data-aos-delay="0">Take a look</span>
<h1 class="mb-4 heading text-white" data-aos="fade-up" data-aos-delay="100">Single Item</h1>

<p class="mb-0" data-aos="fade-up" data-aos-delay="300"><a href="#" class="btn btn-primary">Explore now</a></p>
</div>
</div>
</div>
</div> 
</div> 
<div data-aos="fade-up" data-aos-delay="0" class="scroll-down-wrap">
<span class="scroll-down"><span>scroll down</span></span>
</div>
<ul class="list-unstyled social-hero-section mb-0">
<li data-aos="fade-left" data-aos-delay="0"><a href="#"><span class="icon-whatsapp"></span></a></li>
<li data-aos="fade-left" data-aos-delay="100"><a href="#"><span class="icon-instagram"></span></a></li>
<li data-aos="fade-left" data-aos-delay="200"><a href="#"><span class="icon-facebook"></span></a></li>
<li data-aos="fade-left" data-aos-delay="300"><a href="#"><span class="icon-twitter"></span></a></li>
</ul>
</div> 
<div class="untree_co-section bg-1">
<div class="container">
    <form runat="server">
<div class="col-6 col-md-4 col-lg-4 mb-4" runat="server" id="singleItemImg">

</div>
<div class="col-6 col-md-4 col-lg-4 mb-4" runat="server" id="name">
<asp:Label ID="lblName" runat="server" Text=""></asp:Label>

</div>
<div class="col-6 mb-3" runat="server">

    <asp:TextBox   id="txtQuantity" class="form-control" required="true" runat="server" type="number"   placeholder="Quantity"  Width="60%"  ForeColor="Gray" BorderColor="Gray"   ></asp:TextBox>
</div>
                <div class="col-6 col-md-4 col-lg-4 mb-4">
<asp:Button runat="server" BackColor="#2DAAB8" OnClick="login_Click" text-align="left"   Width="60%" ForeColor="Black"  Text="Add to cart" ID="login" />
</div>
    </form>

</div>
</div> 
<div class="site-footer">
<div class="container">
<div class="row">
<div class="col-lg-4">
<div class="widget">
<h3>About Meal<span class="text-primary">.</span> </h3>
<p>Establishment where patrons can buy and consume food and beverages. We have a wide range of meals from desserts, meat, and more...</p>
</div> 
<div class="widget">
<h3>Connect</h3>
<ul class="list-unstyled social">
<li><a href="#"><span class="icon-instagram"></span></a></li>
<li><a href="#"><span class="icon-twitter"></span></a></li>
<li><a href="#"><span class="icon-facebook"></span></a></li>
<li><a href="#"><span class="icon-linkedin"></span></a></li>
<li><a href="#"><span class="icon-pinterest"></span></a></li>
<li><a href="#"><span class="icon-dribbble"></span></a></li>
</ul>
</div> 
</div> 
<div class="col-lg-2 ml-auto">
<div class="widget">
<h3>Services</h3>
<ul class="list-unstyled float-left links">
<li><a href="#">Chicken</a></li>
<li><a href="#">Salads</a></li>
<li><a href="#">Stew beef</a></li>
<li><a href="#">Pork</a></li>
<li><a href="#">Breakfast</a></li>
</ul>
</div> 
</div> 
<div class="col-lg-2">
<div class="widget">
<h3>Services</h3>
<ul class="list-unstyled float-left links">
<li><a href="#">Pizza's</a></li>
<li><a href="#">Hot Dogs</a></li>
<li><a href="#">Grilled Chicken</a></li>
<li><a href="#">Soup</a></li>
</ul>
</div> 
</div> 
<div class="col-lg-3">
<div class="widget">
<h3>Contact</h3>
<address>43 Raymouth Rd. Baltemoer, Johannesburg 3910</address>
<ul class="list-unstyled links mb-4">
<li><a href="tel://11234567890">+(27)-456-7890</a></li>
<li><a href="tel://11234567890">+(27)-456-0060</a></li>
<li><a href="https://preview.colorlib.com/cdn-cgi/l/email-protection#e980878f86a984908d8684888087c78a8684"><span class="__cf_email__" data-cfemail="2940474f466944504d4644484047074a4644">[email&#160;Pinos@gmail.com]</span></a></li>
</ul>
</div> 
</div> 
</div> 
<div class="row mt-5">
<div class="col-12 text-center">
<p>

Copyright &copy;<script data-cfasync="false" src="../../cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js"></script><script>document.write(new Date().getFullYear());</script> All rights reserved | This webside is made with <i class="icon-heart text-danger" aria-hidden="true"></i> by <a href="https://colorlib.com/" target="_blank">Pinos</a>
</p>
</div>
</div>
</div> 
</div> 
<div id="overlayer"></div>
<div class="loader">
<div class="spinner-border" role="status">
<span class="sr-only">Loading...</span>
</div>
</div>
<script src="js/jquery-3.4.1.min.js"></script>
<script src="js/popper.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/owl.carousel.min.js"></script>
<script src="js/jquery.animateNumber.min.js"></script>
<script src="js/jquery.waypoints.min.js"></script>
<script src="js/jquery.fancybox.min.js"></script>
<script src="js/aos.js"></script>
<script src="js/custom.js"></script>

<script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13"></script>
<script>
        window.dataLayer = window.dataLayer || [];
        function gtag(){dataLayer.push(arguments);}
        gtag('js', new Date());

        gtag('config', 'UA-23581568-13');
    </script>
<script defer src="https://static.cloudflareinsights.com/beacon.min.js/v8b253dfea2ab4077af8c6f58422dfbfd1689876627854" integrity="sha512-bjgnUKX4azu3dLTVtie9u6TKqgx29RBwfj3QXYt5EKfWM/9hPSAI/4qcV5NACjwAo8UtTeWefx6Zq5PHcMm7Tg==" data-cf-beacon='{"rayId":"7ecd95d9da974ecc","version":"2023.4.0","b":1,"token":"cd0b4b3a733644fc843ef0b185f98241","si":100}' crossorigin="anonymous"></script>
</body>

<!-- Mirrored from preview.colorlib.com/theme/meal2/gallery.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 26 Jul 2023 15:13:42 GMT -->
</html>
