using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Text;

namespace cis375projectmysqlDB
{
    public partial class newuser : System.Web.UI.Page
    {
        string firstname, lastname, password1, password2, email1, email2;
        public void login(string fname, string lname, string password, string email)
        {
            StringBuilder uname = new StringBuilder();
            uname.Append(fname[0]);
            uname.Append(lname);
            string username = uname.ToString();
            string connString = "Server=localhost;Port=3306;Database=cis375project;Uid=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            
            StringBuilder insertstring = new StringBuilder("INSERT INTO user VALUES(0,'");
            insertstring.Append(fname);
            insertstring.Append("','");
            insertstring.Append(lname);
            insertstring.Append("','");
            insertstring.Append(email);
            insertstring.Append("','");
            insertstring.Append(username);
            insertstring.Append("',");
            insertstring.Append(password);
            insertstring.Append(")");
            string insert = insertstring.ToString();
            MySqlCommand command = new MySqlCommand("", conn);
            command.CommandText = insert;
            command.ExecuteNonQuery();
            conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            messageTB.Visible = false;
            firstname = fnameTB.Text;
            lastname = lnameTB.Text;
            password1 = passwordTB.Text;
            password2 = conpasswordTB.Text;
            email1 = emailTB.Text;
            email2 = conemailTB.Text;
            if (password1 != password2)
            {
                messageTB.Visible = true;
                messageTB.Text = "Passwords do not match";
            }
            else if (email1 != email2)
            {
                messageTB.Visible = true;
                messageTB.Text = "Emails do not match";
            }
            else
            {
                login(firstname, lastname, password1, email1);
            }
        }
    }
}