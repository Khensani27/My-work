<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="FinalYearWeb.ThankYou" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank you</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .container {
            text-align: center;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.1);
        }
        .label-style {
            font-size: 24px;
            color: #333;
            margin-bottom: 10px;
        }
        .button-style {
            padding: 10px 20px;
            font-size: 16px;
            background-color: #2fd452;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s;
        }
        .button-style:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label runat="server" Text="Thank you for placing your order."
                CssClass="label-style" />
            <br />
            <asp:Label runat="server" Text="It is currently being processed."
                CssClass="label-style" />
            <br />
            <br/>
            <asp:Button runat="server" Text="Track Order" CssClass="button-style" OnClick="Payment_Clicked" />
        </div>
    </form>
</body>
</html>
