<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="06 Cases.aspx.vb" Inherits="BriefEZ._6_Cases" %>

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
    <form id="CasesForm" runat="server">
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
            <DynamicSelectedStyle ForeColor="White" />
            <Items>
                <asp:MenuItem Text="Select State" Value="Feedback"></asp:MenuItem>
                <asp:MenuItem Text="Case Details" Value="Case Details"></asp:MenuItem>
                <asp:MenuItem Text="Personal Details" Value="Personal Details"></asp:MenuItem>
                <asp:MenuItem Text="Appellant/Appellee" Value="Appellant/Appellee"></asp:MenuItem>
                <asp:MenuItem Text="Options" Value="Options"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        <asp:Label ID="lblCases" runat="server" Font-Names="Lucida Bright" Font-Size="XX-Large" Font-Underline="False" Text="Cases"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="lblCase1" runat="server" BackColor="#33CCFF" BorderColor="#333333" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" Height="40px" Text="1" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblCase2" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblCase3" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Enabled="False" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Visible="False" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblCase4" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Enabled="False" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Visible="False" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblCase5" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Enabled="False" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Visible="False" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblCase6" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Enabled="False" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Visible="False" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblCase7" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Enabled="False" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Visible="False" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblCase8" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Enabled="False" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Visible="False" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblCase9" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Enabled="False" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Visible="False" Width="80px"></asp:Label>
&nbsp;<asp:Label ID="lblCase10" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style1" Enabled="False" Font-Names="Lucida Bright" ForeColor="White" Height="40px" Text="+" Visible="False" Width="80px"></asp:Label>
        <br />
        <asp:TextBox ID="txtCase" runat="server" Height="24px" Width="800px" Font-Names="Lucida Bright" BackColor="#CCCCCC" ForeColor="Black"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnInsertSymbol" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="§" Width="58px" />
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <asp:Button ID="btnCancel" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Cancel" Width="160px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnContinue" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Continue" Width="160px" />
    
        <br />
    </form>
</body>
</html>
