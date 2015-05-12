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
    public class OrganizationUnitDetailStrategy : DetailStrategyBase
    {
        public override string BuildDetail(EntityDTO dto)
        {
            HtmlTable t = new HtmlTable(2, 0, "grid");
            BuildDescription(t, dto);
            BuildReferencedDocuments(t, dto);
            return t.EndHtmlTable();
        }
    }
}
