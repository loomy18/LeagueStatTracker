<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="LeagueStatTracker.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <div>
        <asp:TextBox ID="ResultsField" runat="server" Height="117px" Width="347px"></asp:TextBox>
        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ID="BasicTableHeader" />
            </asp:TableHeaderRow> 
            <asp:TableRow>
                <asp:TableCell ID="Level"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
