using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect
{
    public class Sql
    {
        public static string ConnectionString
        {
            get
            {
                string con = ConfigurationManager.ConnectionStrings["UserDbContext"].ConnectionString;
                return con;
            }
        }
    }
}
