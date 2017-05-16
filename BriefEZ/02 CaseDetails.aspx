<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="02 CaseDetails.aspx.vb" Inherits="BriefEZ._02_CaseDetails" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Button1 {
            height: 40px;
            width: 160px;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="CaseDetailsForm" runat="server">
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
        <asp:Menu ID="BriefMenu" runat="server" Font-Names="Lucida Sans" Font-Size="Medium" ForeColor="#333333" Orientation="Horizontal" RenderingMode="Table" BackColor="#33CCFF" BorderColor="#333333" BorderStyle="Solid" BorderWidth="2px" Height="35px" Width="1417px">
            <DynamicSelectedStyle BackColor="White" />
            <Items>
                <asp:MenuItem Text="Select State" Value="Select State"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        <asp:Label ID="lblCaseNumber" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Case Number:"></asp:Label>
        <br />
        <asp:TextBox ID="txtCaseNumber" runat="server" Height="24px" Width="450px" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblDistrict" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="District"></asp:Label>
        <br />
        <asp:TextBox ID="txtDistrict" runat="server" Height="24px" Width="450px" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblCourt" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Court"></asp:Label>
        <br />
        <asp:TextBox ID="txtCourt" runat="server" Height="24px" Width="450px" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblCounty" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="County"></asp:Label>
        <br />
        <asp:TextBox ID="txtCounty" runat="server" Height="24px" Width="450px" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btnBack" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Back" Width="160px" CausesValidation="False" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnContinue" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Continue" Width="160px" CausesValidation="False" />
        </form>
</body>
</html>
