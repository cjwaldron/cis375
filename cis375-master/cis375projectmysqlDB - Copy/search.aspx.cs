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
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool security = false;
            security = pageSecurity.getLogin();
            if (security == false)
                Server.Transfer("default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel4.Visible = true;
            Panel3.Visible = false;
            Panel5.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "saveItemID")
            {
                 int index = Convert.ToInt32(e.CommandArgument);
                 GridViewRow row = GridView1.Rows[index];
                 int id = Convert.ToInt32(row);
            }
        }









        public int index { get; set; }

        
    }
}