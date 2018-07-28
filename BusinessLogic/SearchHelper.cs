using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using nENTITIES = Entities;
using nLOGGER = Logger;

namespace BusinessLogic
{
    public class SearchHelper
    {
        public static nLOGGER.Logger log = nLOGGER.Logger.GetInstance();
        public nENTITIES.SearchResults GetSearchResult(nENTITIES.WebSearch searchObj)
        {
            nENTITIES.SearchResults result = new nENTITIES.SearchResults();
            try
            {
                log.Debug("Entering " + MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name);

                log.Debug("Exiting " + MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }
    }
}
