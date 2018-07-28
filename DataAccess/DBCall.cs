using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using nLOGGER = Logger;
using nCOMMON = Common;

namespace DataAccess
{
    public class DBCall
    {
        private nLOGGER.Logger log = nLOGGER.Logger.GetInstance();
        private nCOMMON.CacheManager cache = new nCOMMON.CacheManager();
        public DataTable ExecuteSelectCommand(string cmdStr)
        {
            DataTable retTab = null;
            try
            {
                log.Debug("Entering " + MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name);
                if (!string.IsNullOrEmpty(cmdStr))
                {
                    retTab = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmdStr, GetConnection()))
                    {
                        da.Fill(retTab);
                    }
                }
                log.Debug("Exiting " + MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, MethodBase.GetCurrentMethod().Name);
            }
            return retTab;
        }

        #region Private Methods
        private SqlConnection GetConnection()
        {
            SqlConnection con = null;
            try
            {
                log.Debug("Entering " + MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name);
                string conStr = cache.CONNECTION_STRING;
                if (!string.IsNullOrEmpty(conStr))
                {
                    con = new SqlConnection(conStr);
                }
                log.Debug("Exiting " + MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, MethodBase.GetCurrentMethod().Name);
            }
            return con;
        }
        #endregion
    }
}
