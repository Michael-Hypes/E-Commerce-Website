<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="AliffOuimetHypesScheduler.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:DropDownList ID="sTime" runat="server" style="z-index: 1; left: 782px; top: 135px; position: absolute; right: 565px" AutoPostBack="True" OnSelectedIndexChanged="sTime_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="eTime" runat="server" style="z-index: 1; left: 923px; top: 132px; position: absolute" AutoPostBack="True">
        </asp:DropDownList>
        <asp:DropDownList ID="Room" runat="server" style="z-index: 1; left: 611px; top: 134px; position: absolute" OnSelectedIndexChanged="Room_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <asp:DropDownList ID="Building" runat="server" style="z-index: 1; left: 354px; top: 136px; position: absolute; " AutoPostBack="True" OnSelectedIndexChanged="Building_SelectedIndexChanged" OnDataBound="Building_DataBound">
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 45px; top: 341px; position: absolute; width: 185px;" Text="Events Scheduled for:"></asp:Label>
        <asp:Calendar ID="calendar" runat="server" style="z-index: 1; left: 43px; top: 133px; position: absolute; height: 188px; width: 259px" SelectedDate="02/10/2020 12:48:04" OnSelectionChanged="calendar_SelectionChanged"></asp:Calendar>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Label ID="TestLabel" runat="server" style="z-index: 1; left: 354px; top: 165px; position: absolute" Text="Description"></asp:Label>
        <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" style="z-index: 1; left: 355px; top: 290px; position: absolute" Text="Create Event" />
        <asp:Label ID="LabelDate" runat="server" style="z-index: 1; left: 189px; top: 341px; position: absolute" Text="Label"></asp:Label>
        <asp:ListBox ID="ListBoxEvents" runat="server" style="z-index: 1; left: 41px; top: 380px; position: absolute; width: 858px" TabIndex="4"></asp:ListBox>
        <asp:TextBox ID="TextBoxDes" runat="server" style="z-index: 1; left: 356px; top: 199px; position: absolute"></asp:TextBox>
        <asp:Button ID="ButtonRemove" runat="server" OnClick="ButtonRemove_Click" style="z-index: 1; left: 46px; top: 470px; position: absolute" Text="Remove Event" />
        <asp:Label ID="TestLabelJR" runat="server" style="z-index: 1; left: 197px; top: 473px; position: absolute" Text="Label" Visible="False"></asp:Label>
        <asp:Button ID="ButtonAddNewUser" runat="server" OnClick="ButtonAddNewUser_Click" style="z-index: 1; left: 572px; top: 293px; position: absolute" Text="Users" />
        <asp:Button ID="ButtonLocations" runat="server" OnClick="ButtonLocations_Click" style="z-index: 1; top: 293px; position: absolute; left: 635px" Text="Locations" />
        <asp:Label ID="LabelDes" runat="server" ForeColor="Red" style="z-index: 1; left: 506px; top: 200px; position: absolute" Text="Please enter a description for your event" Visible="False"></asp:Label>
    </form>
</body>
</html>
