<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="08 Statements.aspx.vb" Inherits="BriefEZ.Statements" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="StatementsForm" runat="server">
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
                <asp:MenuItem Text="Statutes" Value="Statutes"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        <asp:Label ID="lblStatementOfTheCase" runat="server" BackColor="#33CCFF" BorderColor="#333333" BorderStyle="Solid" BorderWidth="2px" Font-Names="Lucida Bright" Height="40px" style="margin-left: 0px" Text="Statement Of The Case" Width="120px"></asp:Label>
&nbsp;<asp:Label ID="lblStatementOfTheFacts" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" Font-Names="Lucida Bright" ForeColor="White" Height="40px" style="margin-left: 0px" Text="Statement Of The Facts" Width="120px"></asp:Label>
&nbsp;<asp:Label ID="lblStatementOfTheGrounds" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" Font-Names="Lucida Bright" ForeColor="White" Height="40px" style="margin-left: 0px" Text="Statement Of The Grounds" Width="120px"></asp:Label>
&nbsp;<asp:Label ID="lblStandardOfReview" runat="server" BackColor="#333333" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="2px" Font-Names="Lucida Bright" ForeColor="White" Height="40px" style="margin-left: 0px" Text="Standard Of Review" Width="120px"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" BackColor="#CCCCCC" Height="500px" TextMode="MultiLine" Width="850px"></asp:TextBox>
        <asp:Button ID="btnInsertSymbol" runat="server" BackColor="#33CCFF" BorderColor="Silver" BorderStyle="Outset" Font-Bold="True" Font-Names="Lucida Bright" Font-Size="X-Large" ForeColor="White" Height="40px" Text="§" Width="58px" />
    
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
