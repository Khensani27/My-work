<%@ Page Title="Library Management Home" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Elibrary.Home" %>

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
        background-image: url('imgs/yes.jpg'); /* Background image */
        background-size: cover;
        background-position: top left;
        height: 80vh;
        color: white;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        text-align: center;
        padding: 20px;
    }

    .hero-overlay {
        background: rgba(0, 0, 0, 0.5); /* Dark overlay for text readability */
        padding: 40px;
        border-radius: 10px;
        max-width: 80%;
    }

    .hero-title {
        font-size: 50px;
        margin-bottom: 15px;
        color: #f8f9fa;
        font-weight: bold;
    }

    .hero-subtitle {
        font-size: 28px;
        margin-bottom: 25px;
        color: #e9ecef;
    }

    .hero-btn {
        background-color: #28a745;
        color: white;
        padding: 15px 30px;
        font-size: 18px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s ease;
        text-decoration: none;
    }

    .hero-btn:hover {
        background-color: #218838;
    }

    /* Features Section */
    .row {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        margin-top: 30px;
    }

    .feature {
        background: rgba(241, 241, 241, 0.9);
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
        color: #007bff;
        margin-bottom: 15px;
    }

    .feature-title {
        font-size: 22px;
        margin-bottom: 10px;
        color: #343a40;
    }

    .feature-text {
        font-size: 16px;
        color: #495057;
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
            max-width: 90%;
        }
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="hero-section">
        <div class="hero-overlay">
            <h1 class="hero-title">Welcome to Vryheid e-Library</h1>
            <p class="hero-subtitle">Discover the Power of Knowledge at Your Fingertips</p>
            <a href="Sign_Up.aspx" class="hero-btn">Join Us Today</a>
        </div>
        
        
        <div class="row">
            
            <div class="feature">
                <i class="fas fa-book feature-icon"></i>
                <h3 class="feature-title">Explore Books</h3>
                <p class="feature-text">Browse through our extensive collection of books.</p>
            </div>

            
            <div class="col-md-4 feature">
                <i class="fas fa-user-friends feature-icon"></i>
                <h3 class="feature-title">Manage Your Account</h3>
                <p class="feature-text">Handle your library account with ease.</p>
            </div>

           
            <div class="col-md-4 feature">
                <i class="fas fa-calendar-alt feature-icon"></i>
                <h3 class="feature-title">Events & Workshops</h3>
                <p class="feature-text">Participate in our exciting events and workshops.</p>
            </div>
        </div>
    </div>
</asp:Content>
