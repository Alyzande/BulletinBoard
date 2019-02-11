<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BulletinBoard.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Index page</h1>

          
            <h2>Register here</h2>
         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/register.aspx">Register</asp:HyperLink>   
            <br />
           <h2>Login Here</h2>
                <br />
            username
                <asp:TextBox ID="UsernameTextbox" runat="server"></asp:TextBox>
                TRY: jeff1, marvin1<br />
            password
                <asp:TextBox ID="PasswordTextbox" runat="server"></asp:TextBox>
                TRY: 123456, password<br />
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
                <br />
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
                <br />
              <hr />

            <br />

            go button
                directs to boards to look at boards
             <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/board.aspx">Logged in, see boards</asp:HyperLink>
            <br />
            <h2>Admin Only</h2>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/manage.aspx">Manage</asp:HyperLink>

        </div>
    </form>
</body>
</html>