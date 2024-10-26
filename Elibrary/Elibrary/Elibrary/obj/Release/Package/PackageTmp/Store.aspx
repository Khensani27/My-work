<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="Elibrary.Store" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .featured_boks {
            padding: 20px;
        }
        .arrivals {
            text-align: center;
            margin-bottom: 50px;
        }
        .arrivals h1 {
            font-size: 36px;
            color: #333;
            margin-bottom: 20px;
        }
        .arrivals_box {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            gap: 20px;
        }
        .arrivals_card {
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 250px;
            padding: 20px;
            text-align: center;
        }
        .arrivals_image img {
            width: 100%;
            border-radius: 10px;
        }
        .arrivals_tag p {
            font-size: 18px;
            color: #555;
            margin: 10px 0;
        }
        .arrivals_icon {
            margin-bottom: 10px;
        }
        .arrivals_icon i {
            color: gold;
        }
        .arrivals_btn {
            display: inline-block;
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border-radius: 5px;
            text-decoration: none;
            transition: background-color 0.3s;
        }
        .arrivals_btn:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="featured_boks">
        <!-- Arrivals -->
        <div class="arrivals">
            <h1>New Arrivals</h1>
            <div class="arrivals_box">
                <div class="arrivals_card">
                    <div class="arrivals_image">
                        <img src="imgs/arrival_1.jpg">
                    </div>
                    <div class="arrivals_tag">
                        <p>New Arrivals</p>
                        <div class="arrivals_icon">
                            <i class="fa-solid fa-star"></i>
                            <i class="fa-solid fa-star"></i>
                            <i class="fa-solid fa-star"></i>
                            <i class="fa-solid fa-star"></i>
                            <i class="fa-solid fa-star-half-stroke"></i>
                        </div>
                        <a href="#" class="arrivals_btn">Learn More</a>
                    </div>
                </div>

                 <div class="arrivals_card">
     <div class="arrivals_image">
         <img src="imgs/arrival_2.jpg">
     </div>
     <div class="arrivals_tag">
         <p>New Arrivals</p>
         <div class="arrivals_icon">
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star-half-stroke"></i>
         </div>
         <a href="#" class="arrivals_btn">Learn More</a>
     </div>
 </div>


                 <div class="arrivals_card">
     <div class="arrivals_image">
         <img src="imgs/arrival_3.jpg">
     </div>
     <div class="arrivals_tag">
         <p>New Arrivals</p>
         <div class="arrivals_icon">
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star-half-stroke"></i>
         </div>
         <a href="#" class="arrivals_btn">Learn More</a>
     </div>
 </div>

                 <div class="arrivals_card">
     <div class="arrivals_image">
         <img src="imgs/arrival_4.jpg">
     </div>
     <div class="arrivals_tag">
         <p>New Arrivals</p>
         <div class="arrivals_icon">
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star-half-stroke"></i>
         </div>
         <a href="#" class="arrivals_btn">Learn More</a>
     </div>
 </div>

                 <div class="arrivals_card">
     <div class="arrivals_image">
         <img src="imgs/arrival_5.jpg">
     </div>
     <div class="arrivals_tag">
         <p>New Arrivals</p>
         <div class="arrivals_icon">
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star-half-stroke"></i>
         </div>
         <a href="#" class="arrivals_btn">Learn More</a>
     </div>
 </div>

                 <div class="arrivals_card">
     <div class="arrivals_image">
         <img src="imgs/arrival_6.jpg">
     </div>
     <div class="arrivals_tag">
         <p>New Arrivals</p>
         <div class="arrivals_icon">
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star-half-stroke"></i>
         </div>
         <a href="#" class="arrivals_btn">Learn More</a>
     </div>
 </div>

                 <div class="arrivals_card">
     <div class="arrivals_image">
         <img src="imgs/arrival_7.jpg">
     </div>
     <div class="arrivals_tag">
         <p>New Arrivals</p>
         <div class="arrivals_icon">
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star-half-stroke"></i>
         </div>
         <a href="#" class="arrivals_btn">Learn More</a>
     </div>
 </div>

                 <div class="arrivals_card">
     <div class="arrivals_image">
         <img src="imgs/arrival_3.jpg">
     </div>
     <div class="arrivals_tag">
         <p>New Arrivals</p>
         <div class="arrivals_icon">
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star-half-stroke"></i>
         </div>
         <a href="#" class="arrivals_btn">Learn More</a>
     </div>
 </div>

                 <div class="arrivals_card">
     <div class="arrivals_image">
         <img src="imgs/arrival_9.jpg">
     </div>
     <div class="arrivals_tag">
         <p>New Arrivals</p>
         <div class="arrivals_icon">
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star-half-stroke"></i>
         </div>
         <a href="#" class="arrivals_btn">Learn More</a>
     </div>
 </div>

                 <div class="arrivals_card">
     <div class="arrivals_image">
         <img src="imgs/arrival_10.jpg">
     </div>
     <div class="arrivals_tag">
         <p>New Arrivals</p>
         <div class="arrivals_icon">
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star"></i>
             <i class="fa-solid fa-star-half-stroke"></i>
         </div>
         <a href="#" class="arrivals_btn">Learn More</a>
     </div>
 </div>
                <!-- Repeat for other arrivals cards -->

            </div>
        </div>
    </div>
</asp:Content>
