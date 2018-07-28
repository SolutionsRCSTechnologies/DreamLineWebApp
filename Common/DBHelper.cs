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
            string colKey = string.Empty, colVal = string.Empty, colActive = string.Empty, commandStr = string.Empty;
             DataTable sourceTab = null;
            try
            {
                commandStr = @"SELECT * FROM ACD_APPLICATION_CONFIGURATION_TABLE WHERE ACTIVE_FLAG = 'Y'";
                sourceTab = Execute(commandStr);
                if (sourceTab != null && sourceTab.Rows!=null && sourceTab.Rows.Count > 0)
                {
                    colActive = "ACTIVE_FLAG";colKey = "CONFIG_KEY"; colVal = "CONFIG_VALUE";
                    dicObj = GetListFromTable(sourceTab, colKey, colVal, colActive, ref dicObj);
                }
                sourceTab = null;
                commandStr = @"SELECT * FROM ACD_APPLICATION_CONTENTS_TABLE WHERE ACTIVE_FLAG = 'Y'";
                sourceTab = Execute(commandStr);
                if (sourceTab != null && sourceTab.Rows != null && sourceTab.Rows.Count > 0)
                {
                    colActive = "ACTIVE_FLAG"; colKey = "CONTENT_KEY"; colVal = "CONTENT_VALUE";
                    dicObj = GetListFromTable(sourceTab, colKey, colVal, colActive, ref dicObj);
                }
            }
            catch (Exception ex)
            {

            }
            return dicObj;
        }

        private Dictionary<string, object> GetListFromTable(DataTable sTab, string colKey, string colVal, string colActive, ref Dictionary<string, object> obj)
        {
            obj = obj ?? new Dictionary<string, object>();
            if (sTab != null && sTab.HasErrors)
            {
                foreach (DataRow dr in sTab.Rows)
                {
                    if (dr != null)
                    {
                        if (dr[colActive] != null && Convert.ToString(dr[colActive]) == "Y")
                        {
                            string key = dr[colKey] != null && !string.IsNullOrEmpty(Convert.ToString(dr[colKey])) ? Convert.ToString(dr[colKey]) : string.Empty;
                            if (!string.IsNullOrEmpty(key) && !obj.ContainsKey(key))
                            {
                                object item = dr[colVal] != null ? dr[colVal] : null;
                                if (item != null)
                                {
                                    obj.Add(key, item);
                                }
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
