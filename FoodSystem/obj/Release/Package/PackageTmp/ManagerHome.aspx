<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerHome.aspx.cs" Inherits="FinalYearWeb.ManagerHome" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manager Home</title>
<script src="https://cdn.plot.ly/plotly-latest.min.js"></script>

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>

        <!-- Favicon -->
    <link href="images/favicon.ico" rel="icon"/>
     
    <!-- Icon Font Stylesheet -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css" rel="stylesheet"/>
 
    <!-- Libraries Stylesheet -->
    <link href="lib/animate/animate.min.css" rel="stylesheet"/>
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet"/>
    <link href="lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />

    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/css/bootstrap.min.css" rel="stylesheet"/>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  
    <!-- Template Stylesheet -->
    <link href="css/css/style.css" rel="stylesheet"/>
    <link href="assets/css/main.css" rel="stylesheet"/>
    <link href="css/main.css" rel="stylesheet"/>   
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

</head>
<body>
    <form id="form1" runat="server">
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
            <li><a href="ManagerHome.aspx" class="nav-item nav-link active">Home</a></li>
            <li><a href="UpdateMenu.aspx">Update Menu</a></li>
            <li><a href="StoreStats.aspx">Orders</a></li>
            <li><a href="AllCustomers.aspx">Customers</a></li>
            <li><a href="StoreSales.aspx">Sales</a></li> 
            <li><a href="EmployeeManagement.aspx"> Employee Management</a></li>
        
        </ul>
      </nav><!-- .navbar -->


      <a class="btn-book-a-table" href="Login.aspx">LogOut</a>
      <i class="mobile-nav-toggle mobile-nav-show bi bi-list"></i>
      <i class="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>

    </div>
  </header>
    <!-- End Header -->
    <br />
    <br />
        <div style="background-color: #F1F8FF">
             <div class="container-xxl py-5">
 
                <div class="text-center" >
                  <!--  <h4 class="section-title ff-secondary text-center text-primary fw-normal">Manager</h4>-->
                    <h3 class="mb-5">Store Statistics Overview</h3>
                </div>
                <div class="row g-4">
                    <div class="col-lg-3 col-sm-6" >
    <div class="service-item rounded pt-3" style="background-color:white; height: 150px; width: 320px;">
        <div class="p-4">
             <h3>Today's Orders</h3>
             <div class="icon-container">
           <i class="fas fa-shopping-basket" style="font-size:48px;color:green"></i>
            </div>
             <div class="icon-container">
            <h3><asp:Label ID="dialyLbl" runat="server" Text=""></asp:Label></h3>
            </div>
        </div>
    </div>
</div>

   <div class="col-lg-3 col-sm-6" >
    <div class="service-item rounded pt-3" style="background-color:white; height: 150px; width: 320px;">
        <div class="p-4">
             <h3>Total Customers</h3>
             <div class="icon-container">
           <i class="fas fa-user-plus" style="font-size:48px;color:green"></i>
            </div>
             <div class="icon-container">
            <h3><asp:Label ID="usersLbl" runat="server" Text=""></asp:Label></h3>
            </div>
             <div class="icon-container">
                <p style="color:green">New today: <asp:Label ID="Label1" runat="server" Text=" "></asp:Label></p>
            </div>
        </div>
    </div>
</div>

                    
   <div class="col-lg-3 col-sm-6" >
    <div class="service-item rounded pt-3" style="background-color:white; height: 150px; width: 320px;">
        <div class="p-4">
             <h3>Today's Sales </h3>
             <div class="icon-container">
            <i class="fas fa-coins" style="font-size:48px;color:green"></i>
                 </div>
            <div class="icon-container">
            <h3>R<asp:Label ID="salesLbl" runat="server" Text=""></asp:Label></h3>
        </div>
        </div>
    </div>
</div>

                    
   <div class="col-lg-3 col-sm-6" >
    <div class="service-item rounded pt-3" style="background-color:white; height: 150px; width: 320px;">
        <div class="p-4">
                <h3>Total Menu Items </h3>
             <div class="icon-container">
<i class="fa fa-hourglass-half" style="font-size:48px;color:green"></i>
                 </div>
             <div class="icon-container">

<h3><asp:Label ID="ItemCountLabel" runat="server" Text=""></asp:Label></h3>
                 </div>
        </div>
    </div>
</div>

    <div class="container2" style="height: 500px; width: 300px">  
   <h3>Order Statuses</h3>
  <div style="height: 180px; width: 250px; display: flex; flex-direction: column; justify-content: space-between;">
    <div style="display: flex; align-items: center;">
        <img src="images/processing.png" alt="" width="20" height="20"/>
        <h4 style="margin-left: 20px;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></h4>
    </div>
    <div style="display: flex; align-items: center;">
        <img src="images/ready.png" alt="" width="20" height="20"/>
        <h4 style="margin-left: 20px;"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></h4>
    </div>
    <div style="display: flex; align-items: center;">
        <img src="images/collected.png" alt="" width="20" height="20"/>
        <h4 style="margin-left: 20px;"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></h4>
    </div>
    <div style="display: flex; align-items: center;">
        <img src="images/delivered.png" alt="" width="20" height="20"/>
        <h4 style="margin-left: 20px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></h4>
    </div>
</div>


<h3>Most Bought Today</h3>
        <div style="display: flex; align-items: center;">
    <asp:Image ID="mostBoughtItemImage" runat="server" AlternateText="Most Bought Item" Width="100px" Height="120px"/>
    <div style="margin-left: 20px;">
        <h4><asp:Label ID="mostBoughtLabel" runat="server" Text=""></asp:Label></h4>
        <h5><asp:Label ID="mostBoughtCountLabel" runat="server" Text=""></asp:Label></h5>
    </div>
</div>

</div>

      <div class="container2" style="height: 500px; width: 550px">  
    <h3>Active Hours</h3>
        <!--  <canvas id="weeklyChart"></canvas>-->
           <div id="weeklyChart" style="height: 400px; width:500px"></div>

</div>

<div class="container2" style="height: 500px; width: 400px">  
    <h3>Customer Type</h3>
   
    <div id="pieChart"></div>

</div>

                   
     <div class="container1" style=" width: 600px;">  
     <h3>Top 10%  Items Bought</h3>
          <asp:Literal ID="foodTable" runat="server">
                 <table class="custom-table"> 
                  
                </table>
            </asp:Literal> 
 </div>
        
          
                                     
   <div class="container1" style=" width: 600px">
      <h3>Bottom 10% Items Bought</h3>
             <asp:Literal ID="bottomItemsTable" runat="server">
        <table class="custom-table"> 
         
       </table>
   </asp:Literal> 
</div>
         
                </div>
            </div>
           </div>
        
        <!-- Service End -->

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

</html>
