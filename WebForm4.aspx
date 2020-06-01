<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="AliffOuimetHypesScheduler.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div>
        </div>
        <asp:ListBox ID="ListBoxUsers" runat="server" style="z-index: 1; left: 41px; top: 109px; position: absolute; width: 312px; height: 262px"></asp:ListBox>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 43px; top: 79px; position: absolute" Text="Locations"></asp:Label>
        <asp:Button ID="ButtonRemove" runat="server" OnClick="ButtonRemove_Click" style="z-index: 1; left: 41px; top: 380px; position: absolute" Text="Remove Locations" />
        <asp:TextBox ID="TextBoxBuilding" runat="server" style="z-index: 1; left: 534px; top: 134px; position: absolute; right: 691px"></asp:TextBox>
        <asp:TextBox ID="TextBoxRoom" runat="server" MaxLength="3" style="z-index: 1; left: 696px; top: 133px; position: absolute"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 538px; top: 102px; position: absolute" Text="Building"></asp:Label>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 700px; top: 102px; position: absolute" Text="Room Number"></asp:Label>
        <asp:Label ID="LabelError" runat="server" ForeColor="Red" style="z-index: 1; left: 698px; top: 191px; position: absolute" Text="Error" Visible="False"></asp:Label>
        <asp:Label ID="TestLabel" runat="server" style="z-index: 1; left: 396px; top: 340px; position: absolute" Text="Label" Visible="False"></asp:Label>
        <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" style="z-index: 1; left: 537px; top: 185px; position: absolute" Text="Add Location" />
        <asp:Label ID="LabelRemoveError" runat="server" ForeColor="Red" style="z-index: 1; left: 220px; top: 384px; position: absolute" Text="An event is scheduled at the selected location" Visible="False"></asp:Label>
    </form>
</body>
</html>
