<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="FinalYearWeb.ResetPassword" Async="true" %>


<!doctype html>
<html lang="en">

<!-- Mirrored from preview.colorlib.com/theme/meal2/book-a-table.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 26 Jul 2023 15:13:44 GMT -->
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<meta name="description" content="" />
<meta name="keywords" content="" />
<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;700&amp;family=Playfair+Display:wght@400;700&amp;display=swap" rel="stylesheet">
<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/animate.min.css">
<link rel="stylesheet" href="css/bootstrap-datepicker.css">
<link rel="stylesheet" href="css/owl.carousel.min.css">
<link rel="stylesheet" href="css/owl.theme.default.min.css">
<link rel="stylesheet" href="css/jquery.fancybox.min.css">
<link rel="stylesheet" href="fonts/icomoon/style.css">
<link rel="stylesheet" href="fonts/flaticon/font/flaticon.css">
<link rel="stylesheet" href="css/aos.css">
<link rel="stylesheet" href="css/style.css">
<title>Reset</title>
<link rel="icon" href="img/logo.png" type="image/png"/>
 <link rel="stylesheet" href="./Layout/css/bootstrap1.min.css" />
<link rel="stylesheet" href="./Layout/vendors/themefy_icon/themify-icons.css" />

    <link rel="stylesheet" href="./Layout/vendors/swiper_slider/css/swiper.min.css" />

<link rel="stylesheet" href="./Layout/vendors/select2/css/select2.min.css" />

<link rel="stylesheet" href="./Layout/vendors/niceselect/css/nice-select.css" />

<link rel="stylesheet" href="./Layout/vendors/owl_carousel/css/owl.carousel.css" />

<link rel="stylesheet" href="./Layout/vendors/gijgo/gijgo.min.css" />

<link rel="stylesheet" href="./Layout/vendors/font_awesome/css/all.min.css" />
<link rel="stylesheet" href="./Layout/vendors/tagsinput/tagsinput.css" />

<link rel="stylesheet" href="./Layout/vendors/datatable/css/jquery.dataTables.min.css" />
<link rel="stylesheet" href="./Layout/vendors/datatable/css/responsive.dataTables.min.css" />
<link rel="stylesheet" href="./Layout/vendors/datatable/css/buttons.dataTables.min.css" />

<link rel="stylesheet" href="./Layout/vendors/text_editor/summernote-bs4.css" />

<link rel="stylesheet" href="./Layout/vendors/morris/morris.css"/>

<link rel="stylesheet" href="./Layout/vendors/material_icon/material-icons.css" />

<link rel="stylesheet" href="./Layout/css/metisMenu.css"/>

<link rel="stylesheet" href="./Layout/css/style1.css" />
<link rel="stylesheet" href="./Layout/css/colors/default.css" id="colorSkinCSS"/>
<script nonce="085b37a6-1708-48d5-ab3b-d6ee52a1f694">(function (w, d) { !function (j, k, l, m) { j[l] = j[l] || {}; j[l].executed = []; j.zaraz = { deferred: [], listeners: [] }; j.zaraz.q = []; j.zaraz._f = function (n) { return function () { var o = Array.prototype.slice.call(arguments); j.zaraz.q.push({ m: n, a: o }) } }; for (const p of ["track", "set", "debug"]) j.zaraz[p] = j.zaraz._f(p); j.zaraz.init = () => { var q = k.getElementsByTagName(m)[0], r = k.createElement(m), s = k.getElementsByTagName("title")[0]; s && (j[l].t = k.getElementsByTagName("title")[0].text); j[l].x = Math.random(); j[l].w = j.screen.width; j[l].h = j.screen.height; j[l].j = j.innerHeight; j[l].e = j.innerWidth; j[l].l = j.location.href; j[l].r = k.referrer; j[l].k = j.screen.colorDepth; j[l].n = k.characterSet; j[l].o = (new Date).getTimezoneOffset(); if (j.dataLayer) for (const w of Object.entries(Object.entries(dataLayer).reduce(((x, y) => ({ ...x[1], ...y[1] })), {}))) zaraz.set(w[0], w[1], { scope: "page" }); j[l].q = []; for (; j.zaraz.q.length;) { const z = j.zaraz.q.shift(); j[l].q.push(z) } r.defer = !0; for (const A of [localStorage, sessionStorage]) Object.keys(A || {}).filter((C => C.startsWith("_zaraz_"))).forEach((B => { try { j[l]["z_" + B.slice(7)] = JSON.parse(A.getItem(B)) } catch { j[l]["z_" + B.slice(7)] = A.getItem(B) } })); r.referrerPolicy = "origin"; r.src = "../../cdn-cgi/zaraz/sd0d9.js?z=" + btoa(encodeURIComponent(JSON.stringify(j[l]))); q.parentNode.insertBefore(r, q) };["complete", "interactive"].includes(k.readyState) ? zaraz.init() : j.addEventListener("DOMContentLoaded", zaraz.init) }(w, d, "zarazData", "script"); })(window, document);</script></head>
<body>



