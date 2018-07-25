using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nENTITIES = Entities;
using nCOMMON = Common;
using nBUSINESS = BusinessLogic;

namespace DreamLineWebApp.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}