<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="AliffOuimetHypesScheduler.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelRemoveError" runat="server" ForeColor="Red" style="z-index: 1; left: 220px; top: 384px; position: absolute" Text="An event is scheduled by this user" Visible="False"></asp:Label>
        </div>
        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 696px; top: 170px; position: absolute" Text="Re-Enter Password"></asp:Label>
        <asp:ListBox ID="ListBoxUsers" runat="server" style="z-index: 1; left: 41px; top: 109px; position: absolute; width: 312px; height: 262px"></asp:ListBox>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 43px; top: 79px; position: absolute" Text="Users"></asp:Label>
        <asp:Button ID="ButtonRemove" runat="server" OnClick="ButtonRemove_Click" style="z-index: 1; left: 41px; top: 380px; position: absolute" Text="Remove User" />
        <asp:TextBox ID="TextBoxEmail" runat="server" style="z-index: 1; left: 534px; top: 134px; position: absolute; right: 691px"></asp:TextBox>
        <asp:TextBox ID="TextBoxPass1" runat="server" style="z-index: 1; left: 535px; top: 199px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="TextBoxPass2" runat="server" style="z-index: 1; left: 695px; top: 199px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="TextBoxName" runat="server" style="z-index: 1; left: 696px; top: 133px; position: absolute"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 538px; top: 102px; position: absolute" Text="New Email"></asp:Label>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 700px; top: 102px; position: absolute" Text="First Name"></asp:Label>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 536px; top: 168px; position: absolute" Text="Password"></asp:Label>
        <asp:Label ID="LabelError" runat="server" ForeColor="Red" style="z-index: 1; left: 699px; top: 261px; position: absolute" Text="Error" Visible="False"></asp:Label>
        <asp:Label ID="TestLabel" runat="server" style="z-index: 1; left: 396px; top: 340px; position: absolute" Text="Label" Visible="False"></asp:Label>
        <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" style="z-index: 1; left: 536px; top: 260px; position: absolute" Text="Add User" />
    </form>
</body>
</html>
