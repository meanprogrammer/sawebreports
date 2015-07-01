using ADB.SA.Reports.Data;
using ADB.SA.Reports.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADB.SA.Reports.WebAPI.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        [HttpGet]
        public JsonResult Index(int id)
        {
            EntityData data = new EntityData();
            EntityDTO dto = data.GetOneEntity(id); 

            return Json(dto, JsonRequestBehavior.AllowGet);
        }

    }
}
