<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="board.aspx.cs" Inherits="BulletinBoard.board" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Boards</h1>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/index.aspx">Index</asp:HyperLink>
            &nbsp;>> Boards
            <br />
            You are logged in as:
            <asp:Label ID="Label1" runat="server" Text="User's Name Displayed here"></asp:Label>
            <br />
            Your login date was:
            <asp:Label ID="Label2" runat="server" Text="Users login date displayed here"></asp:Label>
<br />
            <asp:Button ID="LogoutButton" runat="server" Text="Log Out" OnClick="LogoutButton_Click" />
            <br />
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/post.aspx" Font-Bold="True" Font-Size="Large">VIEW ALL POSTS</asp:HyperLink>
            <br />
            <h2>Browse Topics</h2>
            <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td style="width: 600px; background-color: #f0f0f0;">
                                <asp:Label ID="Topic_Label" runat="server" Text="topicname"></asp:Label>
                            </td>

                            <td style="width: 200px; background-color: #f0f0f0;">
                                <asp:Label ID="Creator_Label" runat="server" Text="creatorname"></asp:Label>
                            </td>

                            <td style="width: 100px; background-color: #f0f0f0;">
                                <asp:Button ID="ViewButton" Width="100%" runat="server" Text="View" />
                            </td>

                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <hr />
            <h2>Create/Add a New Board</h2>
            <asp:TextBox ID="CreateBoardTextbox" runat="server" Height="2em" Width="400px">New Board Name?</asp:TextBox>
            <br />
            <asp:Button ID="CreateBoardButton" runat="server" Text="Create Board" OnClick="CreateBoardButton_Click" />
            <br />
            <br />
          <hr />
            <h2>Admin Only</h2>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/manage.aspx">Manage</asp:HyperLink>


        </div>
    </form>
</body>
</html>
