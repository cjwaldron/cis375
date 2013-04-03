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
        string title, description,category,startDate,endDate,currentTime,mysqlStartDate,mysqlEndDate;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            bool security = false;
            security = pageSecurity.getLogin();
            if (security == false)
                Server.Transfer("default.aspx");
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
            qstring.Append("','8')");
            string sqlquery = qstring.ToString();
            command.CommandText = sqlquery;
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            conn.Close();
        }

       

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

    }
}