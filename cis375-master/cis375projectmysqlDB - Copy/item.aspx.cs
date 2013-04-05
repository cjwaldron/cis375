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
    public partial class item : System.Web.UI.Page
    {
        int userid = pageSecurity.getUserID();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool security=false;
            security = pageSecurity.getLogin();
            if (security == false)
                Server.Transfer("default.aspx");
            userid = pageSecurity.getUserID();
            string connString = "Server=localhost;Port=3306;Database=cis375project;Uid=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT * FROM item WHERE itemid = ");
            qstring.Append(userid);
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string number = reader[0].ToString();
            conn.Close();
        }
    }
}