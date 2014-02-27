<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="LeagueStatTracker.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="SummonerField" runat="server"></asp:TextBox>
        <asp:Button ID="SubmitName" runat="server" Text="Submit" OnClick="SubmitName_Click" />
        <asp:DropDownList ID="ServerSelect" runat="server">
            <asp:ListItem Value="na" Text="NA" Selected="True" />
            <asp:ListItem Value="euw" Text="EUW"/>
            <asp:ListItem Value="eune" Text="EUNE"/>
            <asp:ListItem Value="br" Text="BR"/>
            <asp:ListItem Value="lan" Text="LAN"/>
            <asp:ListItem Value="las" Text="LAS"/>
        </asp:DropDownList>
    </div>
        <table class="auto-style1">
            <tr>
                <td>Summoner Name</td>
                
        </table>
    <div>
        <asp:TextBox ID="ResultsField" runat="server" Height="117px" Width="347px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
