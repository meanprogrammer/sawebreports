using ADB.SA.Reports.Data;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Presenter.Content;
using ADB.SA.Reports.Presenter.Utils;
using ADB.SA.Reports.Utilities.WMF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ADB.SA.Reports.WebAPI.Controllers
{
    public class IndexController : ApiController
    {
        //
        // GET: /Index/
       // [System.Web.Http.HttpGet]
        public HttpResponseMessage Get(int id)
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
                case 79:
                    response.RenderType = "sysarch";
                    break;
                default:
                    break;
            }
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.Created, response);
  
            return result; //Json(response, JsonRequestBehavior.AllowGet);
        }
        /*

        public HttpResponseMessage Resize(int recordId, float percentage)
        {

            EntityData data = new EntityData();

            EntityDTO dto = data.GetOneEntity(recordId);
            dto.ExtractProperties();
            FileData files = new FileData();
            FileDTO file = files.GetFile(dto.DGXFileName);
            byte[] imageBytes = file.Data;
            string path = string.Format("{0}_{1}", file.Date.ToFileTime().ToString(), dto.DGXFileName);
            int poolCount = data.GetPoolCount(dto.ID);
            WmfImageManager imageManager = new WmfImageManager(dto, imageBytes,
                path, dto.Type, poolCount, false);
            path = imageManager.ProcessImageWithPercentage(percentage);
            Dictionary<string, string> ss = new Dictionary<string, string>();
            ss.Add("path", path.Replace(@"\", @"/"));
            //return Json( ss  , "text/plain", Encoding.Unicode, JsonRequestBehavior.AllowGet);

            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.Created, path.Replace(@"\", @"/"));
            return result;
        }*/
    }
}
