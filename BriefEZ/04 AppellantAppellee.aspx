<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="04 AppellantAppellee.aspx.vb" Inherits="BriefEZ.AppellantAppellee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="AppellantAppelleeForm" runat="server">
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
            </Items>
        </asp:Menu>
        <br />
        <asp:Label ID="lblAppellant" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Appellant:"></asp:Label>
        <br />
        <asp:TextBox ID="txtAppellant" runat="server" Height="24px" Width="450px" Font-Names="Lucida Bright" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblAppellee" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Appellee:"></asp:Label>
        <br />
        <asp:TextBox ID="txtAppellee" runat="server" Height="24px" Width="450px" Font-Names="Lucida Bright" Font-Size="Large" BackColor="#CCCCCC"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblBriefType" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="False" Text="Brief:"></asp:Label>
        <br />
        <asp:DropDownList ID="btnBriefTypes" runat="server" Font-Names="Lucida Bright" Height="24px" Width="450px" Font-Size="Large" BackColor="#CCCCCC">
            <asp:ListItem>DEFENDANT-APPELLEE&#39;S BRIEF</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="btnCancel" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Cancel" Width="160px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnContinue" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Continue" Width="160px" />
    
    </form>
</body>
</html>
