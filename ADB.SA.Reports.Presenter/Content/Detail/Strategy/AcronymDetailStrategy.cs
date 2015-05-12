using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Entities.Enums;
using ADB.SA.Reports.Utilities;
using ADB.SA.Reports.Utilities.HtmlHelper;
using ADB.SA.Reports.Global;

namespace ADB.SA.Reports.Presenter.Content
{
    public class AcronymDetailStrategy : DetailStrategyBase
    {
        public override string BuildDetail(EntityDTO dto)
        {
            HtmlTable t = new HtmlTable(2, 0, "grid");
            //t.AppendRowHtml(BuildCloseLink(2));
            //t.AddHeader(dto.Name, 2);
            //t.AppendRowHtml(base.BuildType(dto.Type,1 ));
            t.AddCell(GlobalStringResource.AbbreviationDescription);
            t.AddCell(dto.RenderHTML(GlobalStringResource.AbbreviationDescription, RenderOption.Break));
            BuildDescription(t, dto);
            BuildReferencedDocuments(t, dto);
            return t.EndHtmlTable();
        }
    }
}
