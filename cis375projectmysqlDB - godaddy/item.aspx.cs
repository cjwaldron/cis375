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
        int currentItemId = 0;
        double bid;
        int item_id = itemID.getItemId();
        string itemNum;
        string userId;
        string[] itemData = new string[9];
        string connStr = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
        MySqlCommand cmd = new MySqlCommand();


        protected void Page_Load(object sender, EventArgs e)
        {
            itemNum = item_id.ToString();
            userId = userid.ToString();
            bool security=false;
            security = pageSecurity.getLogin();
            if (security == false)
                Server.Transfer("default.aspx");
            userid = pageSecurity.getUserID();
            currentItemId = itemID.getItemId();


            string connString = "Server=50.63.244.5;Port=3306;Uid=cis375db;Pwd=ProfStiener!1;Database=cis375db;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("SELECT * FROM item WHERE itemid = ");
            qstring.Append(currentItemId);
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int a = 0; a < itemData.Length; a++)
            {
                reader.Read();
               itemData[a] = reader[a].ToString();
            }
            conn.Close();

            titleTB.Text = itemData[1];
            categoryTB.Text = itemData[2];
            priceTB.Text = itemData[6];
            descriptionTB.Text = itemData[3];
            buyitnowTB.Text = itemData[7];
            startdateTB.Text = itemData[4];
            enddateTB.Text = itemData[5];
        }

        protected void bidBT_Click(object sender, EventArgs e)
        {
            userBidBTN.Visible = true;
            userBidTB.Visible = true;
            Label2.Visible = true;
        }

        protected void userBidBTN_Click(object sender, EventArgs e)
        {
           bid = Convert.ToDouble(userBidTB.Text);
           bool placedBid = placeBid(bid, itemNum, userId);
           Server.Transfer("user.aspx");
        }

        
      
