<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="FinalYearWeb.CustomerHome" Async="true"%>

<!doctype html>
<html lang="en">

<!-- Mirrored from preview.colorlib.com/theme/meal2/index.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 26 Jul 2023 15:13:06 GMT -->
<head>
    <title>Customer Home</title>
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
     <li><a href="CustomerHome.aspx" class="nav-item nav-link <%= Request.Url.AbsolutePath.EndsWith("CustomerHome.aspx") ? "active" : "" %>">Menu</a></li>
     <li><a href="About.aspx" class="nav-item nav-link <%= Request.Url.AbsolutePath.EndsWith("About.aspx") ? "active" : "" %>">About</a></li>
     <li><a href="Contact.aspx" class="nav-item nav-link <%= Request.Url.AbsolutePath.EndsWith("Contact.aspx") ? "active" : "" %>">Contact</a></li>
   </ul>
</nav><!-- .navbar -->
       
     <%-- <nav id="navbar" class="navbar">
      <ul>
    <li><a href="CustomerHome.aspx" class="nav-item nav-link active">Home</a></li>
    <li><a href="CustomerHome.aspx">Menu</a></li>
      <li><a href="About.aspx">About</a></li>
      <li><a href="Contact.aspx">Contact</a></li>
      
  </ul>
</nav><!-- .navbar -->--%>
    <%if (Session["U_ID"] != null && !string.IsNullOrEmpty(Session["U_ID"].ToString())){ %>
       
      <a class="btn-book-a-table" href="Logout.aspx">LogOut</a>
      
      <i class="mobile-nav-toggle mobile-nav-show bi bi-list"></i>
      <i class="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>
            
                  <% } else { %>
        <div class="d-flex align-items-center">
        <a class="btn-book-a-table" href="Login.aspx">Login</a>
         <a class="btn-book-a-table" href="Register.aspx">Register</a>
         <i class="mobile-nav-toggle mobile-nav-show bi bi-list"></i>

 <i class="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>
            </div>
<% } %>
          <div class="cart">
    <%--<a href="Login.aspx">Login.aspx</a>--%>
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
      <%--</a>--%>
    </div>
  </header>
    <!-- End Header -->
    <br />
    <br />


        <!-- ======= Menu Section ======= -->
    <section id="menu" class="menu">
      <div class="container" data-aos="fade-up">

        <div class="section-header">
          <h2>Our Menu</h2>
          <p>Check Our <span>Yummy Menu</span></p>
        </div>

        <ul class="nav nav-tabs d-flex justify-content-center" data-aos="fade-up" data-aos-delay="200">

          <li class="nav-item">
            <a class="nav-link active show" data-bs-toggle="tab" data-bs-target="#menu-special">
              <h4>Specials</h4>
            </a>
          </li><!-- End tab nav item -->

          <li class="nav-item">
            <a class="nav-link" data-bs-toggle="tab" data-bs-target="#menu-breakfast">
              <h4>Breakfast</h4>
            </a><!-- End tab nav item -->

          <li class="nav-item">
            <a class="nav-link" data-bs-toggle="tab" data-bs-target="#menu-lunch">
              <h4>Lunch</h4>
            </a>
          </li><!-- End tab nav item -->

          <li class="nav-item">
            <a class="nav-link" data-bs-toggle="tab" data-bs-target="#menu-dinner">
              <h4>Dessert</h4>
            </a>
          </li><!-- End tab nav item -->

          <li class="nav-item">
            <a class="nav-link" data-bs-toggle="tab" data-bs-target="#menu-drinks">
              <h4>Drink</h4>
            </a>
          </li><!-- End tab nav item -->


        </ul>

        <div class="tab-content" data-aos="fade-up" data-aos-delay="300">

          <div class="tab-pane fade active show" id="menu-special">

            <div class="tab-header text-center">
              <p>Menu</p>
              <h3>Today's Specials</h3>
            </div>

            <div class="row gy-5" id="specials" runat="server">

             

            </div>
          </div><!-- End Starter Menu Content -->

          <div class="tab-pane fade" id="menu-breakfast">

            <div class="tab-header text-center">
              <p>Menu</p>
              <h3>Breakfast</h3>
            </div>

            <div class="row gy-5" id="breakfast" runat="server">

           

            </div>
          </div><!-- End Breakfast Menu Content -->

          <div class="tab-pane fade" id="menu-lunch">

            <div class="tab-header text-center">
              <p>Menu</p>
              <h3>Lunch</h3>
            </div>

            <div class="row gy-5" id="lunch" runat="server">

            

            </div>
          </div><!-- End Lunch Menu Content -->

          <div class="tab-pane fade" id="menu-dinner">

            <div class="tab-header text-center">
              <p>Menu</p>
              <h3>Dessert</h3>
            </div>

            <div class="row gy-5" id="dinner" runat="server">

             

            </div>
          </div><!-- End Dinner Menu Content -->

                    <div class="tab-pane fade" id="menu-drinks">

            <div class="tab-header text-center">
              <p>Menu</p>
              <h3>Drinks</h3>
            </div>

            <div class="row gy-5" id="drinks" runat="server">

            </div>
          </div><!-- End Dinner Menu Content -->

        </div>

      </div>
    </section><!-- End Menu Section -->
           <!-- ======= Footer ======= -->
   <footer id="footer" class="footer">

  <div class="container">
    <div class="row gy-3">
      <div class="col-lg-3 col-md-6 d-flex">
        <i class="bi bi-geo-alt icon"></i>
        <div>
          <h4>Address</h4>
          <p>
              5 Kingsway Ave<br />
              Rossmore, Johannesburg<br />
              2092, South Africa<br />
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
        $(document).ready(function () {
            // Event listener for adding items to favorites
            $(".add-to-favorites").click(function () {
                var foodId = $(this).data("foodid");

                // Send the request to your API to add the food item to favorites
                $.post("/api/Favorites/addToFavorites", { foodId: foodId })
                    .done(function (response) {
                        if (response === true) {
                            alert("Item added to favorites!");
                        } else {
                            alert("Failed to add item to favorites.");
                        }
                    })
                    .fail(function () {
                        alert("An error occurred while adding to favorites.");
                    });
            });
        });

        function removeFavorite(foodId) {
            $.ajax({
                url: "api/Favorites/" + foodId, // Adjust the API endpoint URL
                type: "DELETE",
                dataType: "json",
                success: function () {
                    // Reload the page after removing a favorite
                    location.reload();
                },
                error: function (error) {
                    console.error("An error occurred while removing the favorite:", error);
                    alert("An error occurred while removing the favorite.");
                }
            });
        }

</script>
</html>
