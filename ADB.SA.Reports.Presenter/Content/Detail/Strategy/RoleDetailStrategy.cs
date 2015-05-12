using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Data;
using ADB.SA.Reports.Entities.Enums;
using ADB.SA.Reports.Utilities;
using ADB.SA.Reports.Global;
using ADB.SA.Reports.Utilities.HtmlHelper;

namespace ADB.SA.Reports.Presenter.Content
{
    public class RoleDetailStrategy : DetailStrategyBase
    {
        public override string BuildDetail(EntityDTO dto)
        {
            EntityData data = new EntityData();
            EntityDTO description = data.GetRoleDetail(dto.ID);
            description.ExtractProperties();

            HtmlTable t = new HtmlTable(2, 0, "grid");

            //t.AppendRowHtml(BuildCloseLink(2));

            //t.AddHeader(description.Name, 2);
            //t.AppendRowHtml(base.BuildType(description.Type, 1));
            t.AddCell(GlobalStringResource.Responsibilities);
            t.AddCell(description.RenderHTML(GlobalStringResource.Responsibilities, RenderOption.Break));
            //t.AddCell(GlobalStringResource.Description);
            //t.AddCell(description.RenderHTML(GlobalStringResource.Description, RenderOption.Break));
            //t.AddCell(GlobalStringResource.ReferenceDocuments);
            //t.AddCell(description.RenderHTML(GlobalStringResource.ReferenceDocuments, RenderOption.Break));

            BuildDescription(t, dto);
            BuildReferencedDocuments(t, dto);
            return t.EndHtmlTable();
        }
    }
}
