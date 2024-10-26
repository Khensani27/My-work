<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Async="true" CodeBehind="Login.aspx.cs" Inherits="Elibrary.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
   
        <div class="container-fluid" style="background-image: url('imgs/Admin1.jpg'); background-size: cover; background-repeat: no-repeat; min-height: 100vh; display: flex; justify-content: center; align-items: center;">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card shadow-lg" style="border-radius: 10px;">
                        <div class="card-body p-5">
                            <div class="text-center mb-4">
                                <img width="150px" src="imgs/Login.jpg" class="img-fluid" />
                            </div>
                            <div class="text-center">
                                <h3 style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; color: #333;">Login</h3>
                            </div>
                            <hr>
                            <div class="form-group">
                                <label for="email" style="font-size: 14px; font-weight: bold;">Email</label>
                                <asp:TextBox CssClass="form-control" ID="email" runat="server" placeholder="Enter your email" style="padding: 10px; font-size: 14px;"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" style="font-size: 14px; font-weight: bold;">Password</label>
                                <asp:TextBox CssClass="form-control" ID="password" runat="server" placeholder="Enter your password" TextMode="Password" style="padding: 10px; font-size: 14px;"></asp:TextBox>
                            </div>
                            <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-danger" Style="display:none;" />
                            <div class="form-group mt-4">
                                <asp:Button 
                                    runat="server" 
                                    OnClick="login_Click" 
                                    ID="login" 
                                    Text="Login"
                                    CssClass="btn btn-primary btn-lg btn-block" 
                                    Style="background-color: #3498db; color: white; border-radius: 5px; font-size: 16px;" 
                                />
                            </div>
                            <div class="form-group text-center mt-3">
                                <span style="font-size: 16px;">Don't you have an account? </span>
                                <a href="Sign_Up.aspx" style="font-size: 16px; color: #007bff; text-decoration: none; font-weight: bold;">Sign up</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
           
            
</asp:Content>
