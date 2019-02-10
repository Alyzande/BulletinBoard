<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="BulletinBoard.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <h2>Registration page!</h2>
            <p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/index.aspx">Index</asp:HyperLink>&gt;&gt; Registration</p>

            username <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            password<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Real name<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <a href="index.aspx">Return to Index</a>
            <br />
            <h4>Admin Only</h4>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/manage.aspx">Manage</asp:HyperLink>
            <br />
        </div>
    </form>
</body>
</html>
