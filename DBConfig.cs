using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaninLaundry
{
    class DBConfig
    {
        public static string dbServer = "localhost";
        public static string dbUser = "root";
        public static string dbName = "dbhanin";
        public static string dbPass = "";

        public static string ConnStr => $"server={dbServer};user={dbUser};database={dbName};password={dbPass};";

    }
}
