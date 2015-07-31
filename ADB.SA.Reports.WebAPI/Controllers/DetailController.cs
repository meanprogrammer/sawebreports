using ADB.SA.Reports.Data;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Presenter.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ADB.SA.Reports.WebAPI.Controllers
{
    public class DetailController : ApiController
    {
        //
        // GET: /Detail/

        public object Index(int id)
        {
            EntityData data = new EntityData();
            EntityDTO dto = data.GetOneEntity(id);
            dto.ExtractProperties();
            object detail = DetailBuilder2.BuildDetail(dto);
            return detail;
            //return Json(detail, JsonRequestBehavior.AllowGet);
        }

    }
}
