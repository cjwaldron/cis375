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

    
        protected void Gridview1Btn_Click(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;
            string itemid = GridView1.Rows[index].Cells[1].Text;
            itemID.setItemId(Convert.ToInt32(itemid));
            Server.Transfer("item.aspx");
        }

        protected void GridView2Btn_Click(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;
            string itemid = GridView2.Rows[index].Cells[1].Text;
            itemID.setItemId(Convert.ToInt32(itemid));
            Server.Transfer("item.aspx");

        }

        protected void GridView3Btn_Click(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;
            string itemid = GridView3.Rows[index].Cells[1].Text;
            itemID.setItemId(Convert.ToInt32(itemid));
            Server.Transfer("item.aspx");


        }

 

        
    }
}