<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Book_Issuing_Page.aspx.cs" Inherits="Elibrary.Book_Issuing_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
  <div class="row" style="margin-left: 5px;">
    <div class="col-md-6">
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Placeholder="Search by title, status, author, genre, or ISBN" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
    </div>
</div>

<br />

<div class="col-md-12">
    <div class="card shadow-lg" style="border-radius: 10px;">
        <div class="card-body">
            <div class="row">
                <div class="col">
                    <center>
                        <h4 style="color: #343a40; font-weight: bold;">Check-in and Check-out:</h4>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <hr style="border: 1px solid #343a40;">
                </div>
            </div>

           
            <div id="popupContainer" style="margin-top: 10px; margin-bottom: 10px;"></div>

            <script type="text/javascript">
                // Function to show a popup message with fade-in/fade-out effect
                function showPopup(message, type) {
                    var popupContainer = document.getElementById("popupContainer");
                    var popupDiv = document.createElement("div");
                    popupDiv.className = "alert alert-" + type + " fade show";
                    popupDiv.role = "alert";
                    popupDiv.innerText = message;
                    popupContainer.appendChild(popupDiv);
                    setTimeout(function () {
                        popupDiv.classList.remove("show");
                        setTimeout(function () {
                            popupDiv.remove();
                        }, 500);
                    }, 100000);
                }
            </script>

            <div class="row">
                <div class="col">
                    <hr style="border: 1px solid #343a40;">
                </div>
            </div>

            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="User ID" Visible="false" />
                    <asp:BoundField DataField="BookID" HeaderText="Book ID" Visible="false" />
                    <asp:BoundField DataField="First_Name" HeaderText="First Name" />
                    <asp:BoundField DataField="Last_Name" HeaderText="Last Name" />
                    <asp:BoundField DataField="Title" HeaderText="Book Title" />
                    <asp:BoundField DataField="Genre" HeaderText="Genre" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="Book_Status" HeaderText="Status" />

                   
                   <asp:TemplateField HeaderText="Action">
    <ItemTemplate>
        <asp:Button 
            ID="btnReserve" 
            runat="server" 
            Text='<%# Eval("Book_Status").ToString() == "Reserved" ? "Check Out" : "Check In" %>' 
            CommandName='<%# Eval("Book_Status").ToString() == "Reserved" ? "CheckOutBook" : "CheckInBook" %>' 
            CommandArgument='<%# Eval("UserID") + "," + Eval("BookID") %>' 
            CssClass='<%# Eval("Book_Status").ToString() == "Reserved" ? "btn btn-success btn-sm" : "btn btn-warning btn-sm" %>' 
            Visible='<%# Eval("Book_Status").ToString() != "Pending Fine" && Eval("Book_Status").ToString() != "Returned" %>' />
    </ItemTemplate>
</asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
    </div>
</div>





</asp:Content>
