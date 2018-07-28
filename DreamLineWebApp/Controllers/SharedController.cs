using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nENTITIES = Entities;

namespace DreamLineWebApp.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSearchView()
        {
            nENTITIES.WebSearch objSearch = new nENTITIES.WebSearch();
            ViewBag.Search = objSearch;
            return View("Search");
        }
    }
}