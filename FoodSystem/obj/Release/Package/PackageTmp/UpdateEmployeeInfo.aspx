﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateEmployeeInfo.aspx.cs" Inherits="FinalYearWeb.UpdateEmployeeInfo" Async="true"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
  <link href="images/favicon.ico" rel="icon"/>
    <!--Modal-->
   
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    
 
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
    <form id="form2" runat="server">
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
<li><a href="UpdateMenu.aspx" class="nav-item nav-link active">Update Menu</a></li>
<li><a href="StoreStats.aspx">Orders</a></li>
<li><a href=" AllCustomers.aspx">Customers</a></li>
<li><a href="StoreSales.aspx">Sales</a></li> 
             <li><a href="EmployeeManagement.aspx"> Employee Management</a></li>
        
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

     <div class="container-xxl py-5">
            <div class="container">
                <div class="text-center" >
                    <h4 class="section-title ff-secondary text-center text-primary fw-normal">Manager</h4>
                    <h3 class="mb-5">Employee Management</h3>
                </div>

             <div class="container-xxl py-5 px-0 wow fadeInUp" data-wow-delay="0.1s">
            <div class="row g-0">
                <div class="col-md-6">
                    <div class="video" id="update" runat="server">

                    </div>
                </div>
                <div class="col-md-6 bg-dark d-flex align-items-center">
                    <div class="p-5 wow fadeInUp" data-wow-delay="0.2s">
                        <h1 class="text-white mb-4">Update Employee Details</h1>
                        
                                <div class="modal-body">
                                
                                  <div class="mb-3">
                                       <asp:TextBox  ID="nameUpdate" Width="550px" Height="40px" placeholder="Employee name" ForeColor="Gray" BorderColor="Gray"    runat="server"></asp:TextBox>
                                  </div>

                                   <div class="mb-3">
                                       <asp:TextBox     Width="550px" Height="40px"  id="emailUpdate" type="text"   placeholder="Employee Email" ForeColor="Gray" BorderColor="Gray"    runat="server"></asp:TextBox>
                                   </div>

                                   <div class="mb-3">
                                       <div>
                                            <asp:Label ID="Label1" runat="server" BackColor="Gray" Text="Upload New Image"></asp:Label><asp:FileUpload ID="FileUpload1" CssClass="custom-fileupload"  runat="server" /> <asp:Button ID="Button1" BackColor="#008000" ForeColor="Black" runat="server" Text="Upload" OnClick="btnUpload" />
                                       </div>
                                       <asp:Label ID="Status" runat="server" Text=""></asp:Label>
                                       <!--<asp:TextBox      Width="550px" Height="40px" id="imageUpdate" type="text"   placeholder="Item image" ForeColor="Gray" BorderColor="Gray" runat="server"></asp:TextBox>-->
                                   </div>

                                   <div class="mb-3">
                                       <asp:TextBox   Width="550px" Height="40px" id="addressUpdate" type="text"  placeholder="Employee Address" ForeColor="Gray" BorderColor="Gray"    runat="server"></asp:TextBox>
                                        
                                   </div>
                                   <div class="mb-3">
                                       <asp:TextBox   Width="550px" Height="40px" id="languageUpdate" type="text"  placeholder="Language" ForeColor="Gray" BorderColor="Gray"    runat="server"></asp:TextBox>
                                       
                                   </div>
                                 <div class="mb-3">
                                     
                                         <asp:Button ID="Button2" runat="server" Text="Update" BackColor="#008000" AutoPostBack ="true" Width="550px" Height="50px" ForeColor="Black" OnClick="btnUpdateMenu"/>
                                         <asp:Label ID="LblErro" runat="server" Text=""></asp:Label>
                                    
                                </div>
       


                               
                                </div>

                        </form>
                    </div>
                </div>
            </div>
        </div>

                   

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
</html>

