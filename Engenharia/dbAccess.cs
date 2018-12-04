using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia
{
    public class dbAccess
    {
        public static List<Dictionary<string, object>> callSql(string command)
        {
            List<Dictionary<string, object>> tableResult = new List<Dictionary<string, object>>();
            var con = new OleDbConnection(Keys.conStr);
            var cmd = new OleDbCommand(command, con);
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var line = new Dictionary<string, object>();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        line.Add(dr.GetName(i), dr.GetValue(i));
                    }
                    tableResult.Add(line);
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
           
            

            return tableResult;
        }
    }
}
