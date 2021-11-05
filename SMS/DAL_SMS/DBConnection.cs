using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
namespace DAL_SMS
{
    public class DBConnection
    {
        public static SqlConnection con = new SqlConnection("server=DESKTOP-CUNAA3I\\SQLEXPRESS;uid=sa;pwd=123;database=SMD");
    }
}
