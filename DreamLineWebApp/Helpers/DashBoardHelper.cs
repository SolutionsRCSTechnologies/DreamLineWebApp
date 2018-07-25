using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nBUSINESS = BusinessLogic;
using nENTITIES = Entities;
using nCOMMON = Common;
using DreamLineWebApp.Models;

namespace DreamLineWebApp.Helpers
{
    public class DashBoardHelper
    {
        public DashBoard GetDashBoard()
        {
            DashBoard dashBoard = null;
            nBUSINESS.DashBoardHelper helper = new nBUSINESS.DashBoardHelper();
            return dashBoard;
        }
    }
}