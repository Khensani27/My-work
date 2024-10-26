<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="FinalYearWeb.MyAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>My account</title>
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
      <h1>Pino's<span>On campus</span></h1>
    </a>

    <nav id="navbar" class="navbar">
      <ul>
        <li><a href="CustomerHome.aspx" class="nav-item nav-link active">Home</a></li>
        <li><a href="CustomerHome.aspx">Menu</a></li>
          <li><a href="About.aspx">About</a></li>
          <li><a href="Contact.aspx">Contact</a></li>
          
      </ul>
    </nav><!-- .navbar -->
    <div class="d-flex align-items-center">
      <a class="btn-book-a-table me-2" href="MyAccount.aspx"><i class="bi bi-person"></i></a>
      <a class="btn-book-a-table" href="#book-a-table">LogOut</a>
    </div>
    <i class="mobile-nav-toggle mobile-nav-show bi bi-list"></i>
    <i class="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>

  </div>
</header>
    <br />
    <br />
    <br />
    <div class="container mt-5">
      <div class="row justify-content-center">
        <div class="col-lg-6">
          <div class="card">
            <div class="card-body">
              <h2>Account</h2>
              <form id="edit-profile-form">
                <div class="mb-3">
                  <label for="firstName" class="form-label">First Name</label>
                  <input type="text" class="form-control" id="firstName" name="firstName" value="John" disabled=""/>
                </div>
                <div class="mb-3">
                  <label for="lastName" class="form-label">Last Name</label>
                  <input type="text" class="form-control" id="lastName" name="lastName" value="Doe" disabled=""/>
                </div>
                <div class="mb-3">
                  <label for="email" class="form-label">Email</label>
                  <input type="email" class="form-control" id="email" name="email" value="johndoe@example.com" disabled=""/>
                </div>
                <div class="mb-3">
                  <label for="contact" class="form-label">Contact</label>
                  <input type="text" class="form-control" id="contact" name="contact" value="+27 769 0293" disabled=""/>
                </div>
                <div class="text-end">
                  <button type="button" class="btn btn-primary" id="editBtn">Edit</button>
                  <button type="button" class="btn btn-success d-none" id="saveBtn">Save</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
    <br />

       <!-- ======= Footer ======= -->
  <footer id="footer" class="footer">

    <div class="container">
      <div class="row gy-3">
        <div class="col-lg-3 col-md-6 d-flex">
          <i class="bi bi-geo-alt icon"></i>
          <div>
            <h4>Address</h4>
            <p>
              A108 Adam Street <br/>
              New York, NY 535022 - US<br/>
            </p>
          </div>

        </div>

        <div class="col-lg-3 col-md-6 footer-links d-flex">
          <i class="bi bi-telephone icon"></i>
          <div>
            <h4>Reservations</h4>
            <p>
              <strong>Phone:</strong> +1 5589 55488 55<br/>
              <strong>Email:</strong> info@example.com<br/>
            </p>
          </div>
        </div>

        <div class="col-lg-3 col-md-6 footer-links d-flex">
          <i class="bi bi-clock icon"></i>
          <div>
            <h4>Opening Hours</h4>
            <p>
              <strong>Mon-Sat: 11AM</strong> - 23PM<br/>
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
    document.addEventListener("DOMContentLoaded", function () {
      const editBtn = document.getElementById("editBtn");
      const saveBtn = document.getElementById("saveBtn");
      const formFields = document.querySelectorAll("#edit-profile-form input");

      editBtn.addEventListener("click", function () {
        formFields.forEach((field) => {
          field.removeAttribute("disabled");
        });
        editBtn.classList.add("d-none");
        saveBtn.classList.remove("d-none");
      });

      saveBtn.addEventListener("click", function () {
        // You can handle the save functionality here, such as sending the updated data to a server.
        formFields.forEach((field) => {
          field.setAttribute("disabled", "true");
        });
        saveBtn.classList.add("d-none");
        editBtn.classList.remove("d-none");
      });
    });
    </script>
</html>
