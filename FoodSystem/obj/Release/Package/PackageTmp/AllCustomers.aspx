<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllCustomers.aspx.cs" Inherits="FinalYearWeb.AllCustomers" Async="true"%>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customers</title>
  
        <!-- jQuery -->
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <!-- DataTables JavaScript -->

    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.7.0/chart.min.js"></script>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>

<!-- DataTables CSS -->
<link rel="stylesheet" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css" />


    <link href="images/favicon.ico" rel="icon"/>
    <!--Modal-->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"/>
  
  
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
    <link href="css/main.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
      
</head>
<body>
    <form id="form1" runat="server">
  <!-- ======= Header ======= -->
    <header id="header" class="header fixed-top d-flex align-items-center">
        <div class="container d-flex align-items-center justify-content-between">
            <a href="#" class="logo d-flex align-items-center me-auto me-lg-0">
                <h1>Pino's <span>On campus</span></h1>
            </a>
            
            <nav id="navbar" class="navbar">
                <ul>
                   <li><a href="ManagerHome.aspx" >Home</a></li>
                    <li><a href="UpdateMenu.aspx">Update Menu</a></li>
<li><a href="StoreStats.aspx">Orders</a></li>
<li><a href=" AllCustomers.aspx" class="nav-item nav-link active">Customers</a></li>
<li><a href="StoreSales.aspx">Sales</a></li> 
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
         <div class="text-center" >
             <h3 class="mb-5">Active Customers</h3>
         </div>
        <div>
   <div class="search-container">
        <input type="text" id="searchBar"  placeholder="Search for customer name" style="width: 500px; height:40px; border-color:green"  />
        <i class="fas fa-search search-icon"></i>
   
</div>
         
</div>
<br />
         <asp:Literal ID="userTableLiteral" runat="server">
              <table class="content"> 
  
</table>
         </asp:Literal>


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

    <script>
        $(document).ready(function () {
            var $rows = $("#userTableLiteral tr"); // Select all rows in the table including the headers
            $("#searchBar").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $rows.show(); // Show all rows initially

                // Filter rows (excluding the first row, which is the header row)
                $rows.slice(1).filter(function () {
                    var text = $(this).text().toLowerCase();
                    return text.indexOf(value) === -1;
                }).hide(); // Hide rows that don't match the search query
            });
        });

    </script>

     <script>
         document.addEventListener('DOMContentLoaded', function () {
             const content = document.querySelector('.userTableLiteral');
             const itemsPerPage = 5;
             let currentPage = 0;
             const items = Array.from(content.getElementsByTagName('tr')).slice(1);

             function showPage(page) {
                 const startIndex = page * itemsPerPage;
                 const endIndex = startIndex + itemsPerPage;
                 items.forEach((item, index) => {
                     item.classList.toggle('hidden', index < startIndex || index >= endIndex);
                 });
                 updateActiveButtonStates();
             }

             function createPageButtons() {
                 const totalPages = Math.ceil(items.length / itemsPerPage);
                 const paginationContainer = document.createElement('div');
                 paginationContainer.classList.add('pagination');
                 document.body.appendChild(paginationContainer);

                 // Add page buttons
                 for (let i = 0; i < totalPages; i++) {
                     const pageButton = document.createElement('button');
                     pageButton.textContent = i + 1;
                     pageButton.addEventListener('click', () => {
                         currentPage = i;
                         showPage(currentPage);
                         updateActiveButtonStates();
                     });

                     paginationContainer.appendChild(pageButton);
                 }
             }

             function updateActiveButtonStates() {
                 const pageButtons = document.querySelectorAll('.pagination button');
                 pageButtons.forEach((button, index) => {
                     if (index === currentPage) {
                         button.classList.add('active');
                     } else {
                         button.classList.remove('active');
                     }
                 });
             }

             createPageButtons(); // Call this function to create the page buttons initially
             showPage(currentPage);
         });
     </script>
    
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

