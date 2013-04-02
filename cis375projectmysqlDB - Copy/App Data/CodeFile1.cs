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
    public static class pageSecurity
    {
        static Boolean isLoggedin = false;
        static int currentUserIdNum;
        static int currentUserId;

        public static void setLogin(bool loggedIn)
        {
            isLoggedin = loggedIn;
        }
        public static bool getLogin()
        {
            return isLoggedin;
        }
        public static void setCurrentUserID(int userid)
        {
            currentUserId = userid;
        }
        public static int getUserID()
        {
            if (isLoggedin == true)
            {
                return currentUserId;
            }
            else
                return 0;
        }
    }
}

