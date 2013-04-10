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
        protected void Page_Load(object sender, EventArgs e)
        {
            bool security = false;
            security = pageSecurity.getLogin();
            if (security == false)
                Server.Transfer("default.aspx");
        }
        
        protected void searchBT_Click(object sender, EventArgs e)
        {
            Server.Transfer("search.aspx");
        }

        protected void listitemBT_Click(object sender, EventArgs e)
        {
            Server.Transfer("listitem.aspx");
        }


        protected void sellersInfoBT_Click(object sender, EventArgs e)
        {
            Panel4.Visible = false;
            Panel2.Visible = true;
            
            userId = pageSecurity.getUserID();
            retrievedData = sellerNumItemsListed(userId);
            TextBox1.Text = retrievedData;
            retrievedData = sellerUnsoldItemCount(userId);
            TextBox2.Text = retrievedData;
            retrievedData = sellerListedItemCount(userId);
            TextBox3.Text = retrievedData;
            retrievedData = sellersSalesTotal(userId);
            TextBox4.Text = retrievedData;
        }
        protected void buyersInfoBT_Click(object sender, EventArgs e)
                {
                    userId = pageSecurity.getUserID();
                    Panel4.Visible = true;
                    Panel2.Visible = false;
                    retrievedData = totalAmountSpent(userId);
                    TextBox5.Text = retrievedData;
                    retrievedData = totalNumItemsPurch(userId);
                    TextBox6.Text = retrievedData;
                    retrievedData = totalNumOfItemsBiddingOn(userId);
                    TextBox7.Text = retrievedData;
                    retrievedData = totalNumOfWinning(userId);
                    TextBox8.Text = retrievedData;
                    retrievedData = totalAmountOfWinning(userId);
                    TextBox9.Text = retrievedData;
                }

        public string sellerNumItemsListed(int user_id)
        {
            string connString1 = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
             MySqlConnection conn = new MySqlConnection(connString1);
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
            string connString2 = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
            MySqlConnection conn = new MySqlConnection(connString2);
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
            string connString3 = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
            MySqlConnection conn = new MySqlConnection(connString3);
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
        public string sellersSalesTotal(int user_id)
        {
            string connString5 = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
            MySqlConnection conn = new MySqlConnection(connString5);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT SUM(sold.price) FROM sold,item WHERE item.iduser = ");
            qstring.Append(user_id);
            qstring.Append(" AND item.itemid = sold.itemid");
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string number = reader[0].ToString();
            conn.Close();
            return number;
        }

        public string totalAmountSpent(int user_id)
        {

            string connString6 = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
            MySqlConnection conn = new MySqlConnection(connString6);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT SUM(item.price) FROM item,listed,sold WHERE ((item.iduser = "); 
            qstring.Append(user_id);
            qstring.Append(" AND item.itemid=sold.itemid) OR (item.itemid=listed.itemid AND listed.highestbidder = ");
            qstring.Append(user_id);
            qstring.Append("))");
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string number = reader[0].ToString();
            conn.Close();
            return number;
        }

        public string totalNumItemsPurch(int user_id)
        {
           string connString7 = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
            MySqlConnection conn = new MySqlConnection(connString7);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT COUNT(item.itemid) FROM item, sold WHERE (item.iduser = "); 
            qstring.Append(user_id);
            qstring.Append(" AND item.itemid=sold.itemid )");
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string number = reader[0].ToString();
            conn.Close();
            return number; 
        }

        public string totalNumOfItemsBiddingOn(int user_id)
        {
            string connString4 = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
            MySqlConnection conn = new MySqlConnection(connString4);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT COUNT(item.itemid) FROM item,listed,bids WHERE (item.iduser = ");
            qstring.Append(user_id);
            qstring.Append(" AND item.itemid=listed.itemid AND item.itemid=bids.itemid)");
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string number = reader[0].ToString();
            conn.Close();
            return number;
        }

        public string totalNumOfWinning(int user_id)
        {
            string connString4 = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
            MySqlConnection conn = new MySqlConnection(connString4);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT DISTINCT COUNT(listed.highestbidder) FROM listed WHERE listed.highestbidder = ");
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

        public string totalAmountOfWinning(int user_id)
        {
            string connString4 = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
            MySqlConnection conn = new MySqlConnection(connString4);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT SUM(item.price) FROM item,listed WHERE (listed.itemid=item.itemid AND listed.highestbidder = ");
            qstring.Append(user_id);
            qstring.Append(")");
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string number = reader[0].ToString();
            conn.Close();
            return number;




        }

        
        



        
        
        


    }
}