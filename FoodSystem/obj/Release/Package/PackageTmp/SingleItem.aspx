<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleItem.aspx.cs" Inherits="FinalYearWeb.SingleItem"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
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
          <%--<li><a href="#">Favourite Items</a></li>--%>
        </ul>
      </nav><!-- .navbar -->

      <a class="btn-book-a-table" href="Logout.aspx">LogOut</a>
      <i class="mobile-nav-toggle mobile-nav-show bi bi-list"></i>
      <i class="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>
       <a>
          <div class="cart">
            <div class="cart_container d-flex flex-row align-items-center justify-content-end">
                <div class="cart_icon">
                <img src="images/cart.png" alt=""/>
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

    <form runat="server">
   <!-- <br />
    <br />
    <br />
    <br />
    <br />-->
    

    <section class="about_part">
        <div class="container-fluid">
            <div class="row align-items-center" id="singleItemID" runat="server">
                    <!--<div class="col-sm-4 col-lg-5 offset-lg-1">
                        <div class="about_img">
                            <img src="images/img_4_b.jpg" alt="" width="500"/>
                        </div>
                    </div>
                    <div class="col-sm-8 col-lg-4">
                        <div class="about_text">
                            <h5>name</h5>
                            <p>Description</p>
                            <span>R1111</span>"
                        </div>
                        
                    </div>-->
                    
            </div><!---->
            <div class="row align-items-center">
                <asp:TextBox ID="txtQuantity" type="number" style="float:left; margin-left:660px;" Width="200" placeholder="Quantity" runat="server"></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="row align-items-center" >
                 <div class="col-sm-8 col-lg-4">
                     <asp:Button ID="Button1" runat="server" Text="ADD TO CART" style="position:absolute; float:left; margin-left:650px;" BackColor="#08000" Width="550" ForeColor="Black" OnClick="BtnAddToCart"/>
                 </div>
                
            </div>
        </div>
    </section>
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

    <script>
        function validateQuantityAndDisplay(input) {
            var quantityLabel = document.getElementById("idQuantityLabel");
            if (input.value < 1) {
                input.value = 1;
            }
            quantityLabel.textContent = "Quantity: " + input.value;
        }
</script>
</html>
