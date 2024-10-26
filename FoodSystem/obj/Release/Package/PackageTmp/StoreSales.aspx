<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreSales.aspx.cs" Inherits="FinalYearWeb.StoreSales" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Report</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.7.0/chart.min.js"></script>
    <!-- Include chartjs-adapter-date-fns from a CDN -->
<script src="https://cdn.jsdelivr.net/npm/chartjs-adapter-date-fns/dist/chartjs-adapter-date-fns.bundle.min.js"></script>
             <!-- Include Chart.js from a CDN -->
<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

  <link href="images/favicon.ico" rel="icon"/>
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
     
</head>
<body>
    <form id="form2" runat="server">
  <!-- ======= Header ======= -->
    <header id="header" class="header fixed-top d-flex align-items-center">
        <div class="container d-flex align-items-center justify-content-between">
            <a href="#" class="logo d-flex align-items-center me-auto me-lg-0">
                <h1>Pino's <span>On campus</span></h1>
            </a>
            
            <nav id="navbar" class="navbar">
                <ul>
                   <li><a href="ManagerHome.aspx">Home</a></li>
<li><a href="UpdateMenu.aspx">Update Menu</a></li>
<li><a href="StoreStats.aspx">Orders</a></li>
<li><a href=" AllCustomers.aspx">Customers</a></li>
<li><a href="StoreSales.aspx" class="nav-item nav-link active">Sales</a></li> 
                     <li><a href="EmployeeManagement.aspx"> Employee Management</a></li>
        
            
                </ul>

            </nav><!-- .navbar -->
            <a class="btn-book-a-table" href="Login.aspx">LogOut</a>
            <i class="mobile-nav-toggle mobile-nav-show bi bi-list"></i>
            <i class="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>

        </div>
    </header>
        <br />
        <br />
      
  <div class="container-xxl py-5">
   <div class="container">
        <div class="text-center">
            
            <h3 class="mb-5">Sales</h3>
        </div>

       
                 
       <br />
       <br />
       <br />
        <div class="row">
  <div class="col-md-8 mb-1">
            
          <div class="container2" style="background-color: white; height: 600px; width: 700px">
                      <ul class="nav nav-tabs d-flex justify-content-center" data-aos="fade-up" data-aos-delay="200" style="height:40px">

  <li class="nav-item">
    <a class="nav-link active show" data-bs-toggle="tab" data-bs-target="#menu-special" style="height:40px">
      <p>Weekly Sales</p>
    </a>
  </li><!-- End tab nav item -->

  <li class="nav-item">
    <a class="nav-link" data-bs-toggle="tab" data-bs-target="#menu-breakfast" style="height:40px">
      <p>Monthly Sales</p>
    </a><!-- End tab nav item -->
      </li>

  <li class="nav-item">
    <a class="nav-link" data-bs-toggle="tab" data-bs-target="#menu-lunch" style="height:40px">
      <p>Yearly Sales</p>
    </a>
  </li><!-- End tab nav item -->

  

</ul>

        <div class="tab-content" data-aos="fade-up" data-aos-delay="300">

          <div class="tab-pane fade active show" id="menu-special">

            <div class="tab-header text-center">
              
             
            </div>
               <div class="container1"  style="height: 600px; width: 700px">
        <h2>Weekly Sales Chart</h2>
        <canvas id="weeklyChart" ></canvas>
    </div>
          </div>

          <div class="tab-pane fade" id="menu-breakfast">

            <div class="tab-header text-center">
              
            </div>
               <div class="container1"  style="height: 600px; width: 700px">
                <h2>Monthly Sales Chart</h2>
                <canvas id="monthlyChart"></canvas>
            
                   </div>
            
          </div>

          <div class="tab-pane fade" id="menu-lunch">

            <div class="tab-header text-center">
             
            </div>
               <div class="container1"  style="height: 600px; width: 700px">
        <h2>Yearly Sales Chart</h2>
        <canvas id="yearlyChart"></canvas>
        </div>
         </div>   
          </div>
            </div>
        </div> 
             <div class="col-md-4 mt-1">
      <div class="container2" style=" height: 600px; width: 500px">
          <h2>Categories</h2>
<canvas id="weeklyPieChart" ></canvas>
</div>
                 
                 </div>
</div>

       <br />

                    
       </div>
      </div>
        

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
    </form>

 
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
