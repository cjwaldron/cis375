using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cis375projectmysqlDB
{
    public partial class item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool security=false;
            security = pageSecurity.getLogin();
            if (security == false)
                Server.Transfer("default.aspx");
        }
    }
}