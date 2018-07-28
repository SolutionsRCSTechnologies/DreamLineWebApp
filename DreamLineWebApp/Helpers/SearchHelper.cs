using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nBUSINESS = BusinessLogic;
using nENTITIES = Entities;
using nCOMMON = Common;
using DreamLineWebApp.Models;
using nLOGGER = Logger;
using System.Reflection;

namespace DreamLineWebApp
{
    public class SearchHelper
    {
        public static nLOGGER.Logger log = nLOGGER.Logger.GetInstance();
        private nBUSINESS.SearchHelper helper = new nBUSINESS.SearchHelper();

        public void GetSearchResult(WebSearch searchObj)
        {
            try
            {
                log.Debug("Entering " + MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name);
                nENTITIES.WebSearch _searchObj = searchObj.Instance;
                nENTITIES.SearchResults results = helper.GetSearchResult(_searchObj);
                log.Debug("Exiting " + MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}