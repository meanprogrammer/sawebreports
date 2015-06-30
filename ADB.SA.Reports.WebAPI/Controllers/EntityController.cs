using ADB.SA.Reports.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADB.SA.Reports.WebAPI.Controllers
{
    public class EntityController : Controller
    {
        //
        // GET: /Entity/
        [HttpGet]
        public ActionResult Index(int id)
        {
            return View();
        }

    }
}
