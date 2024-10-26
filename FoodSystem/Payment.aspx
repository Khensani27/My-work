<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="FinalYearWeb.Payment" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment</title>
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
               <%-- <div class="cart_count"><span>10</span></div>--%>
                </div>
                <div class="cart_content">
                <div class="cart_text"><a href="Cart.aspx">Cart</a></div>
               <%-- <div class="cart_price">$85</div>--%>
            </div>
           </div>
           </div>
      </a>
    </div>
  </header>
    <!-- End Header -->
    <br />
    <br />

     <!-- Payment page content -->
<form id="form1" runat="server">
    <div class="container py-5">
        <div class="row mb-4">
            <div class="col-lg-8 mx-auto text-center">
                <h1 class="display-6">Payment</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 mx-auto">
                <div class="card">
                    <div class="card-header">
                        <%--<div class="bg-white shadow-sm pt-4 pl-2 pr-2 pb-2">
                            <!-- Credit card form tabs -->
                            <ul role="tablist" class="nav bg-light nav-pills rounded nav-fill mb-3">
                                <li class="nav-item"><a data-toggle="pill" href="#credit-card" class="nav-link active "><i class="fas fa-credit-card mr-2"></i>Card </a></li>
                            </ul>
                        </div>--%>
                        <!-- End -->
                        <!-- Credit card form content -->
                        <div class="tab-content">
                            <!-- credit card info-->
                            <div id="credit-card" class="tab-pane fade show active pt-3">
                                <div class="form-group">
                                    <label for="surname">
                                        <h6>Surname</h6>
                                    </label>
                                    <input runat="server" id="txtsurname" type="text" name="surname" placeholder="Surname" required class="form-control"/>
                                </div>
                                <div class="form-group">
                                    <label for="contacts">
                                        <h6>Contact Information</h6>
                                    </label>
                                    <input runat="server" id="txtcontacts" type="text" name="contacts" placeholder="Contact Information" required class="form-control"/>
                                </div>
                                <div class="form-group">
                                    <label for="cardNumber">
                                        <h6>Card number</h6>
                                    </label>
                                    <div class="input-group">
                                        <input runat="server" id="txtcardnumber" type="number" name="cardNumber" placeholder="Valid card number" class="form-control" required>
                                        <div class="input-group-append"><span class="input-group-text text-muted"><i class="fab fa-cc-visa mx-1"></i><i class="fab fa-cc-mastercard mx-1"></i><i class="fab fa-cc-amex mx-1"></i></span></div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            <label>
                                                <span class="hidden-xs">
                                                    <h6>Expiration Date</h6>
                                                </span>
                                            </label>
                                            <div class="input-group">
                                                <input runat="server" id="txtmm" type="number" placeholder="MM" name="" class="form-control" required/>
                                                <input runat="server" id="txtyy" type="number" placeholder="YY" name="" class="form-control" required/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group mb-4">
                                            <label data-toggle="tooltip" title="Three digit CV code on the back of your card">
                                                <h6>CVV <i class="fa fa-question-circle d-inline"></i></h6>
                                            </label>
                                            <input runat="server" id="txtcvv" type="text" required class="form-control"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <%--<label for="Amount">
                                        <h6>Amount to pay</h6>
                                    </label>
                                    <div class="input-group">
                                        <input runat="server" id="txtAmount" name="Amount" placeholder="Enter the payment amount" class="form-control" required>
                                    </div>--%>
                                   <%-- <asp:Label ID="lblError" runat="server" Text=""></asp:Label>--%>
                                     <asp:Label ID="totalAmountLabel" runat="server"></asp:Label>
                                </div>
                               
                             <%--<div class="form-group">
                            <label for="Amount">
                                <h6>Amount to pay</h6>
                            </label>
                            <div class="input-group">
                                <input id="Text1" runat="server" name="Amount" value="<%= Request.QueryString["totalAmount"] %>" class="form-control" required readonly>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </div>
                        </div>  --%>

                            </div>
                        </div>
                        <!-- End -->
                        <div class="row">
        <div class="col-lg-6 mx-auto">
            <div class="text-center">
                <button id="btnSubmit" type="submit" class="btn btn-primary btn-block py-2" >
                  <i class="fa fa-check"></i> Submit Payment
                 </button>
<%--                    <asp:Button ID="Button1" runat="server" Text="Submit Payment" class="btn btn-primary btn-block py-2" OnClick="Button1_Click"/> --%>                
            </div>
        </div>
    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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

    <script type="text/javascript">
        const cartData = JSON.parse('<%=getAllCartValues()%>');
        console.log(cartData);

        let buttonHandler = document.getElementById("btnSubmit");

        buttonHandler.addEventListener("click", function (event) {
            event.preventDefault();
            postDataArrayToApi(cartData);
            window.location.href = "ThankYou.aspx";
        });

        function postDataArrayToApi(dataArray) {

            const apiUrl = 'http://localhost:5280/api/Orders/CreateOrder';

            dataArray.forEach((data, index) => {

                const requestOptions = {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json', 
                    },
                    body: JSON.stringify(data), 
                };

                fetch(apiUrl, requestOptions)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        //return response.json(); 
                    })
                    .then(result => {
                        console.log(`Data item ${index + 1} posted successfully:`, result);
                    })
                    .catch(error => {
                        console.error(`Error posting data item ${index + 1}:`, error);
                    });
            });
        }
    </script>
</html>