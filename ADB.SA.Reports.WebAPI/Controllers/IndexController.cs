using ADB.SA.Reports.Data;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Presenter.Content;
using ADB.SA.Reports.Presenter.Utils;
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
            dto.ExtractProperties();
            ProcessStrategy st = new ProcessStrategy();
            PageResponseDTO response = new PageResponseDTO();
            response.BreadCrumbContent = BreadcrumbHelper.BuildBreadcrumbContent(dto);
            response.Header = dto.Name;
            response.Content = MainContentBuilder.BuildContent(dto);
            switch (dto.Type)
            {
                case 111:
                    response.RenderType = "process";
                    break;
                case 142:
                    response.RenderType = "subprocess";
                    break;
                case 145:
                    response.RenderType = "st2020";
                    break;
                default:
                    break;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}
