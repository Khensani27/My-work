<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FinalYearWeb.Registration" EnableEventValidation="false" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Employee</title>
        <!-- Favicon -->
    <link href="images/favicon.ico" rel="icon"/>

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
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
    .bold-label {
        font-weight: bold;
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
        <h1>Pino's <span>On campus</span></h1>
      </a>

      <nav id="navbar" class="navbar">
        <ul>
         <li><a href="ManagerHome.aspx" >Home</a></li>
<li><a href="UpdateMenu.aspx">Update Menu</a></li>
<li><a href="StoreStats.aspx">Orders</a></li>
<li><a href=" AllCustomers.aspx">Customers</a></li>
<li><a href="StoreSales.aspx">Sales</a></li> 
             <li><a href="EmployeeManagement.aspx" class="nav-item nav-link active"> Employee Management</a></li>
        
             </ul>
      </nav><!-- .navbar -->

      <a class="btn-book-a-table" href="#book-a-table">LogOut</a>
      <i class="mobile-nav-toggle mobile-nav-show bi bi-list"></i>
      <i class="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>

    </div>
  </header>
    <!-- End Header -->
    <br />
    <br />        
        <div class="modal-header">
            <h5 class="modal-title">REGISTER</h5>
        </div>
             <!-- Reservation Start -->
    <form id="Form2" runat="server">
        <div class="container-xxl py-5 px-0 wow fadeInUp" data-wow-delay="0.1s">
            <div class="row g-0">
                <div class="col-md-6">
                    <div class="video" id="update" runat="server">
                        <section class="about_part">
                        <form id="Form1">
                                <div class="modal-body">
                                     <div class="mb-3">
                                         <asp:Label ID="lblName" runat="server" CssClass="bold-label" Text=""></asp:Label>
		                              </div>

		                               <div class="mb-3">
                                           <asp:Label ID="lblSurname" runat="server" CssClass="bold-label" Text=""></asp:Label>
		                               </div>

		                               <div class="mb-3">
                                           <asp:Label ID="lblEmail" runat="server" CssClass="bold-label" Text=""></asp:Label>
		                               </div>

		                               <div class="mb-3">
                                           <asp:Label ID="lblPhone" runat="server" CssClass="bold-label" Text=""></asp:Label>
		                               </div>
                               </div>
                        </form>
                        </section>
                    </div>
                </div>
                <div class="col-md-6 bg-dark d-flex align-items-center">
                    <div class="p-5 wow fadeInUp" data-wow-delay="0.2s">
                        <h1 class="text-white mb-4">Register Delivery Person</h1>
                                <div class="modal-body">
                                     <div class="mb-3">
			                               <asp:TextBox  ID="name" required="true" Width="500px" Height="40px" placeholder="Employees name" ForeColor="Gray" BorderColor="Gray"    runat="server"></asp:TextBox>
		                              </div>

		                               <div class="mb-3">
			                               <asp:TextBox required="true"    Width="500px" Height="40px"  id="surname" type="text"   placeholder="Employees surname" ForeColor="Gray" BorderColor="Gray"    runat="server"></asp:TextBox>
		                               </div>

		                               <div class="mb-3">
			                               <asp:TextBox  required="true"   Width="500px" Height="40px" id="email" type="email"   placeholder="Email address" ForeColor="Gray" BorderColor="Gray"    runat="server"></asp:TextBox>
		                               </div>

		                               <div class="mb-3">
			                               <asp:TextBox required="true"    Width="500px" Height="40px" id="phone" type="phone"  placeholder="Phone number" ForeColor="Gray" BorderColor="Gray"    runat="server"></asp:TextBox>
		                               </div>
                                        <div class="mb-3">
			                               <asp:TextBox required="true"    Width="500px" Height="40px" id="password" type="text"  placeholder="Password" ForeColor="Gray" BorderColor="Gray"    runat="server"></asp:TextBox>
		                               </div>
		                             <div class="mb-3">  
                                         <asp:Button ID="Button1" runat="server" Text="Register" BackColor="#5A5A5A"   Width="500px" Height="50px" ForeColor="Black" OnClick="btnRegister" />
			                              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
		                            </div>
                             
                               </div>
                    </div>
                </div>
            </div>
        </div>
        </form>
    <!-- Reservation End -->

  <!-- ======= Footer ======= -->
  <footer id="footer" class="footer">

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
        <!-- All the links in the footer should remain intact. -->
        <!-- You can delete the links only if you purchased the pro version. -->
        <!-- Licensing information: https://bootstrapmade.com/license/ -->
        <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/yummy-bootstrap-restaurant-website-template/ -->
        Designed by <a href="https://bootstrapmade.com/">BootstrapMade</a>
      </div>
    </div>

  </footer><!-- End Footer -->

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
</html>
