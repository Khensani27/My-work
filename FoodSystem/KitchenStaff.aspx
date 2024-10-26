<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KitchenStaff.aspx.cs" Inherits="FinalYearWeb.KitchenStaff" Async="true"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>

<!-- ======= Header ======= -->
  <header id="header" class="header fixed-top d-flex align-items-center">
    <div class="container d-flex align-items-center justify-content-between">

      <a href="KitchenStaff.aspx" class="logo d-flex align-items-center me-auto me-lg-0">
        <!-- Uncomment the line below if you also wish to use an image logo -->
        <!--<img src="assets/img/logo.png" alt=""> -->
        <h1>Pino's<span>On campus</span></h1>
      </a>

   
     
      <a class="btn-book-a-table" href="Login.aspx">LogOut</a>
      <i class="mobile-nav-toggle mobile-nav-show bi bi-list"></i>
      <i class="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>

    </div>
  </header>
    <!-- End Header -->
    <br />
    <br />

    <form id="mainForm" runat="server">
    <section class="main_content dashboard_part">



<div class="main_content_iner ">
<div class="container-fluid p-0">
<div class="row justify-content-center">
<div class="col-12">
<div class="QA_section">

<div class="QA_table mb_30" >
<h4>Kitchen staff Home</h4>
<table class="table lms_table_active">

<thead>

<tr>
<th scope="col">Customer ID</th>
<th scope="col">Customer Name</th>
<th scope="col">Order Details</th>
<th scope="col">Total Price</th>
<th scope="col">Order Status</th>

</tr>
</thead>
<tbody id="table" runat="server">
<!--<tr>
<th scope="row"> <a href="#" class="question_content">1</a></th>
<td>Mike</td>
<td><a href="#" class="status_btn">2 x Cheese burger with chips, 2 x coke 500ml</a></td>
<td><a href="#" class="status_btn">R 156.99</a></td>
<td>
    <label for="cars">Update order status:</label>
    <select name="update" id="update">
      <option value="processed">Still pending</option>
      <option value="processed">Order being processed</option>
      <option value="Ready">Ready for pickup</option>
    </select>
    <asp:Button ID="Button1" runat="server" Text="Update" />
</td>

</tr>-->
<!--<tr>
<th scope="row"> <a href="#" class="question_content">2</a></th>
<td>Adam</td>
<td><a href="#" class="status_btn">2 x Cheese burger with chips, 2 x coke 500ml</a></td>
<td><a href="#" class="status_btn">R 156.99</a></td>
<td>
      <label for="cars">Update order status:</label>
    <select name="update" id="updateId">
      <option value="processed">Still pending</option>
      <option value="processed">Order being processed</option>
      <option value="Ready">Ready for pickup</option>
    </select>
    <asp:Button ID="Button2" runat="server" Text="Update" />
</td>
</tr>-->

</tbody>

</table>
    <!--<asp:Button ID="Button3" runat="server" Text="All Update Order Status" BackColor="#008000"   Width="1460px" Height="50px" ForeColor="Black" OnClick="btnUpdate"/>-->
</div>
</div>
</div>
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
