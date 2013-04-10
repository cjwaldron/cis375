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
using System.Net.Mail;
using System.Net.Mime;
using System.Configuration;

namespace cis375projectmysqlDB
{
    public partial class newuser : System.Web.UI.Page
    {
        string firstname, lastname, password1, password2, email1, email2,username;
        public void login(string fname, string lname, string password, string email)
        {
            StringBuilder uname = new StringBuilder();
            uname.Append(fname[0]);
            uname.Append(lname);
            username = uname.ToString();
            string connString = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
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
            insertstring.Append("','");
            insertstring.Append(password);
            insertstring.Append("')");
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
                try
                {
                    login(firstname, lastname, password1, email1);
                }
                catch
                {
                    messageTB.Visible = true;
                    messageTB.Text = "Error creating user, please try again";
                }
                //messageTB.Visible = true;
                //messageTB.Text = "User Account Created Sucessfully. Your Username is: " + username;
                //Button2.Visible = true;
                //MailMessage mailer = new MailMessage();
                //SmtpClient smtp = new SmtpClient();
                //mailer.To.Add(new MailAddress(email1));
                //mailer.Subject = "TODD Online Auction";
                //mailer.IsBodyHtml = true;
                //mailer.Priority = MailPriority.High;
                //mailer.Body = "You have successfully created your online account. Your username is: " + username + " , and your password is: " + password1;
                //smtp.Send(mailer);
                //mailer = null;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("default.aspx");
        }
    }
}