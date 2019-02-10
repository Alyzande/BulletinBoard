using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLDatabase.DatabaseTable posts_table = new SQLDatabase.DatabaseTable("Posts");   // Need to load the table we're going to display...

            posts_table.Bind(DataList2);
        }

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataListItem i = e.Item;
                System.Data.DataRowView r = ((System.Data.DataRowView)e.Item.DataItem); // 'r' represents the next row in the table that has been passed here via the 'bind' function.

                // Find the label controls that are associated with this data item.

                Label PostsText_LBL = (Label)e.Item.FindControl("PostsText_Label");       // Find the text Label.
                Label PostsCreator_LBL = (Label)e.Item.FindControl("PostsCreatorID_Label"); // Find the creator ID Label.


                PostsText_LBL.Text = r["Text"].ToString();           // Topic name.
                PostsCreator_LBL.Text = r["CreatorID"].ToString();     // Creator ID number.


            }
        }

        protected void CreatePostButton_Click(object sender, EventArgs e)
        {
            {
                SQLDatabase.DatabaseTable posts_table = new SQLDatabase.DatabaseTable("Posts");   // Need to load the table we're going to insert into.

                SQLDatabase.DatabaseRow new_row = posts_table.NewRow();    // Create a new based on the format of the rows in this table.

                string new_id = posts_table.GetNextID().ToString();    // Use this to create a new ID number for this module. This new ID follows on from the last row's ID number.
                string creatorname = "1";
                int creatorid = int.Parse(creatorname);
                string boardnum = "1";
                int boardid = int.Parse(boardnum);
                string creationdate = "";
                string creationtime = "";

                new_row["ID"] = new_id;                                 // Add some data to the row (using the columns names in the table).
                new_row["Text"] = CreatePostTextBox.Text.ToString();            // post contents.
                new_row["CreatorID"] = creatorid.ToString();
                new_row["BoardID"] = boardid.ToString();
                new_row["DateCreated"] = creationdate;
                new_row["TimeCreated"] = creationtime;

                posts_table.Insert(new_row);                           // Execute the insert - add this new row into the database.
            }

        }
    }
}
