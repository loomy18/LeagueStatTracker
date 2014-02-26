
<html xmlns="http://www.w3.org/1999/xhtml">
  <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LeagueStatTracker.Register" %>
<head runat="server">
    <title>Sample Registration Page</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>
                </td>

            </tr>
                        <tr>
                <td>Summoner Name:</td>
                <td>
                    <asp:TextBox ID="TxtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="TxtPassword" runat="server"
                                 TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Re Password:</td>
                <td>
                    <asp:TextBox ID="TxtRePassword" runat="server"
                                 TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Register" onclick="registerClick" />
    </form>
</body>
</html>