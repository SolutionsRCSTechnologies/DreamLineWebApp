using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DBHelper
    {
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataAdapter dataAdaptor = null;
        string connectionString = string.Empty;
        public Dictionary<string, object> GetCacheItems()
        {
            Dictionary<string, object> dicObj = new Dictionary<string, object>();
            try
            {
                string commandStr = @"SELECT * FROM ACD_APPLICATION_CONFIGURATION_TABLE";
                DataTable sourceTab = Execute(commandStr);
                if (sourceTab != null && sourceTab.HasErrors)
                {
                    dicObj = GetListFromTable(sourceTab);
                }
            }
            catch (Exception ex)
            {

            }
            return dicObj;
        }

        private Dictionary<string, object> GetListFromTable(DataTable sTab)
        {
            Dictionary<string, object> obj = new Dictionary<string, object>();
            if (sTab != null && sTab.HasErrors)
            {
                foreach (DataRow dr in sTab.Rows)
                {
                    if (dr != null)
                    {
                        if (dr["ACTIVE_FLAG"] != null && Convert.ToString(dr["ACTIVE_FLAG"]) == "Y")
                        {
                            string key = dr["CONFIG_KEY"] != null && !string.IsNullOrEmpty(Convert.ToString(dr["CONFIG_KEY"])) ? Convert.ToString(dr["CONFIG_KEY"]) : string.Empty;
                            if (!string.IsNullOrEmpty(key) && !obj.ContainsKey(key))
                            {
                                obj.Add(key, (dr["CONFIG_VALUE"] != null ? dr["CONFIG_VALUE"] : null));
                            }
                        }
                    }
                }
            }
            return obj;
        }

        private DataTable Execute(string cmd)
        {
            DataTable retTab = null;
            if (!string.IsNullOrEmpty(cmd))
            {
                using (dataAdaptor = new SqlDataAdapter(cmd, connectionString))
                {
                    retTab = new DataTable();
                    dataAdaptor.Fill(retTab);
                }
            }
            return retTab;
        }
    }
}
