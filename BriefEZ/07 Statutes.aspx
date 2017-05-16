<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="07 Statutes.aspx.vb" Inherits="BriefEZ.Statutes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="StatutesForm" runat="server">
    <div id="Header" style="background-color: #999999">
    
        <br />
        <asp:Label ID="lblBrief" runat="server" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="XX-Large" ForeColor="#33CCFF" Text="Brief"></asp:Label>
        <asp:Label ID="lblEZ" runat="server" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="XX-Large" ForeColor="#333333" Text="EZ"></asp:Label>
        <br />
        <asp:Label ID="lblSlogan" runat="server" Font-Names="Lucida Bright" ForeColor="Black" Text="&quot;You can breathe easy with BriefEZ.&quot;"></asp:Label>
        <br />
        <br />
        <asp:Menu ID="NavigationMenu" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="True" ForeColor="#33CCFF" Orientation="Horizontal" BorderColor="#333333" Font-Bold="True" RenderingMode="Table" Width="1200px">
            <DynamicHoverStyle ForeColor="#333333" />
            <Items>
                <asp:MenuItem Text="About" Value="About"></asp:MenuItem>
                <asp:MenuItem Text="Home" Value="Home"></asp:MenuItem>
                <asp:MenuItem Text="Feedback" Value="Feedback"></asp:MenuItem>
            </Items>
        </asp:Menu>
    
    </div>
        <asp:Menu ID="BriefMenu" runat="server" Font-Names="Lucida Sans" Font-Size="Medium" ForeColor="#333333" Orientation="Horizontal" RenderingMode="Table" BorderStyle="Solid" Font-Underline="False" Height="35px" Width="1200px" BackColor="#33CCFF" BorderColor="#333333" BorderWidth="2px">
            <DynamicHoverStyle BackColor="#333333" />
            <DynamicSelectedStyle BackColor="White" />
            <Items>
                <asp:MenuItem Text="Select State" Value="Feedback"></asp:MenuItem>
                <asp:MenuItem Text="Case Details" Value="Case Details"></asp:MenuItem>
                <asp:MenuItem Text="Personal Details" Value="Personal Details"></asp:MenuItem>
                <asp:MenuItem Text="Appellant/Appellee" Value="Appellant/Appellee"></asp:MenuItem>
                <asp:MenuItem Text="Options" Value="Options"></asp:MenuItem>
                <asp:MenuItem Text="Cases" Value="Cases"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        <asp:Label ID="lblStatutes" runat="server" Font-Names="Lucida Bright" Font-Size="XX-Large" Font-Underline="False" Text="Statutes"></asp:Label>
        <br />
        <asp:Label ID="lblStat1" runat="server" BackColor="#33CCFF" BorderColor="#333333" BorderStyle="Solid" BorderWidth="2px" Font-Names="Lucida Bright" Height="40px" style="font-size: xx-large" Text="1" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblStat2" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblStat3" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblStat4" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblStat5" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblStat6" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblStat7" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblStat8" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblStat9" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblStat10" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Width="80px"></asp:Label>
        <br />
        <asp:TextBox ID="txtCase" runat="server" Height="24px" Width="800px" Font-Names="Lucida Bright" BackColor="#CCCCCC" Font-Size="Medium"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnInsertSymbol" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="§" Width="58px" />
    
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Button ID="btnCancel" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Cancel" Width="160px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnContinue" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Continue" Width="160px" />
    
        <br />
    </form>
</body>
</html>
