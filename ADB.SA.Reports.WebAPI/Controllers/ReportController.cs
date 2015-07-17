using ADB.SA.Reports.Data;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Global;
using ADB.SA.Reports.Presenter;
using ADB.SA.Reports.Presenter.Report;
using ADB.SA.Reports.Utilities;
using ADB.SA.Reports.Utilities.WMF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ADB.SA.Reports.WebAPI.Controllers
{
    public class ReportController : Controller
    {
        [HttpGet]
        public ActionResult  Report(int id)
        {
            EntityData entityData = new EntityData();
            FileData filesData = new FileData();
            WmfImageManager imageManager = null;
            var stream = new MemoryStream();
            // processing the stream.


            EntityDTO dto = entityData.GetOneEntity(id);
            dto.ExtractProperties();

            FileDTO file = filesData.GetFile(dto.DGXFileName);

            byte[] diagram = file.Data;
            //Save the raw .wmf file
            int poolCount = entityData.GetPoolCount(dto.ID);


            imageManager = new WmfImageManager(dto, diagram, dto.DGXFileName, dto.Type, poolCount, true);

            string resizedDiagram = imageManager.SaveAndResizeImage(diagram, dto.DGXFileName, dto.Type,
                                    poolCount, true);

            string[] images = new string[] { PathResolver.MapPath(resizedDiagram) };

            if (poolCount > 1 && dto.Type == 142)
            {
                //slice the wmf
                SubProcessSlicer slicer = new SubProcessSlicer(resizedDiagram);
                images = slicer.Slice();
            }

            List<PdfContentParameter> contents = ReportBuilder.BuildReport(dto);
            byte[] pdfBytes = PDFBuilder.CreatePDF(contents, images, dto.Type);

            //System.IO.File.WriteAllBytes(@"C:\\Users\\vd2\\test.pdf", pdfBytes);

            return new FileStreamResult(new MemoryStream(pdfBytes), "application/pdf"); 

        }
    }
}
