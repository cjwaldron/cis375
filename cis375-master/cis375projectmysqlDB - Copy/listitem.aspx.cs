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

    public partial class listitem : System.Web.UI.Page
    {
        double price,buyItNow;
        string title, description,category,startDate,endDate,userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool security = false;
            security = pageSecurity.getLogin();
            if (security == false)
                Server.Transfer("default.aspx");
            userid = pageSecurity.getUserID().ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            category = ListBox1.SelectedValue;
            price = Convert.ToDouble(TextBox1.Text);
            if (CheckBox1.Checked == true)
                buyItNow = Convert.ToDouble(TextBox2.Text);
            title = TextBox3.Text;
            description = TextBox4.Text;
            endDate = Calendar1.SelectedDate.ToString();
            startDate = DateTime.Now.ToString();
            string connString = "Server=localhost;Port=3306;Database=cis375project;Uid=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            StringBuilder qstring = new StringBuilder("INSERT INTO item  (title,category,description,startdate,enddate,price,buyitnow,iduser) VALUES('");
            qstring.Append(title);
            qstring.Append("','");
            qstring.Append(category);
            qstring.Append("','");
            qstring.Append(description);
            qstring.Append("','");
            qstring.Append(startDate);
            qstring.Append("','");
            qstring.Append(endDate);
            qstring.Append("','");
            qstring.Append(price);
            qstring.Append("','");
            qstring.Append(buyItNow);
            qstring.Append("',");
            qstring.Append(userid);
            qstring.Append(")");
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Close();
            ////////////add item to listed////////////
            StringBuilder q_string = new StringBuilder("SELECT MAX(itemid) FROM item WHERE iduser = ");
            q_string.Append(pageSecurity.getUserID().ToString());
            string sql_query = q_string.ToString();
            command.CommandText = sql_query;
            MySqlDataReader reader1 = command.ExecuteReader();
            reader1.Read();
            string itemid = reader1[0].ToString();
            reader1.Close();
            StringBuilder insert_itemid = new StringBuilder("INSERT INTO listed (itemid) VALUES (");
            insert_itemid.Append(itemid);
            insert_itemid.Append(")");
            string insert_itemID = insert_itemid.ToString();
            command.CommandText = insert_itemID;
            MySqlDataReader reader2 = command.ExecuteReader();
            reader2.Read();
            reader2.Close();
            conn.Close();
            Server.Transfer("user.aspx");
        }

       

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            FileUpload1.SaveAs(Server.MapPath("~/images"));
             
  
        }

    }
}