using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
namespace SQL_Driver
{
    class Query
    {
        private string SQL;
        private List<SqlParameter> SqlParameters;


        public Query()
        {
            SQL = string.Empty;
            SqlParameters = new List<SqlParameter>();
        }

        public static Query EQ(string dataField, string value)
        {
            Query query = new Query();
            query.SQL += dataField + "=@" + dataField;
            query.SqlParameters.Add(new SqlParameter("@" + dataField, value));
            return query;
        }

        public static Query IN(string dataField, string [] value)
        {
            Query query = new Query();
            query.SQL += dataField + " IN ({0})";

            string inSQL = string.Empty;
            for (int index = 0; index < value.Length; index++)
            {
                inSQL += "@" + dataField + index + ",";
                query.SqlParameters.Add(new SqlParameter("@" + dataField + index, value));
            }
            query.SQL=string.Format(query.SQL, inSQL.TrimEnd(','));
            return query;
        }
        
        public static Query AND(Query condition1, Query condition2)
        {
            Query query = new Query();
            query.SQL = condition1.ToSQL() + " AND " + condition2.ToSQL();
            query.SqlParameters = condition1.SqlParameters.Concat(condition2.SqlParameters).ToList();
            return query;
        }

        public SqlParameter [] Get_SqlParameters()
        {
            return SqlParameters.ToArray();
        }
        
        public string ToSQL()
        {
            return SQL;
        }
    }
}