///////////////////////////////////////////////////////////
       
        public double getItemPrice(string itemNum)//complete
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            double itemPrice = 0;
            cmd = new MySqlCommand("SELECT price FROM item WHERE itemid=@x", connection);
            cmd.Parameters.AddWithValue("@x", itemNum);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                itemPrice += double.Parse("0" + dataReader["PRICE"]);
            }
            dataReader.Close();
            connection.Close();
            return itemPrice;
        }
        public double getHighestBid(string itemNum)//complete
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            double highestBid = 0;
            cmd = new MySqlCommand("SELECT Max(bidamount) AS HIGHESTBID FROM bids WHERE itemid=@x", connection);
            cmd.Parameters.AddWithValue("@x", itemNum);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                highestBid = double.Parse("0" + dataReader["HIGHESTBID"]);
            }
            dataReader.Close();
            connection.Close();
            return highestBid;
        }
        public bool placeBid(Double bid, String itemNum, String user_Id)//completed
        {
            //retrieve price of current item
            double itemPrice = getItemPrice(itemNum);
            if (bid < itemPrice)
                return false;
            else
            {
                //retrieve highest bid from DB and store highestbid
                double highestBid = getHighestBid(itemNum);
                //MessageBox.Show("the highest bid is " + highestBid);
                if (itemPrice < highestBid)
                {
                    if (bid > highestBid)
                    {
                        if (bid > highestBid * 1.1)
                            itemPrice = highestBid * 1.1;
                        else
                            itemPrice = bid;
                        //MessageBox.Show("updating highest bidder");
                        updateHighestBidder(itemNum, user_Id);//update highest bid and bidders table as well as price
                    }
                    else
                    {
                        if (highestBid > bid * 1.1)
                            itemPrice = bid * 1.1;
                        else
                            itemPrice = highestBid;
                    }
                }
                else
                {
                    if (bid > itemPrice * 1.1)
                        itemPrice = itemPrice * 1.1;
                    else
                        itemPrice = bid;
                }
            }
            updatePrice(itemNum, itemPrice);
            updateBidders(user_Id, itemNum, bid);
            updateEndDate(itemNum); //update auction end time
            return true;
        }
        public DateTime getEndDate(string itemNum)//complete
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            cmd = new MySqlCommand("SELECT enddate FROM item WHERE itemid = @y", connection);
            cmd.Parameters.AddWithValue("@y", itemNum);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            DateTime endDate = DateTime.Now;
            while (dataReader.Read())
            {
                endDate = DateTime.Parse("" + dataReader["enddate"]);
            }
            dataReader.Close();
            connection.Close();
            return endDate;
        }
        public void updateEndDate(string itemNum)//complete
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            DateTime current = DateTime.Now;
            DateTime endDate = getEndDate(itemNum);
            //MessageBox.Show(endDate.ToString());
            if (endDate.CompareTo(current.AddMinutes(15)) <= 0)
            {
                //MessageBox.Show("updating endDate to " + current.AddMinutes(15).ToString());//have to make the database value compatible with minutes
                cmd = new MySqlCommand("UPDATE item SET enddate = DATE_ADD(NOW(),INTERVAL 15 MINUTE)  WHERE itemid =@y", connection);
                cmd.Parameters.AddWithValue("@y", itemNum);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Close();
            }
            connection.Close();
        }
        public void updateBidders(string user_Id, string itemNum, double bid)//complete
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            cmd = new MySqlCommand("INSERT INTO bids (userid,itemid,bidamount) VALUES (@x,@y,@z)", connection);
            cmd.Parameters.AddWithValue("@x", user_Id);
            cmd.Parameters.AddWithValue("@y", itemNum);
            cmd.Parameters.AddWithValue("@z", bid);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            connection.Close();
            dataReader.Close();
        }
        public void updatePrice(string itemNum, double itemPrice)//complete
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            cmd = new MySqlCommand("UPDATE item SET price = @x WHERE itemid = @y", connection);
            cmd.Parameters.AddWithValue("@x", itemPrice);
            cmd.Parameters.AddWithValue("@y", itemNum);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            connection.Close();
            dataReader.Close();
        }
        public string getHigherstBidder(string itemNum)//complete
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            cmd = new MySqlCommand("SELECT highestbidder FROM listed WHERE itemid = @y", connection);
            cmd.Parameters.AddWithValue("@y", itemNum);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            string highestBidder = "";
            while (dataReader.Read())
            {
                highestBidder = "" + dataReader["highestbidder"];
            }
            dataReader.Close();
            connection.Close();
            return highestBidder;
        }
        public void updateHighestBidder(string itemNum, string user_Id)//must add the email functionality
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            string highestBidder = getHigherstBidder(itemNum);
            //call email functionality here
            cmd = new MySqlCommand("UPDATE listed SET highestbidder = @x WHERE itemid = @y", connection);
            cmd.Parameters.AddWithValue("@x", userId);
            cmd.Parameters.AddWithValue("@y", itemNum);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Close();
            connection.Close();
        }

        protected void buyitnowBT_Click(object sender, EventArgs e)
        {
            // delete item from listed
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            cmd = new MySqlCommand("DELETE FROM listed WHERE itemid = @y", connection);
            cmd.Parameters.AddWithValue("@y", itemNum);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Close();
            // get buy it now price
            cmd = new MySqlCommand("SELECT buyitnow FROM item WHERE itemid = @z", connection);
            cmd.Parameters.AddWithValue("@z", itemNum);
            MySqlDataReader dataReader2 = cmd.ExecuteReader();
            dataReader2.Read();
            string buyItNow = dataReader2[0].ToString();
            dataReader2.Close();
            // add item to sold
            cmd = new MySqlCommand("INSERT INTO sold (itemid, price) VALUES(@a,@b)", connection); 
            cmd.Parameters.AddWithValue("@a", itemNum);
            cmd.Parameters.AddWithValue("@b", buyItNow);
            MySqlDataReader dataReader3 = cmd.ExecuteReader();
            dataReader3.Close();
            connection.Close();
            Server.Transfer("user.aspx");
        }
   
        
    }
}