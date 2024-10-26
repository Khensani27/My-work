<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Async="true" CodeBehind="Sign_Up.aspx.cs" Inherits="Elibrary.Sign_Up" %>

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
                                <h4 style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; color: #333;">***Member Registration***</h4>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtFirstName" style="font-size: 14px; font-weight: bold;">First Name:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtFirstName" runat="server" placeholder="Full Name" style="padding: 10px; font-size: 14px;" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtLastName" style="font-size: 14px; font-weight: bold;">Last Name:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtLastName" runat="server" placeholder="Last Name" style="padding: 10px; font-size: 14px;" required></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtNumber" style="font-size: 14px; font-weight: bold;">Contact Number:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtNumber" runat="server" placeholder="Contact Number" style="padding: 10px; font-size: 14px;" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtEmailAddress" style="font-size: 14px; font-weight: bold;">Email Address:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtEmailAddress" runat="server" placeholder="Email" TextMode="email" style="padding: 10px; font-size: 14px;" required></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label for="txtAddess" style="font-size: 14px; font-weight: bold;">Address:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtAddess" runat="server" placeholder="Full Address" style="padding: 10px; font-size: 14px;" required></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtPassword" style="font-size: 14px; font-weight: bold;">Password:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" style="padding: 10px; font-size: 14px;" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtPassword1" style="font-size: 14px; font-weight: bold;">Confirm Password:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtPassword1" runat="server" placeholder="Confirm Password" TextMode="Password" style="padding: 10px; font-size: 14px;" required></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="text-center mb-4">
                                <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-danger" Style="display:none;" />
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col text-center">
                                    <asp:Button runat="server" OnClick="Register_Click" ID="login" Text="Register" CssClass="btn btn-success btn-lg btn-block" Style="border-radius: 25px; padding: 10px 20px;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
