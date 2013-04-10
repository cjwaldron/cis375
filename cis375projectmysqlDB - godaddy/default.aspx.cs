using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using System.Text;

namespace cis375projectmysqlDB
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        string username = "null", password = "null";
        int userid = 0;
        
        public bool login(string username, string password)
        {
            string dbusername, dbpassword;
            string connString = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            string qstring = "SELECT * FROM user WHERE username = '";
            qstring = qstring + username + "' ";
            //StringBuilder qstring = new StringBuilder("SELECT * FROM user WHERE username = '");
            //qstring.Append(username);
            //qstring.Append("'");
            //string sqlquery = qstring.ToString();
            //command.CommandText = sqlquery;
            command.CommandText = qstring;
            try
            {
                conn.Open();
            }
            catch
            {
                Server.Transfer("loginerror.aspx");

            }
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            try
            {
                dbusername = reader[4].ToString();
                dbpassword = reader[5].ToString();
                userid = (int)reader[0];
                pageSecurity.setCurrentUserID(userid);
            }
            catch
            {
                Server.Transfer("loginerror.aspx");
            }
            dbusername = reader[4].ToString();
            dbpassword = reader[5].ToString();
            userid = (int)reader[0];
            conn.Close();
            if (dbusername == username && dbpassword == password)
                return true;
            else
            {
                return false;
            }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void newUsersBtn_Click(object sender, EventArgs e)
        {
            Server.Transfer("newuser.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool verifyLogin = false;
            username = usernameTB.Text;
            if(username == "")
                Server.Transfer("loginerror.aspx");
            password = passwordTB.Text;
            if (password == "")
                Server.Transfer("loginerror.aspx");
            verifyLogin = login(username,password);
            if (verifyLogin == true)
            {
                pageSecurity.setusername(username);
                pageSecurity.setLogin(verifyLogin);
                Label2.Visible=true;
                Server.Transfer("user.aspx");
            }
            else
                Server.Transfer("loginerror.aspx");
        }

    }
}