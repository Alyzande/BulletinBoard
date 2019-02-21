using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedinID"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users");   // Need to load the table we're going to display...

            users_table.Bind(DataList3);


        }
        protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataListItem i = e.Item;
                System.Data.DataRowView r = ((System.Data.DataRowView)e.Item.DataItem); // 'r' represents the next row in the table that has been passed here via the 'bind' function.

                // Find the label controls that are associated with this data item.

                Label UsersID_LBL = (Label)e.Item.FindControl("UsersID_Label");       // Find the ID Label.
                Label Usersname_LBL = (Label)e.Item.FindControl("Usersname_Label"); // Find the real name Label.
                Label UsersUsername_LBL = (Label)e.Item.FindControl("UsersUsername_Label"); // Find the username Label.
                Label UsersPassword_LBL = (Label)e.Item.FindControl("UsersPassword_Label"); // Find the password Label.
                Label UsersUsertype_LBL = (Label)e.Item.FindControl("UsersUserType_Label"); // Find the password Label.



                UsersID_LBL.Text = r["ID"].ToString();           // ID
                Usersname_LBL.Text = r["Name"].ToString();     // real name
                UsersUsername_LBL.Text = r["Username"].ToString();     // username
                UsersPassword_LBL.Text = r["Password"].ToString();     // username
                UsersUsertype_LBL.Text = r["UserType"].ToString();     // user type



                /* Button ViewButton = (Button)e.Item.FindControl("ViewButton");   // Find the button in this row.
                 ViewButton.CommandArgument = i.ItemIndex.ToString();    // Allocate the row number to the 'command argument' property of the button, so we can identify which button was pressed later.
                 ViewButton.CommandName = "View"; */
            }
        }

        protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "View")    // ViewButton clicked - but which one?
            {
                // Find the index of the button - which indicates which row...

                int index = int.Parse((string)e.CommandArgument);  // The 'Command Argument' is a string, so turn it into an integer...

                SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users");   // Need to load the table again, to extract the row in which the button was clicked.

                SQLDatabase.DatabaseRow row = users_table.GetRow(index);   // Get the row from the table.

                Session["ID"] = row;    // Store this on the Session, so we can access this module in the other page. 

                Response.Redirect("#"); // Now to go the other page to view the module information...
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //change own username
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //your password displayed
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //View Password of user
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //change password of user
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //delete user
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/index.aspx");
        }
    }
}