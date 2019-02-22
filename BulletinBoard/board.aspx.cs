using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class board : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedinID"] == null)
                {
                    Response.Redirect("~/index.aspx");
                }

                SQLDatabase.DatabaseTable boards_table = new SQLDatabase.DatabaseTable("Boards");   // load boards db

                boards_table.Bind(DataList1);

                SQLDatabase.DatabaseTable loggedintable = new SQLDatabase.DatabaseTable("Users", "SELECT Username from Users WHERE ID = " + Session["LoggedinID"]);  // get username from userdb using sessionid

                //get username from loggedintable where userid == LoggedinID

                string Username = loggedintable.GetRow(0)["Username"];

                Label2.Text = Session["LastLoginDay"].ToString();
                Label1.Text = Username;
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataListItem i = e.Item;
                System.Data.DataRowView r = ((System.Data.DataRowView)e.Item.DataItem); // 'r' represents the next row in the table that has been passed here via the 'bind' function.

                // Find the label controls that are associated with this data item.

                Label Topic_LBL = (Label)e.Item.FindControl("Topic_Label");       // Find the Name Label.
                Label Creator_LBL = (Label)e.Item.FindControl("Creator_Label"); // Find the Staff ID Label.

                SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users", "SELECT Username from Users WHERE ID = " + r["CreatorID"].ToString());
                string Username = users_table.GetRow(0)["Username"];


                Topic_LBL.Text = r["Name"].ToString();           // Topic name.
                Creator_LBL.Text = Username;

                Button ViewButton = (Button)e.Item.FindControl("ViewButton");   // Find the button in this row.
                ViewButton.CommandArgument = i.ItemIndex.ToString();    // Allocate the row number to the 'command argument' property of the button, so we can identify which button was pressed later.
                ViewButton.CommandName = "View";
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "View")    // ViewButton clicked - but which one?
            {
                // Find the index of the button - which indicates which row...
             
                int index = int.Parse((string)e.CommandArgument);  // The 'Command Argument' is a string, so turn it into an integer...

                SQLDatabase.DatabaseTable boards_table = new SQLDatabase.DatabaseTable("Boards");   // Need to load the table again, to extract the row in which the button was clicked.

                SQLDatabase.DatabaseRow row = boards_table.GetRow(index);   // Get the row from the table.

                Session["Boards"] = row;
                //Session["Boards"] = row["ID"];    // Store this on the Session, so we can access this module in the other page. 

                Response.Redirect("post.aspx"); // Now to go the other page to view the module information...
            }
        }

        protected void CreateBoardButton_Click(object sender, EventArgs e)
        {
            SQLDatabase.DatabaseTable boards_table2 = new SQLDatabase.DatabaseTable("Boards");   // Need to load the table we're going to insert into.

            SQLDatabase.DatabaseRow new_row = boards_table2.NewRow();    // Create a new based on the format of the rows in this table.

            string new_id = boards_table2.GetNextID().ToString();    // Use this to create a new ID number for this module. This new ID follows on from the last row's ID number.
            string str = "";
            if (Session["LoggedinID"] != null)
            {
                str = Session["LoggedinID"].ToString();
            }

            int creatorid = int.Parse(str);

            new_row["ID"] = new_id;                                 // Add some data to the row (using the columns names in the table).
            new_row["Name"] = CreateBoardTextbox.Text.ToString();            // topic name.
            new_row["CreatorID"] = creatorid.ToString();

            boards_table2.Insert(new_row);                           // Execute the insert - add this new row into the database.
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/index.aspx");
        }
    }
}