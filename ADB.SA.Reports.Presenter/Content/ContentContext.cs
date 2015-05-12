using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Entities.DTO;

namespace ADB.SA.Reports.Presenter.Content
{
    public class ContentContext
    {
        ContentStrategyBase strategy;

        public ContentContext(ContentStrategyBase strategy)
        {
            this.strategy = strategy;
        }

        public string BuildContent(EntityDTO dto)
        {
            return this.strategy.BuildContent(dto);
        }
    }
}
