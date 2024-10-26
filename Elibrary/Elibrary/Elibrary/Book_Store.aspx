<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site1.Master" Async="true" AutoEventWireup="true" CodeBehind="Book_Store.aspx.cs" Inherits="Elibrary.Book_Store" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" />
    <link rel="stylesheet" href="~/Content/site.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="row" style="margin-left: 5px;">
        <div class="col-md-6">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Placeholder="Search by title, author, genre, or ISBN" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
        </div>
    </div>

    <br />
    <div class="col-md-12">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Available Books</h4>
                        </center>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <hr>
                    </div>
                </div>
                <div id="popupContainer"></div>

                <script type="text/javascript">
                    // Function to show a popup message.
                    function showPopup(message, type) {
                        var popupContainer = document.getElementById("popupContainer");
                        var popupDiv = document.createElement("div");
                        popupDiv.className = "alert alert-" + type;
                        popupDiv.role = "alert";
                        popupDiv.innerText = message;
                        popupContainer.appendChild(popupDiv);
                        setTimeout(function () {
                            popupDiv.remove();
                        }, 3000);
                    }

                    // Debounce search input to limit the number of postbacks
                    let debounceTimer;
                    document.getElementById('<%= txtSearch.ClientID %>').addEventListener('input', function () {
                        clearTimeout(debounceTimer);
                        debounceTimer = setTimeout(function () {
                            __doPostBack('<%= txtSearch.UniqueID %>', '');
                        }, 500); // Adjust the delay as needed
                    });
                </script>

                <div class="row">
                    <div class="col">
                        <hr>
                    </div>
                </div>
                <asp:Label ID="lblMessage" runat="server" CssClass="text-success" />


                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Book ID" Visible="false" />
                        <asp:BoundField DataField="Author" HeaderText="Author" />
                        <asp:BoundField DataField="Title" HeaderText="Book Title" />
                        <asp:BoundField DataField="Genre" HeaderText="Genre" />
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                        <asp:BoundField DataField="Book_Status" HeaderText="Status" />

                        <asp:TemplateField HeaderText="Reserve">
                            <ItemTemplate>
                                <asp:Button ID="btnReserve" runat="server" Text="Reserve" CommandName="ReserveBook" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-info" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
