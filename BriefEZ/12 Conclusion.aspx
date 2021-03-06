﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="12 Conclusion.aspx.vb" Inherits="BriefEZ._12_Conclusion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="background-color: #999999">
    
        <br />
        <asp:Label ID="lblBrief" runat="server" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="XX-Large" ForeColor="#33CCFF" Text="Brief"></asp:Label>
        <asp:Label ID="lblEZ" runat="server" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="XX-Large" ForeColor="#333333" Text="EZ"></asp:Label>
        <br />
        <asp:Label ID="lblSlogan" runat="server" Font-Names="Lucida Bright" ForeColor="Black" Text="&quot;You can breathe easy with BriefEZ.&quot;"></asp:Label>
        <br />
        <br />
        <asp:Menu ID="NavigationMenu" runat="server" Font-Names="Lucida Bright" Font-Size="X-Large" Font-Underline="True" ForeColor="#33CCFF" Orientation="Horizontal" BorderColor="#333333" Font-Bold="True" RenderingMode="Table" Width="750px">
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
            <Items>
                <asp:MenuItem Text="Select State" Value="Feedback"></asp:MenuItem>
                <asp:MenuItem Text="Case Details" Value="Case Details"></asp:MenuItem>
                <asp:MenuItem Text="Personal Details" Value="Personal Details"></asp:MenuItem>
                <asp:MenuItem Text="Appellant/Appellee" Value="Appellant/Appellee"></asp:MenuItem>
                <asp:MenuItem Text="Options" Value="Options"></asp:MenuItem>
                <asp:MenuItem Text="Cases" Value="Cases"></asp:MenuItem>
                <asp:MenuItem Text="Statutes" Value="Statutes"></asp:MenuItem>
                <asp:MenuItem Text="Statements" Value="Statements"></asp:MenuItem>
                <asp:MenuItem Text="Issues" Value="Issues"></asp:MenuItem>
                <asp:MenuItem Text="Arguments" Value="Arguments"></asp:MenuItem>
                <asp:MenuItem Text="SubArguments" Value="SubArguments"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        <br />
        <asp:Label ID="lblConclusion" runat="server" Font-Names="Lucida Bright" Font-Size="XX-Large" Font-Underline="False" Text="Conclusion"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" BackColor="#CCCCCC" Height="500px" TextMode="MultiLine" Width="850px"></asp:TextBox>
        <asp:Button ID="btnInsertSymbol" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="§" Width="58px" />
    
        <br />
        <br />
        <br />
        <asp:Button ID="btnCancel" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Cancel" Width="160px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnContinue" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="Continue" Width="160px" />
    
    </form>
</body>
</html>
