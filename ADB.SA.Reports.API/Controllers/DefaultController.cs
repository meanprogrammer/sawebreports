using ADB.SA.Reports.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADB.SA.Reports.API.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index(int id)
        {
            EntityData ed = new EntityData();
            var result = ed.GetOneEntity(id);
            return Ok(result);
        }
    }
}
