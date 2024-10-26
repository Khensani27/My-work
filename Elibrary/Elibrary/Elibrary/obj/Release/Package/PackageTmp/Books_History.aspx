<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Books_History.aspx.cs" Inherits="Elibrary.Books_History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="col-md-12">
     <div class="card">
         <div class="card-body">
             <div class="row">
                 <div class="col">
                     <center>
                         <img width="150px" src="imgs/Login.jpg" />
                     </center>
                 </div>
             </div>
               <br/>
             <div class="row">
                 <div class="col">
                     <center>
                         <h4>Your Book History</h4>
                       
                         <label>Account Status:</label><asp:Label ID="Label2" runat="server" Text="Approved" class="badge rounded-pill text-bg-success" style="background-color: #28a745; border-radius: 50rem; color: #fff; padding: 0.5em 1em; font-size: 0.875em; font-weight: 700; line-height: 1; text-align: center; white-space: nowrap; vertical-align: baseline;"></asp:Label>
                     </center>
                 </div>
             </div>
             <div class="row">
                 <div class="col">
                     <hr />
                 </div>
             </div>
             <div class="row">
                 <div class="col">
       <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped" >
      <Columns>
          <asp:BoundField DataField="Title" HeaderText="Title"  />
          <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
          <asp:BoundField DataField="Borrowed_Date" HeaderText="Borrowed Date" />
          <asp:BoundField DataField="Returned_Date" HeaderText="Returned Date" />
          <asp:BoundField DataField="Genre" HeaderText="Genre" />
          <asp:BoundField DataField="Book_Status" HeaderText="Book Status" />
          <asp:BoundField DataField="Fine" HeaderText="FINE" />
      </Columns>
  </asp:GridView>

                 </div>
             </div>
         </div>
     </div>
 </div>
</asp:Content>
