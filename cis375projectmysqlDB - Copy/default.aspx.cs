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
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        string username = "null", password = "null";
        int userid = 0;
        
        public bool login(string username, string password)
        {
            string dbusername, dbpassword;
            string connString = "Server=localhost;Port=3306;Database=cis375project;Uid=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT * FROM user WHERE username = '");
            qstring.Append(username);
            qstring.Append("'");
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
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
            if (dbusername == username && dbpassword == password)
                return true;
            else
            {
                conn.Close();
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

                pageSecurity.setLogin(verifyLogin);
                Server.Transfer("user.aspx");
            }
            else
                Server.Transfer("loginerror.aspx");
        }
    }
}