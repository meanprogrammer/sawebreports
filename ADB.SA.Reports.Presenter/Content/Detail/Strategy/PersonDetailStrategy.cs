using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Entities.Enums;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Utilities;
using ADB.SA.Reports.Utilities.HtmlHelper;
using ADB.SA.Reports.Global;

namespace ADB.SA.Reports.Presenter.Content
{
    public class PersonDetailStrategy : DetailStrategyBase
    {
        public override string BuildDetail(EntityDTO dto)
        {

            HtmlTable t = new HtmlTable(2, 0, "grid");

            //t.AppendRowHtml(base.BuildType(dto.Type, 1));

            t.AddCell(GlobalStringResource.Email);
            t.AddCell(dto.RenderHTML(GlobalStringResource.Email, RenderOption.Break));

            t.AddCell(GlobalStringResource.Contact);
            t.AddCell(dto.RenderHTML(GlobalStringResource.Contact, RenderOption.Break));

            return t.EndHtmlTable();
        }
    }
}
