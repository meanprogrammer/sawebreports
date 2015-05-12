using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Entities.Enums;
using ADB.SA.Reports.Utilities;
using ADB.SA.Reports.Global;
using ADB.SA.Reports.Utilities.HtmlHelper;

namespace ADB.SA.Reports.Presenter.Content
{
    public class ReviewerApproverPositionDetailStrategy : DetailStrategyBase
    {
        public override string BuildDetail(EntityDTO dto)
        {
            HtmlTable t = new HtmlTable(2, 0, "grid");

            //t.AppendRowHtml(base.BuildType(dto.Type, 1));

            t.AddCell(GlobalStringResource.Assignedto);
            t.AddCell(dto.RenderHTML(GlobalStringResource.Assignedto, RenderOption.Break));

            //t.AddCell(GlobalStringResource.Description);
            //t.AddCell(dto.RenderHTML(GlobalStringResource.Description, RenderOption.Break));

            //t.AddCell(GlobalStringResource.ReferenceDocuments);
            //t.AddCell(dto.RenderHTML(GlobalStringResource.ReferenceDocuments, RenderOption.Break));

            BuildDescription(t, dto);
            BuildReferencedDocuments(t, dto);

            return t.EndHtmlTable();
        }
    }
}
