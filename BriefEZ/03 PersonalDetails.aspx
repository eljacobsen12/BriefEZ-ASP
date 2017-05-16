<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="03 PersonalDetails.aspx.vb" Inherits="BriefEZ.PersonalDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="PersonalDetailsForm" runat="server">
    <div id="Header" style="background-color: #999999">
    
        <br />
        <asp:Label ID="lblBrief" runat="server" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="XX-Large" ForeColor="#33CCFF" Text="Brief"></asp:Label>
        <asp:Label ID="lblEZ" runat="server" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="XX-Large" ForeColor="#333333" Text="EZ"></asp:Label>
        <br />
        <asp:Label ID="lblSlogan" runat="server" Font-Names="Lucida Bright" ForeColor="Black" Text="&quot;You can breathe easy with BriefEZ.&quot;"></asp:Label>
        <br />
        <br />
        <asp:Menu ID="NavigationMenu" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="True" ForeColor="#33CCFF" Orientation="Horizontal" RenderingMode="Table" Width="1200px">
            <DynamicHoverStyle ForeColor="#333333" />
            <Items>
                <asp:MenuItem Text="About" Value="About"></asp:MenuItem>
                <asp:MenuItem Text="Home" Value="Home"></asp:MenuItem>
                <asp:MenuItem Text="Feedback" Value="Feedback"></asp:MenuItem>
            </Items>
        </asp:Menu>
    
    </div>
        <asp:Menu ID="BriefMenu" runat="server" Font-Names="Lucida Sans" Font-Size="Medium" ForeColor="#333333" Orientation="Horizontal" RenderingMode="Table" Width="1200px" BackColor="#33CCFF" BorderColor="#333333" BorderStyle="Solid" BorderWidth="2px" Height="35px">
            <DynamicHoverStyle BackColor="#333333" />
            <DynamicSelectedStyle BackColor="White" />
            <Items>
                <asp:MenuItem Text="Select State" Value="Select State"></asp:MenuItem>
                <asp:MenuItem Text="Case Details" Value="Case Details"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        <asp:Label ID="lblPersonalTitle" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Personal Title:"></asp:Label>
        <br />
        <asp:TextBox ID="txtPersonalTitle" runat="server" Height="24px" Width="450px" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblFullName" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Full Name:"></asp:Label>
        <br />
        <asp:TextBox ID="txtFullName" runat="server" Height="24px" Width="450px" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblBarNumber" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Bar Number:"></asp:Label>
        <br />
        <asp:TextBox ID="txtBarNumber" runat="server" Height="24px" Width="450px" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblFirm" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Firm:"></asp:Label>
        <br />
        <asp:TextBox ID="txtFirmName" runat="server" Height="24px" Width="450px" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblFirmAddress" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Firm Address:"></asp:Label>
        <br />
        <asp:TextBox ID="txtFirmAddress" runat="server" Height="24px" Width="450px" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btnBack" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Back" Width="160px" CausesValidation="False" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnContinue" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Continue" Width="160px" CausesValidation="False" />
    
    </form>
</body>
</html>
