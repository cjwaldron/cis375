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
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        
    }
}