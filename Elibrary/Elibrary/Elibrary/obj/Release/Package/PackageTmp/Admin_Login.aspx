<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin_Login.aspx.cs" Inherits="Elibrary.Admin_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="150px" src="imgs/adminuser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>**Admin Login**</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="email" runat="server" placeholder="username"></asp:TextBox>
                        </div>
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="password" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
                        </div>
                         <div class="form-group">
                                      <div style="display: flex; justify-content: center; align-items: center; height: 80%; margin: 0 auto;">
    <asp:Button 
        runat="server" 
        OnClick="login_Click" 
        ID="login" 
        Text="Login"
        Style="background-color: #22DD22; color: white; border: none; border-radius: 5px; padding: 15px; text-align: center; font-size: 18px; cursor: pointer; width: 110%; max-width: 500px;" 
    />
</div>
                                </div>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                     </div>
                  </div>
               </div>
            </div>
           
         </div>
      </div>
   </div>
         
</asp:Content>
