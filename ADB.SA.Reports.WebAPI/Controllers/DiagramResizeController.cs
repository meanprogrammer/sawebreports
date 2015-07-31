using ADB.SA.Reports.Data;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Utilities.WMF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;

namespace ADB.SA.Reports.WebAPI.Controllers
{
    public class DiagramResizeController : Controller
    {
        public JsonResult Save(int recordId, float percentage)
        {
            return null;
        }

        [Route("api/diagramresize/{recordId}/{percentage}")]
        public JsonResult Resize(int recordId, float percentage)
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
            return Json( ss  , "text/plain", Encoding.Unicode, JsonRequestBehavior.AllowGet);
        }
    }
}
