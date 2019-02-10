<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="BulletinBoard.post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Posts</h1>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/index.aspx">Index</asp:HyperLink>
            &nbsp; &gt;&gt; <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/board.aspx">Boards</asp:HyperLink>&nbsp;&gt;&gt; Post<br />
            If user has logged in: 
            <asp:Label ID="Label1" runat="server" Text="User's Name Displayed here"></asp:Label>
            <br />
            Else (user is not logged in)
                user is redirected to
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/index.aspx">Index</asp:HyperLink>
            
            <br />
            <br />
            <h2>Boards</h2>
          <p>Choose your Topic</p>
             <asp:DataList ID="DataList2" runat="server" OnItemDataBound="DataList2_ItemDataBound" >
                <ItemTemplate>
                    <table>
                        <tr>
                            <td style="width: 600px; background-color: #f0f0f0;">
                                <asp:Label ID="PostsText_Label" runat="server" Text="PostsText"></asp:Label>
                            </td>

                            <td style="width: 200px; background-color: #f0f0f0;">
                                <asp:Label ID="PostsCreatorID_Label" runat="server" Text="PostsCreatorID"></asp:Label>
                            </td>

                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
             <br />
            <hr />
             <h2>Create A New Topic/Board</h2>

            <br />
            <asp:TextBox ID="CreatePostTextBox" runat="server" Width="400px" Height="3em">Your Post on the Topic?</asp:TextBox>
            <br />
            <asp:Button ID="CreatePostButton" runat="server" Text="Create A Post" OnClick="CreatePostButton_Click" />
            <br />
            <br />
           <hr />
            <h2>Admin Only</h2>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/manage.aspx">Manage</asp:HyperLink>
            <h2>&nbsp;</h2>
             </div>
    </form>
</body>
</html>
