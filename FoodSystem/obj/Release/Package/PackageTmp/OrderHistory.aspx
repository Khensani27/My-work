﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="FinalYearWeb.OrderHistory" Async="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order history</title>
    <link href="images/favicon.ico" rel="icon"/>

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin=""/>
    <link href="https://fonts.googleapis.com/css2?family=Heebo:wght@400;500;600&family=Nunito:wght@600;700;800&family=Pacifico&display=swap" rel="stylesheet"/>

    <!-- Icon Font Stylesheet -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css" rel="stylesheet"/>

    <!-- Libraries Stylesheet -->
    <link href="lib/animate/animate.min.css" rel="stylesheet"/>
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet"/>
    <link href="lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />

    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/css/bootstrap.min.css" rel="stylesheet"/>

    <!-- Template Stylesheet -->
    <link href="css/css/style.css" rel="stylesheet"/>
    <link href="assets/css/main.css" rel="stylesheet"/>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <style>
        /* Add your custom styles here */
        .container {
            text-align: center;
            padding-top: 20px;
        }

        .order-container {
            border: 1px solid #ccc;
            margin: 20px;
            padding: 10px;
            background-color: #f9f9f9;
        }

        .order-details {
            text-align: left;
        }

        .order-title {
            font-size: 24px;
            margin: 0;
        }

        .order-status {
            font-size: 18px;
            color: #007bff;
        }

        .order-cost {
            font-size: 20px;
            font-weight: bold;
            color: #28a745;
        }

        /* Style for the view history button */
        #viewHistoryButton {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            margin-top: 20px;
            font-size: 16px;
            cursor: pointer;
        }

        #viewHistoryButton:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
     <!-- ======= Header ======= -->
  <header id="header" class="header fixed-top d-flex align-items-center">
    <div class="container d-flex align-items-center justify-content-between">



      <a href="#" class="logo d-flex align-items-center me-auto me-lg-0">
        <!-- Uncomment the line below if you also wish to use an image logo -->
        <!--<img src="assets/img/logo.png" alt=""> -->
        <h1>Pino's On<span> campus</span></h1>
      </a>

          <nav id="navbar" class="navbar">
   <ul>
     <li><a href="CustomerHome.aspx" class="nav-item nav-link <%= Request.Url.AbsolutePath.EndsWith("CustomerHome.aspx") ? "active" : "" %>">Menu</a></li>
     <li><a href="About.aspx" class="nav-item nav-link <%= Request.Url.AbsolutePath.EndsWith("About.aspx") ? "active" : "" %>">About</a></li>
     <li><a href="Contact.aspx" class="nav-item nav-link <%= Request.Url.AbsolutePath.EndsWith("Contact.aspx") ? "active" : "" %>">Contact</a></li>
   </ul>
</nav><!-- .navbar -->
            <div class="d-flex align-items-center">
  <%--<a class="btn-book-a-table me-2" href="MyAccount.aspx"><i class="bi bi-person"></i></a>--%>
  <a class="btn-book-a-table" href="Logout.aspx">LogOut</a>
</div>
      <i class="mobile-nav-toggle mobile-nav-show bi bi-list"></i>
      <i class="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>

    </div>
  </header>

    <br />
     <br />
     <br />
  <br />
    <form runat="server">
        <div class="container">
            <h2>Order History</h2>
            <div id="orderhistory" runat="server"></div>
             <!-- Add a line break -->
            <asp:Button ID="viewHistoryButton" runat="server" Text="Backhome" OnClick="ViewHistoryButton_Click" />
            <br />
            <br />
        </div>
    </form>
              <!-- ======= Footer ======= -->
  <footer id="footer" class="footer">

    <div class="container">
      <div class="row gy-3">
        <div class="col-lg-3 col-md-6 d-flex">
          <i class="bi bi-geo-alt icon"></i>
          <div>
            <h4>Address</h4>
            <p>
              Auckland Park Kingsway <br/>
              Johannesburg, APK - SA<br/>
            </p>
          </div>

        </div>

        <div class="col-lg-3 col-md-6 footer-links d-flex">
          <i class="bi bi-telephone icon"></i>
          <div>
            <h4>Contacts</h4>
            <p>
              <strong>Phone:</strong> +27 76 990 2895<br/>
              <strong>Email:</strong> pinos@businessmail.com<br/>
            </p>
          </div>
        </div>

        <div class="col-lg-3 col-md-6 footer-links d-flex">
          <i class="bi bi-clock icon"></i>
          <div>
            <h4>Opening Hours</h4>
            <p>
              <strong>Mon-Fri: 08h00PM</strong> - 17h00PM<br/>
              <strong>Sat: 08h00PM</strong> - 13h00PM<br/>
              Sunday: Closed
            </p>
          </div>
        </div>

        <div class="col-lg-3 col-md-6 footer-links">
          <h4>Follow Us</h4>
          <div class="social-links d-flex">
            <a href="#" class="twitter"><i class="bi bi-twitter"></i></a>
            <a href="#" class="facebook"><i class="bi bi-facebook"></i></a>
            <a href="#" class="instagram"><i class="bi bi-instagram"></i></a>
            <a href="#" class="linkedin"><i class="bi bi-linkedin"></i></a>
          </div>
        </div>

      </div>
    </div>

    <div class="container">
      <div class="copyright">
        &copy; Copyright <strong><span>Yummy</span></strong>. All Rights Reserved
      </div>
      <div class="credits">
        <!-- All the links in the footer should remain intact. -->
        <!-- You can delete the links only if you purchased the pro version. -->
        <!-- Licensing information: https://bootstrapmade.com/license/ -->
        <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/yummy-bootstrap-restaurant-website-template/ -->
        Designed by <a href="https://bootstrapmade.com/">BootstrapMade</a>
      </div>
    </div>

  </footer>
  <!-- End Footer -->
    

</body>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="lib/wow/wow.min.js"></script>
    <script src="lib/easing/easing.min.js"></script>
    <script src="lib/waypoints/waypoints.min.js"></script>
    <script src="lib/counterup/counterup.min.js"></script>
    <script src="lib/owlcarousel/owl.carousel.min.js"></script>
    <script src="lib/tempusdominus/js/moment.min.js"></script>
    <script src="lib/tempusdominus/js/moment-timezone.min.js"></script>
    <script src="lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js"></script>

    <!-- Template Javascript -->
    <script src="js/main.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/json2/20110223/json2.js"></script>

</html>