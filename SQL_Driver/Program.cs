using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQL_Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            Query myQuery = Query.AND(Query.EQ("test", "A"), Query.IN("no", new string[] { "1", "2" }));
            Table myTable = Table.SELECT("customer_profile", myQuery, "age, phone");
            using (SqlConnection cn = new SqlConnection(""))
            {
                SqlCommand cmd = new SqlCommand(myTable.ToSQL(), cn);
                cmd.Parameters.AddRange(myQuery.Get_SqlParameters());
            }

        }
    }
}
