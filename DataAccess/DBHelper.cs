﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using nLOGGER = Logger;

namespace DataAccess
{
    public class DBHelper
    {
        private nLOGGER.Logger log = nLOGGER.Logger.GetInstance();
        public DataTable GetResultSet(string cmdStr)
        {
            DataTable retTab = null;
            try
            {
                log.Debug("Entering " + MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name);

                log.Debug("Exiting " + MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, MethodBase.GetCurrentMethod().Name);
            }
            return retTab;
        }
    }
}
