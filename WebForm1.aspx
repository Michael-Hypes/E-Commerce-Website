<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AliffOuimetHypesScheduler.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="email" runat="server" style="z-index: 1; left: 140px; top: 196px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="password" runat="server" style="z-index: 1; left: 138px; top: 257px; position: absolute" TextMode="Password"></asp:TextBox>
        <asp:Button ID="confirm" runat="server" OnClick="confirm_Click" style="z-index: 1; left: 138px; top: 289px; position: absolute" Text="Login" />
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 142px; top: 171px; position: absolute" Text="Email"></asp:Label>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 140px; top: 231px; position: absolute" Text="Password"></asp:Label>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 137px; top: 112px; position: absolute" Text="Reservation Scheduler"></asp:Label>
        <asp:Label ID="incorrect" runat="server" ForeColor="Red" style="z-index: 1; left: 107px; top: 144px; position: absolute" Text="Username or Password incorrect" Visible="False"></asp:Label>
    </form>
</body>
</html>
