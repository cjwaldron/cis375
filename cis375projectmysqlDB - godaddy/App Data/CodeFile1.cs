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
    public static class itemID
    {
        static int currentItemId=0;
        public static void setItemId(int id)
        {
            currentItemId = id;
        }
        public static int getItemId()
        {
            return currentItemId;
        }
    }
    public static class pageSecurity
    {
        static Boolean isLoggedin = false;
        static string username;
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
        public static void setusername(string userNAME)
        {
            username = userNAME;
        }
        public static string getUsername()
        {
            if (isLoggedin == true)
            {
                return username;
            }
            else
                return " ";

        }

    }
}

