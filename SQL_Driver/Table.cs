using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Driver
{
    class Table
    {
        private string SQL;
        public Table()
        {
            SQL = string.Empty;
        }
        //public static Table SELECT (string tableName, Query condition)
        //{ 
        //    Table table =new Table ();
        //    table.SQL = "SELECT * FROM " + tableName + " WHERE " + condition.ToSQL();
        //    return table;
        //}
        public static Table SELECT(string tableName, Query condition, string fields = "*")
        {
            Table table = new Table();
            table.SQL = "SELECT "+fields+" FROM " + tableName + " WHERE " + condition.ToSQL();
            return table;
        }
        public string ToSQL()
        {
            return SQL;
        }
    }
}
