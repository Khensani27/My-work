<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Async="true" CodeBehind="Member_Profile.aspx.cs" Inherits="Elibrary.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="background-image: url('imgs/Admin1.jpg'); background-size: cover; background-repeat: no-repeat; height: 100vh;">
        <div class="row h-100">
            <div class="col d-flex justify-content-center align-items-center">
                <div class="col-md-5"> <!-- Adjusted width for better responsiveness -->
                    <div class="card">
                        <div class="card-body">
                            <!-- Message Label for displaying messages -->
                            <asp:Label ID="lblMessage" runat="server" CssClass="alert" style="display: none;"></asp:Label>

                            <!-- Profile Picture -->
                            <div class="row">
                                <div class="col text-center">
                                    <img width="150px" src="imgs/Login.jpg" alt="Profile Picture" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col text-center">
                                    <h4>User Profile</h4>
                                    <span>Account Status: </span>
                                    <asp:Label ID="Label1" runat="server" 
                                        class="badge rounded-pill text-bg-success" 
                                        style="background-color: #28a745; border-radius: 50rem; color: #fff; padding: 0.5em 1em; font-size: 0.875em; font-weight: 700; line-height: 1; text-align: center; white-space: nowrap; vertical-align: baseline;"></asp:Label>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <label>First Name:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="lblFirstName" runat="server" placeholder="Full Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Last Name:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="lblLastName" runat="server" placeholder="Date of Birth"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>Contact Number:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="lblNumber" runat="server" placeholder="Contact Number" TextMode="number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Email Address:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="lblEmail" runat="server" placeholder="Email Address" TextMode="email"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Address:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="lblAddress" runat="server" placeholder="Address"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <br />
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="User ID" TextMode="number" Visible="false" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <label>New Password:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="lblPassword" runat="server" placeholder="New Password" TextMode="password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col text-center">
                                    <asp:Button 
                                        runat="server" 
                                        OnClick="Update_Click" 
                                        ID="update" 
                                        Text="Update"
                                        CssClass="btn btn-info btn-lg"
                                        Style="background-color: #95a5a6; color: white; border-radius: 5px;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
