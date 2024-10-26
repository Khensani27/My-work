<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Elibrary.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Custom CSS for additional styling */
        .page-header {
            font-size: 28px;
            color: #5a5a5a;
            font-weight: bold;
            padding-bottom: 15px;
            border-bottom: 2px solid #ddd;
        }

        .search-box {
            display: flex;
            justify-content: center;
            margin-top: 20px;
        }

        .search-box .form-control {
            max-width: 500px;
            height: 45px;
            border-radius: 5px;
        }

        .table {
            margin-top: 30px;
            border-radius: 5px;
            overflow: hidden;
        }

        .table th {
            background-color: #007bff;
            color: white;
        }

        .table td, .table th {
            vertical-align: middle;
        }

        .table-striped tbody tr:nth-of-type(odd) {
            background-color: rgba(0, 123, 255, 0.05);
        }

        /* Optional footer styling for better structure */
        .footer {
            margin-top: 30px;
            text-align: center;
            padding: 15px;
            background-color: #f7f7f7;
            border-top: 1px solid #ddd;
            color: #777;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
     
        <h3 class="page-header text-center">Manage Fines:</h3>

        
        <div class="search-box">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Placeholder="Search by title, author, or genre" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
        </div>

     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-bordered">
    <Columns>
        <asp:BoundField DataField="UserID" HeaderText="User ID" Visible="false" />
        <asp:BoundField DataField="BookID" HeaderText="Book ID" Visible="false" />
        <asp:BoundField DataField="UserFirstName" HeaderText="First Name" />
        <asp:BoundField DataField="UserSurname" HeaderText="Surname" />
        <asp:BoundField DataField="BookTitle" HeaderText="Book Title" />
        <asp:BoundField DataField="Borrowed_Date" HeaderText="Borrowed Date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="Returned_Date" HeaderText="Returned Date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="Fine" HeaderText="Fine" DataFormatString="{0:C}" />
        <asp:BoundField DataField="Book_Status" HeaderText="Book Status" />
        <asp:TemplateField HeaderText="Settle Fine">
            <ItemTemplate>
                <asp:Button ID="btnSettleFine" runat="server" Text="Settle Fine" CssClass="btn btn-success"
                            OnClick="btnSettleFine_Click" CommandArgument='<%# Eval("UserID") + "," + Eval("BookID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>



    </div>

    
   

</asp:Content>
