using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users");   // Need to load the table we're going to display

            //  users_table.Bind(DataList4);

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users");
            string UserText = UsernameTextbox.Text;
            string PassText = PasswordTextbox.Text;

            //initialise some empty strings
            string userIdHolder = "";
            string UserNameHolder = "";
            string PasswordHolder = "";
            string UserTypeHolder = "";


            //iterate through the users database rows to find the user

            for (int i = 0; i < users_table.RowCount; i++)
            {
                userIdHolder = users_table.GetRow(i)["ID"];
                UserNameHolder = users_table.GetRow(i)["Username"];
                PasswordHolder = users_table.GetRow(i)["Password"];
                UserTypeHolder = users_table.GetRow(i)["UserType"];

                if (UserNameHolder == UserText)
                //if usernames match
                {
                    if (PasswordHolder == PassText)
                    //if passwords also match
                    {  //Log them in
                       //store info in session variable to be accessed later
                        Session["LoggedinID"] = userIdHolder;
                        //Can call it later with 
                        //string abc = Session["LoggedinID"].ToString();

                        //update last loggin in date

                        Session["LastLoginDay"] = DateTime.Today.ToString("ddd dd MMM yyyy");
                        Session["LastLoginTime"] = DateTime.Now.ToString("HH:mm");
                        //ErrorLabel.Text = "Logging in as " + Session["LoggedinID"].ToString() + "...";

                        //update the database with the logging in date and logging in time


                        for (int n = 0; n < users_table.RowCount; ++n)
                        {
                            SQLDatabase.DatabaseRow row = users_table.GetRow(n); //get current ID.
                            if (userIdHolder == users_table.GetRow(n)["ID"]) //if userID is the same as it's in the row
                            {

                                row["LastLoginDate"] = Session["LastLoginDay"].ToString();
                                row["LastLoginTime"] = Session["LastLoginTime"].ToString();
                                users_table.Update(row);
                            }
                        }

                        //go to boards page
                        Response.Redirect("~/board.aspx");
                    }
                    else ErrorLabel.Text = "wrong password";
                }
                else ErrorLabel.Text = "No user by that name!";
            }


        }


    }
}
