<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"  CodeBehind="Member_Home.aspx.cs" Inherits="Elibrary.Member_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
    /* Global Styles */
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        margin: 0;
        padding: 0;
    }

    /* Hero Section */
    .hero-section {
        background-image: url('imgs/Yooh.jpg'); /* Your background image URL */
        background-size: cover;
        background-position: top left; /* Align image to top left */
        height: 80vh;
        color: white;
        display: flex;
        align-items: center;
        justify-content: center;
        text-align: center;
        padding: 20px;
    }


    .hero-overlay {
        background: rgba(0, 0, 0, 0.4); /* Dark overlay for text readability */
        padding: 40px;
        border-radius: 10px;
    }

    .hero-title {
        font-size: 50px;
        margin-bottom: 15px;
        color: #f8f9fa; /* Light color for contrast */
        font-weight: bold;
    }

    .hero-subtitle {
        font-size: 28px;
        margin-bottom: 25px;
        color: #e9ecef; /* Slightly lighter color */
    }

    .hero-btn {
        background-color: #28a745; /* Green color */
        color: white;
        padding: 15px 30px;
        font-size: 18px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    .hero-btn:hover {
        background-color: #218838; /* Darker green */
    }

    /* Features Section */
    .features-section {
        padding: 60px 0;
        background-image: url('imgs/Yooh.jpg'); /* Background image under fixtures */
        background-size: cover;
        background-position: center;
        text-align: center;
    }

    .features-section .container {
        max-width: 1200px;
        margin: 0 auto;
    }

    .row {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
    }

    .feature {
        background: rgba(241, 241, 241, 0.9); /* Slightly transparent background */
        border-radius: 10px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        padding: 30px;
        margin: 15px;
        text-align: center;
        flex: 1;
        max-width: 300px;
    }

    .feature-icon {
        font-size: 50px;
        color: #007bff; /* Blue color */
        margin-bottom: 15px;
    }

    .feature-title {
        font-size: 22px;
        margin-bottom: 10px;
        color: #343a40; /* Dark color */
    }

    .feature-text {
        font-size: 16px;
        color: #495057; /* Light gray color */
    }

    /* Responsive Design */
    @media (max-width: 768px) {
        .hero-title {
            font-size: 40px;
        }

        .hero-subtitle {
            font-size: 22px;
        }

        .hero-btn {
            font-size: 16px;
            padding: 12px 25px;
        }

        .feature {
            max-width: 90%; /* Adjust feature width on smaller screens */
        }
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <!-- Admin Features Section -->
<div class="features-section">
    <div class="container">
        <div class="row">
            <div class="col-md-4 feature">
                <a href="Member_Profile.aspx">
                    <i class="fas fa-users feature-icon"></i>
                    <h3 class="feature-title">Update Your details</h3>
                    <p class="feature-text">View and Update your details..</p>
                </a>
            </div>
            <div class="col-md-4 feature">
                <a href="Book_Store.aspx">
                    <i class="fas fa-upload feature-icon"></i>
                    <h3 class="feature-title">Get Your Book</h3>
                    <p class="feature-text">Reserve a  book of your choice</p>
                </a>
            </div>
            <div class="col-md-4 feature">
                <a href="Books_History.aspx">
                    <i class="fas fa-book-open feature-icon"></i>
                    <h3 class="feature-title">View Borrowing History:</h3>
                    <p class="feature-text">check your borrowing records.</p>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 feature">
                <a href="Users_Took_Books.aspx">
                    <i class="fas fa-user-check feature-icon"></i>
                    <h3 class="feature-title">Users Who Took Books</h3>
                    <p class="feature-text">View users who have borrowed books.</p>
                </a>
            </div>
            <div class="col-md-4 feature">
                <a href="Handle_Fines.aspx">
                    <i class="fas fa-money-bill-wave feature-icon"></i>
                    <h3 class="feature-title">Handle Fines</h3>
                    <p class="feature-text">Manage fines for late book returns.</p>
                </a>
            </div>
        </div>
    </div>
</div>





</asp:Content>