<div class="main_content_iner ">
<div class="container-fluid p-0">
<div class="row justify-content-center">
<div class="col-lg-12">
<div class="white_box mb_30">

<div class="row justify-content-center">
<div class="col-lg-6">

<div class="modal-content cs_modal">
<div class="modal-header">
<h5 class="modal-title">Reset</h5>
</div>
<div class="modal-body">
    <form id="form1" runat="server">
      <div class="mb-3">
           <asp:TextBox  id="email" required="true" runat="server" type="number"   placeholder="Phone"  Width="60%"  ForeColor="Gray" BorderColor="Gray"   ></asp:TextBox>
</div>
           <div class="mb-3">
           <asp:TextBox  required="true"  Width="60%" id="password" type="password"   placeholder="Password" ForeColor="Gray" BorderColor="Gray"   runat="server"></asp:TextBox>
</div>
          <div class="mb-3">
           <asp:TextBox  required="true"  Width="60%" id="TextBox1" type="password"   placeholder="Confirm password" ForeColor="Gray" BorderColor="Gray"   runat="server"></asp:TextBox>
</div>
       
        <asp:Button runat="server" BackColor="#2DAAB8" text-align="left"   Width="60%" ForeColor="Black"  Text="Search" ID="search" />
        <asp:Button runat="server" BackColor="#2DAAB8" text-align="left"   Width="60%" ForeColor="Black"  Text="Submit" ID="submit" />
               <div class="mb-3">
                   <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Sign in</asp:HyperLink>
                   <asp:Label ID="LblLogin" runat="server" Text=""></asp:Label>
               </div>
       
    
    </form>
    </div>
     </div>
     </div>
     </div>
     </div>
     </div>
     </div>
     </div>
     </div>
<div class="site-footer">
<div class="container">
<div class="row">
<div class="col-lg-4">
<div class="widget">
<h3>About Meal<span class="text-primary">.</span> </h3>
<p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.</p>
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
<h3>Projects</h3>
<ul class="list-unstyled float-left links">
<li><a href="#">La Lega Stadium</a></li>
 <li><a href="#">France Building</a></li>
<li><a href="#">22 New Homes</a></li>
<li><a href="#">Manage Center</a></li>
<li><a href="#">Sports Hall</a></li>
</ul>
</div> 
</div> 
<div class="col-lg-2">
<div class="widget">
<h3>Services</h3>
<ul class="list-unstyled float-left links">
<li><a href="#">Architect</a></li>
<li><a href="#">Interior Design</a></li>
<li><a href="#">Landscape Design</a></li>
<li><a href="#">Consultancy</a></li>
</ul>
</div> 
</div> 
<div class="col-lg-3">
<div class="widget">
<h3>Contact</h3>
<address>43 Raymouth Rd. Baltemoer, London 3910</address>
<ul class="list-unstyled links mb-4">
<li><a href="tel://11234567890">+1(123)-456-7890</a></li>
<li><a href="tel://11234567890">+1(123)-456-7890</a></li>
<li><a href="https://preview.colorlib.com/cdn-cgi/l/email-protection#9ef7f0f8f1def3e7faf1f3fff7f0b0fdf1f3"><span class="__cf_email__" data-cfemail="e881868e87a885918c8785898186c68b8785">[email&#160;protected]</span></a></li>
</ul>
</div> 
</div> 
</div> 
<div class="row mt-5">
<div class="col-12 text-center">
<p>

Copyright &copy;<script data-cfasync="false" src="../../cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js"></script><script>document.write(new Date().getFullYear());</script> All rights reserved | This website is made with <i class="icon-heart text-danger" aria-hidden="true"></i> by <a href="https://colorlib.com/" target="_blank">Food lovers</a>
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
<script src="js/bootstrap-datepicker.min.js"></script>
<script src="js/aos.js"></script>
<script src="js/custom.js"></script>

<script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13"></script>
<script>
    window.dataLayer = window.dataLayer || [];
    function gtag() { dataLayer.push(arguments); }
    gtag('js', new Date());

    gtag('config', 'UA-23581568-13');
    </script>
<script defer src="https://static.cloudflareinsights.com/beacon.min.js/v8b253dfea2ab4077af8c6f58422dfbfd1689876627854" integrity="sha512-bjgnUKX4azu3dLTVtie9u6TKqgx29RBwfj3QXYt5EKfWM/9hPSAI/4qcV5NACjwAo8UtTeWefx6Zq5PHcMm7Tg==" data-cf-beacon='{"rayId":"7ecd95e5ed2e4eba","version":"2023.4.0","b":1,"token":"cd0b4b3a733644fc843ef0b185f98241","si":100}' crossorigin="anonymous"></script>
</body>

<!-- Mirrored from preview.colorlib.com/theme/meal2/book-a-table.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 26 Jul 2023 15:13:45 GMT -->
</html>
