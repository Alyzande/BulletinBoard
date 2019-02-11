<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="BulletinBoard.manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>User Management</h1>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/index.aspx">Index</asp:HyperLink>
            &nbsp;&gt;&gt; Management
            <br />
            If user has logged in: 
            <asp:Label ID="Label1" runat="server" Text="User's Name Displayed here"></asp:Label>
            <br />
            Else (user is not logged in)
                user is redirected to
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/index.aspx">Index</asp:HyperLink>
            <br />
            <asp:Button ID="Logout" runat="server" Text="Log Out" OnClick="Logout_Click" />
            <br />
            <br />
            <h2>Account Management</h2>
            <h3>Your Details</h3>
            Your Username: <asp:Label ID="Label3" runat="server" Text="Displayed Here"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" Width="400px"></asp:TextBox>
                <asp:Button ID="Button4" runat="server" Text="Change Username" Width="200px" OnClick="Button4_Click" />
            <br />
            Your Password:
            <asp:Label ID="Label4" runat="server" Text="Displayed Here"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Width="400px"></asp:TextBox>
                <asp:Button ID="Button5" runat="server" Text="Change Password" Width="200px" OnClick="Button5_Click" />
            <br />
       
<asp:Label ID="Label2" runat="server" Text="List of Posts Ever Made"></asp:Label>
            <br />
            <br />
            <hr />
            <h3>Only Display is user = admin</h3>
            <h3>User Admin</h3>
            Username select<br />
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" Text="View Password" Width="200px" OnClick="Button1_Click" />
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Change Password" Width="200px" />
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button3" runat="server" OnClick="Button2_Click" Text="Delete User" Width="200px" />
                

            <asp:DataList ID="DataList3" runat="server" OnItemDataBound="DataList3_ItemDataBound" OnItemCommand="DataList3_ItemCommand">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td style="width: 80px; background-color: #f0f0f0;">
                                <asp:Label ID="UsersID_Label" runat="server" Text="User ID"></asp:Label>
                            </td>

                            <td style="width: 300px; background-color: #f0f0f0;"><asp:Label ID="Usersname_Label" runat="server" Text="Users Name"></asp:Label>
                            </td>

                             <td style="width: 300px; background-color: #f0f0f0;"> <asp:Label ID="UsersUsername_Label" runat="server" Text="Users Username"></asp:Label>
                            </td>
                          
                            <td style="width: 200px; background-color: #f0f0f0;"> <asp:Label ID="UsersPassword_Label" runat="server" Text="Users Password"></asp:Label>
                            </td>

                               <td style="width: 80px; background-color: #f0f0f0;"> <asp:Label ID="UsersUserType_Label" runat="server" Text="Users Type"></asp:Label>
                            </td>

                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
                

        </div>
    </form>
</body>
</html>
