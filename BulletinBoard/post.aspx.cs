using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDatabase;

namespace BulletinBoard
{
    public partial class post : System.Web.UI.Page
    {
        private SQLDatabase.DatabaseRow r = new DatabaseRow();
        private string StoredBoardID = "StoredBoardID at start";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedinID"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            //Checking which user is logged in and posting it.
            SQLDatabase.DatabaseTable posts_table = new SQLDatabase.DatabaseTable("Posts");   // Load the Posts table  

            posts_table.Bind(DataList2);

            SQLDatabase.DatabaseTable loggedintable = new SQLDatabase.DatabaseTable("Users", "SELECT Username from Users WHERE ID = " + Session["LoggedinID"]);  // get username from Users db where id is the loggedinid passed in session

            string Username = loggedintable.GetRow(0)["Username"]; //get username from loggedintable where userid == LoggedinID

            Label2.Text = Session["LastLoginDay"].ToString();
            Label1.Text = Username;

            //bringing in Session["Boards"]
            SQLDatabase.DatabaseRow r = (SQLDatabase.DatabaseRow)Session["Boards"]; // Create r and give it the same info as the row matching Boards
            string StoredBoardID = r["ID"].ToString(); // Extract the column ID from the row stored in Session["Boards"] and store it in string StoredBoardID

            //checking it, temporary
            Label3.Text = StoredBoardID;
            if (r["ID"].ToString() != null)
            {
                Label4.Text = r["ID"].ToString();
            }
            else Label4.Text = "null";


        }

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataListItem i = e.Item;

                System.Data.DataRowView r = ((System.Data.DataRowView)e.Item.DataItem); // 'r' represents the next row in the table that has been passed here via the 'bind' function.
                if (r["BoardID"].ToString() == StoredBoardID)
                {

                    // Find the label controls that are associated with this data item.

                    Label PostsText_LBL = (Label)e.Item.FindControl("PostsText_Label");       // Find the text Label.
                    Label PostsCreator_LBL = (Label)e.Item.FindControl("PostsCreatorID_Label"); // Find the creator ID Label.
                                                                                                //Label PostsBoardID_LBL = (Label)e.Item.FindControl("PostsBoardID_Label"); // Find the board ID Label.
                    Label PostsCreatorName_LBL = (Label)e.Item.FindControl("PostCreatorName_Label"); // Find the creator ID Label.
                    Label DateCreated_LBL = (Label)e.Item.FindControl("Day_Label"); // Find the date created Label.
                    Label TimeCreated_LBL = (Label)e.Item.FindControl("Time_Label"); // Find the date created Label.

                    SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users", "SELECT Username from Users WHERE ID = " + r["CreatorID"].ToString());
                    string Username = users_table.GetRow(0)["Username"];

                    PostsText_LBL.Text = r["Text"].ToString();           // Topic name.
                                                                         //PostsCreator_LBL.Text = r["CreatorID"].ToString();     // Creator ID number.
                    PostsCreatorName_LBL.Text = Username;     // Creator ID number.
                                                              //PostsBoardID_LBL.Text = r["BoardID"].ToString();     // Board ID number.
                    DateCreated_LBL.Text = r["DateCreated"].ToString();     // date created.
                    TimeCreated_LBL.Text = r["TimeCreated"].ToString();     // Time created

                }

            }
        }

        protected void CreatePostButton_Click(object sender, EventArgs e)
        {
            {
                SQLDatabase.DatabaseTable posts_table = new SQLDatabase.DatabaseTable("Posts");   // Need to load the table we're going to insert into.

                SQLDatabase.DatabaseRow new_row = posts_table.NewRow();    // Create a new based on the format of the rows in this table.

                string new_id = posts_table.GetNextID().ToString();    // Use this to create a new ID number for this module. This new ID follows on from the last row's ID number.
                SQLDatabase.DatabaseTable loggedintable = new SQLDatabase.DatabaseTable("Users", "SELECT Username from Users WHERE ID = " + Session["LoggedinID"]);  // get username from userdb using sessionid

                //get username from loggedintable where userid == LoggedinID
                string creatorname = loggedintable.GetRow(0)["Username"];
                string str = "";
                if (Session["LoggedinID"] != null)
                {
                    str = Session["LoggedinID"].ToString();
                }
                int creatorid = Convert.ToInt32(str);
                string boardnum = r["ID"].ToString();
                int boardid = int.Parse(boardnum);
                string creationdate = DateTime.Today.ToString("ddd dd MMM yyyy");
                string creationtime = DateTime.Now.ToString("HH:mm");

                new_row["ID"] = new_id;                                 // Add some data to the row (using the columns names in the table).
                new_row["Text"] = CreatePostTextBox.Text.ToString();            // post contents.
                new_row["CreatorID"] = creatorid.ToString();
                new_row["BoardID"] = boardid.ToString();
                new_row["DateCreated"] = creationdate;
                new_row["TimeCreated"] = creationtime;

                posts_table.Insert(new_row);                           // Execute the insert - add this new row into the database.
            }

        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/index.aspx");
        }
    }
}
