<%@ Page Title="Library Stats" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="Elibrary.Stats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center my-4">e-Library Statistics:</h2>

    <!-- Row for Borrowed Books and Overdue Books -->
    <div class="row">
        <!-- Bar Chart for Books Borrowed Per Month (col-md-6) -->
        <div class="col-md-6">
            <div class="card mb-4 shadow-sm">
                <div class="card-header bg-info text-white">
                    <h5 class="card-title mb-0">Books Borrowed Per Month (Bar Chart)</h5>
                </div>
                <div class="card-body">
                    <!-- Increase canvas size -->
                    <canvas id="borrowedBooksBarChart" width="600" height="400"></canvas>
                </div>
            </div>
        </div>

        <!-- Overdue Books with Pending Fine Section (col-md-6) -->
        <div class="col-md-6">
            <div class="card mb-4 shadow-sm" style="border-radius: 10px;">
                <div class="card-header bg-danger text-white">
                    <h5 class="card-title mb-0">Overdue Books (Pending Fine)</h5>
                </div>
                <div class="card-body">
                    <asp:Literal ID="overdueBooksPendingFineLiteral" runat="server"></asp:Literal>

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-bordered">
                        <Columns>
                            <asp:BoundField DataField="UserID" HeaderText="User ID" Visible="false" />
                            <asp:BoundField DataField="BookID" HeaderText="Book ID" Visible="false" />
                            <asp:BoundField DataField="UserFirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="UserSurname" HeaderText="Surname" />
                            <asp:BoundField DataField="BookTitle" HeaderText="Book Title" />
                            <asp:BoundField DataField="Borrowed_Date" HeaderText="Borrowed Date" DataFormatString="{0:yyyy-MM-dd}" Visible="false" />
                            <asp:BoundField DataField="Returned_Date" HeaderText="Returned Date" DataFormatString="{0:yyyy-MM-dd}" Visible="false" />
                            <asp:BoundField DataField="Fine" HeaderText="Fine" DataFormatString="{0:C}" />
                            <asp:BoundField DataField="Book_Status" HeaderText="Book Status" Visible="false" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    
 <div class="row">
    <!-- Most Borrowed Books Section -->
    <div class="col-md-12">
        <div class="card shadow-sm mb-4" style="border-radius: 10px;">
            <div class="card-header bg-success text-white">
                <h5 class="card-title mb-0">Top 5 Most Borrowed Books</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-bordered">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Book Title" />
                        <asp:BoundField DataField="BorrowCount" HeaderText="Times Borrowed" />
                    </Columns>
                </asp:GridView>
                
                <!-- Add Literal to display "No data available" message -->
                <asp:Literal ID="mostBorrowedBookLiteral" runat="server" />
            </div>
        </div>
    </div>
</div>


    <!-- Hidden fields to store chart data from backend -->
    <asp:HiddenField ID="borrowedBooksBarChartData" runat="server" />

    <script type="text/javascript">
        // Get data from hidden fields populated by the backend
        const borrowedBooksData = <%= borrowedBooksBarChartData.Value %>;

        // Data for bar chart
        const barChartData = {
            labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            datasets: [{
                label: 'Books Borrowed',
                data: borrowedBooksData, // Use dynamic data from the backend
                backgroundColor: 'rgba(54, 162, 235, 0.2)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1
            }]
        };

        // Bar chart configuration
        const ctxBar = document.getElementById('borrowedBooksBarChart').getContext('2d');
        new Chart(ctxBar, {
            type: 'bar',
            data: barChartData,
            options: {
                responsive: true,
                maintainAspectRatio: false,  // Disable aspect ratio to allow custom size
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    </script>

</asp:Content>
