using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cis375projectmysqlDB
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void headerHomeBT_Click(object sender, EventArgs e)
        {
            Server.Transfer("default.aspx");
        }

        protected void headerLogoutBT_Click(object sender, EventArgs e)
        {   
            bool security = false;
            pageSecurity.setLogin(security);
            Server.Transfer("default.aspx");
        }
    }
}