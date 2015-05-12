using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using ADB.SA.Reports.Entities;
using ADB.SA.Reports.Presenter;
using ADB.SA.Reports.View;

namespace ADB.SA.Reports.Web.Ajax
{
    public class AjaxFileUploadHandler : IHttpHandler, ICommentsView
    {
        CommentsPresenter presenter;
        HttpContext context = null;
        public AjaxFileUploadHandler()
        {
            presenter = new CommentsPresenter(this);
        }

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string id = context.Request["id"];
            string page = context.Request["page"];
            presenter.GetPagedComments(id, int.Parse(page));            
            
            #region old_code
            //if (context.Request.Files.Count == 0)
            //{
            //    return;
            //}

            //HttpPostedFile file = context.Request.Files[0];
            //string path = context.Server.MapPath("uploadedfile");
            //string fileName = Path.GetFileName(file.FileName);
            //string fullPath = string.Format(@"{0}\{1}", path, fileName);
            //file.SaveAs(fullPath);

            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            //Dictionary<string, string> files = new Dictionary<string, string>();
            //files.Add("name", fileName);
            //files.Add("size", file.ContentLength.ToString());
            //files.Add("type", file.ContentType);
            //files.Add("url", fileName);
            //files.Add("thumbnailUrl", fileName);
            //files.Add("deleteUrl", string.Empty);
            //files.Add("deleteType", "DELETE");

            //list.Add(files);

            //JsonResponse f = new JsonResponse()
            //{
            //    files = list
            //};

            //string jsonResponse = serializer.Serialize(f);

            //context.Response.Write(jsonResponse);
            //context.Response.End();
            #endregion 
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        #region ICommentsView Members

        public void RenderComments(string comments)
        {
            this.context.Response.Write(comments);
            this.context.Response.End();
        }

        public void RenderExcel(byte[] comments, string fileName)
        {
            throw new NotImplementedException();
        }

        public void LoginSuccess()
        {
            throw new NotImplementedException();
        }

        public void LoginFailed()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICommentsView Members


        public void RenderComments(ADB.SA.Reports.Entities.DTO.CommentResponseDTO response)
        {
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }

        #endregion
    }
}
