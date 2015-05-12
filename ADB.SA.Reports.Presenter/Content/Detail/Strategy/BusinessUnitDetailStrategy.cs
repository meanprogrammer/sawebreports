using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Utilities.HtmlHelper;

namespace ADB.SA.Reports.Presenter.Content
{
    public class BusinessUnitDetailStrategy : DetailStrategyBase
    {
        public override string BuildDetail(ADB.SA.Reports.Entities.DTO.EntityDTO dto)
        {
            HtmlTable t = new HtmlTable(2, 0, "grid");

            //t.AddHeader(dto.Name, 2);
            //t.AppendRowHtml(base.BuildType(dto.Type, 1));

            BuildDescription(t, dto);
            BuildReferencedDocuments(t, dto);

            //t.AddCell(GlobalStringResource.Description);
            //t.AddCell(dto.RenderHTML(GlobalStringResource.Description, RenderOption.Break));

            //t.AddCell(GlobalStringResource.ReferenceDocuments);
            //t.AddCell(dto.RenderHTML(GlobalStringResource.ReferenceDocuments, RenderOption.Break));

            return t.EndHtmlTable();
        }
    }
}
