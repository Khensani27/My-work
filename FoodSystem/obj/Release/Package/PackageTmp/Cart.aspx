<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FinalYearWeb.Cart" Async="true" %>

<!doctype html>
<html lang="en">

<!-- Mirrored from preview.colorlib.com/theme/meal2/gallery.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 26 Jul 2023 15:13:42 GMT -->
<head>
    <title>Shopping Cart</title>
    <!-- Favicon -->
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

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
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
          <li><a href="CustomerHome.aspx" class="nav-item nav-link active">Menu</a></li>
         <%-- <li><a href="Favorites.aspx">Favourite Items</a></li>--%>
        </ul>
      </nav><!-- .navbar -->

      <a class="btn-book-a-table" href="#book-a-table">LogOut</a>
      <i class="mobile-nav-toggle mobile-nav-show bi bi-list"></i>
      <i class="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>
      <a>
          <div class="cart">
            <div class="cart_container d-flex flex-row align-items-center justify-content-end">
                <div class="cart_icon">
                <img src="images/cart.png" alt="">
                <%--<div class="cart_count"><span>10</span></div>--%>
                </div>
                <div class="cart_content">
                <div class="cart_text"><a href="Cart.aspx">Cart</a></div>
                <%--<div class="cart_price">$85</div>--%>
            </div>
           </div>
           </div>
      </a>

    </div>
  </header>
    <!-- End Header -->
    <br />
    <br />

       <style>
            @media (min-width: 1025px) {
        .h-custom {
        height: 100vh !important;
        }
        }
        </style>
           
    <form id="mainform" runat="server">

        <section class="h-100 h-custom">
            <div class="container h-100 py-5">
                <div class="row d-flex justify-content-center align-items-center h-100">
                  <div class="col">

                    <div class="table-responsive">
                      <table class="table lms_table_active">
                        <thead>
                          <tr>
                            <th scope="col" ></th>
                            <th scope="col" >Image</th>
                            <th scope="col">Name</th>
                            <th scope="col">Quantity</th>
                            <th scope="col">Price</th>
                          </tr>
                        </thead>
                        <tbody id="cart_rows" runat="server">
                           
                        </tbody>
                      </table>
                    </div>
                    
                    <div class="card shadow-2-strong mb-5 mb-lg-0" style="border-radius: 16px;">
                      <div class="card-body p-4">
                        <div class="row" id="total" runat="server">
                         
    <asp:Button ID="RedirectButton" runat="server" Text="Proceed to Payment" OnClick="RedirectButton_Click1" />
                            
                          </div>
                        </div>
                      </div>
                    </div>

                  </div>
                </div>
        </section>
    </form>

  <!-- ======= Footer ======= -->
 <!-- <footer id="footer" class="footer">

    <div class="container">
      <div class="row gy-3">
        <div class="col-lg-3 col-md-6 d-flex">
          <i class="bi bi-geo-alt icon"></i>
          <div>
            <h4>Address</h4>
            <p>
              A108 Adam Street <br>
              New York, NY 535022 - US<br>
            </p>
          </div>

        </div>

        <div class="col-lg-3 col-md-6 footer-links d-flex">
          <i class="bi bi-telephone icon"></i>
          <div>
            <h4>Reservations</h4>
            <p>
              <strong>Phone:</strong> +1 5589 55488 55<br>
              <strong>Email:</strong> info@example.com<br>
            </p>
          </div>
        </div>

        <div class="col-lg-3 col-md-6 footer-links d-flex">
          <i class="bi bi-clock icon"></i>
          <div>
            <h4>Opening Hours</h4>
            <p>
              <strong>Mon-Sat: 11AM</strong> - 23PM<br>
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

        Designed by <a href="https://bootstrapmade.com/">BootstrapMade</a>
      </div>
    </div>

  </footer>-->
  <!-- End Footer -->
</body>


</html>
