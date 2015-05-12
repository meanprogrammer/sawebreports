using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Utilities.HtmlHelper;

namespace ADB.SA.Reports.Presenter.Content
{
    public class ControlObjectiveDetailStrategy : DetailStrategyBase
    {
        public override string BuildDetail(ADB.SA.Reports.Entities.DTO.EntityDTO dto)
        {
            HtmlTable t = new HtmlTable(2, 0, "grid");
            BuildDescription(t, dto);
            BuildReferencedDocuments(t, dto);
            return t.EndHtmlTable();
        }
    }
}
