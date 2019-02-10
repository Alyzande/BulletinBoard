using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SQLDatabase.DatabaseTable user_table = new SQLDatabase.DatabaseTable("Users");   
            // Need to load the table we're going to insert into.

            SQLDatabase.DatabaseRow new_row = user_table.NewRow();    
            // Create new row based on the format of the rows in this table.

            string new_id = user_table.GetNextID().ToString();    
            // Use this to create a new ID number for this user. This new ID follows on from the last row's ID number.

             new_row["ID"] = new_id;                                 
            // Add some data to the row (using the columns names in the table).
             new_row["Name"] = TextBox3.Text.ToString();
            new_row["Username"] = TextBox1.Text.ToString();
            new_row["Password"] = TextBox2.Text.ToString();

            user_table.Insert(new_row);
            Label1.Text = "You have registered as: " + TextBox1.Text.ToString() + " password: " + TextBox2.Text.ToString() + ", " + TextBox3.Text.ToString() + "." ;
            // Execute the insert - add this new row into the database.
        }
    }
}