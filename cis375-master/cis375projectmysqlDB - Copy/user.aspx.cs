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
    public partial class user : System.Web.UI.Page
    {
       
        string retrievedData;
        int userId;
        protected void searchBT_Click(object sender, EventArgs e)
        {
            Server.Transfer("search.aspx");
        }

        protected void listitemBT_Click(object sender, EventArgs e)
        {
            Server.Transfer("listitem.aspx");
        }

        public string sellerNumItemsListed(int user_id)
        {
             string connString = "Server=localhost;Port=3306;Database=cis375project;Uid=root;password=root;";
             MySqlConnection conn = new MySqlConnection(connString);
             MySqlCommand command = conn.CreateCommand();     
             StringBuilder qstring = new StringBuilder("SELECT COUNT(itemid) FROM item WHERE iduser = ");
             qstring.Append(user_id);
             string sqlquery = qstring.ToString();
             command.CommandText = sqlquery;
             conn.Open();
             MySqlDataReader reader = command.ExecuteReader();
             reader.Read();
             string number = reader[0].ToString();
             conn.Close();
             return number;
       }
        public string sellerUnsoldItemCount(int user_id)
        {
            string connString = "Server=localhost;Port=3306;Database=cis375project;Uid=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT COUNT(unsold.itemid) FROM unsold,item,user WHERE user.iduser = ");
            qstring.Append(user_id);
            qstring.Append(" AND user.iduser = item.iduser AND item.itemid = unsold.itemid");
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string number = reader[0].ToString();
            conn.Close();
            return number;
        }
        public string sellerListedItemCount(int user_id)
        {
            string connString = "Server=localhost;Port=3306;Database=cis375project;Uid=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT COUNT(listed.itemid) FROM listed,item,user WHERE user.iduser = ");
            qstring.Append(user_id);
            qstring.Append(" AND user.iduser = item.iduser AND item.itemid = listed.itemid");
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string number = reader[0].ToString();
            conn.Close();
            return number;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            bool security = false;
            security = pageSecurity.getLogin();
            if (security == false)
                Server.Transfer("default.aspx");
            else
            {
                userId = pageSecurity.getUserID();
                retrievedData = sellerNumItemsListed(userId);
                TextBox1.Text = retrievedData;
                retrievedData = sellerUnsoldItemCount(userId);
                TextBox2.Text = retrievedData;
                retrievedData = sellerListedItemCount(userId);
                TextBox3.Text = retrievedData;
            }
        }
       

        
        



        
        
        


    }
}