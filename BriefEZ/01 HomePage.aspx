<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="01 HomePage.aspx.vb" Inherits="BriefEZ.Home_Page" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="HomePageForm" runat="server">
    <div id="Header" style="background-color: #999999">
    
        <br />
        <asp:Label ID="lblBrief" runat="server" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="XX-Large" ForeColor="#33CCFF" Text="Brief"></asp:Label>
        <asp:Label ID="lblEZ" runat="server" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="XX-Large" ForeColor="#333333" Text="EZ"></asp:Label>
        <br />
        <asp:Label ID="lblSlogan" runat="server" Font-Names="Lucida Bright" ForeColor="Black" Text="&quot;You can breathe easy with BriefEZ.&quot;"></asp:Label>
        <br />
        <asp:Menu ID="NavigationMenu" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="True" ForeColor="#33CCFF" Orientation="Horizontal" RenderingMode="Table" Width="1200px">
            <Items>
                <asp:MenuItem Text="About" Value="About"></asp:MenuItem>
                <asp:MenuItem Text="Home" Value="Home"></asp:MenuItem>
                <asp:MenuItem Text="Feedback" Value="Feedback"></asp:MenuItem>
            </Items>
        </asp:Menu>
    
    </div>
        <br />
        <asp:Label ID="lblSelectState" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Select State"></asp:Label>
        <br />
        <asp:DropDownList ID="btnSelectState" runat="server" Font-Names="Lucida Bright" Font-Size="Large" Height="24px" Width="450px" BackColor="#CCCCCC">
            <asp:ListItem>VIRGINIA</asp:ListItem>
            <asp:ListItem>NORTH CAROLINA</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblSelectBrief" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Select Brief"></asp:Label>
        <asp:RadioButtonList ID="btnSelectBrief" runat="server" BorderStyle="Inset" Font-Names="Lucida Bright" Font-Size="Large" Height="24px" Width="350px" BackColor="#CCCCCC" BorderWidth="2px" CellPadding="5" CellSpacing="5" style="text-align: left">
            <asp:ListItem Selected="True">Trial Brief</asp:ListItem>
            <asp:ListItem Enabled="False">Legal Brief</asp:ListItem>
            <asp:ListItem>Appellate Brief</asp:ListItem>
            <asp:ListItem Enabled="False">Memorandum of Law</asp:ListItem>
            <asp:ListItem Enabled="False">IRAC Case Brief</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <asp:Button ID="btnCreateBrief" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Create Brief" Width="160px" CausesValidation="False" />
    </form>
</body>
</html>
