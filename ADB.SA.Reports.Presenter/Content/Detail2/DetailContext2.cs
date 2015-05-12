using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Entities.DTO;

namespace ADB.SA.Reports.Presenter.Content
{
    public class DetailContext2
    {
        DetailStrategyBase2 strategy;

        public DetailContext2(DetailStrategyBase2 strategy)
        {
            this.strategy = strategy;
        }

        public object BuildDetail(EntityDTO dto)
        {
            return this.strategy.BuildDetail(dto);
        }
    }
}
