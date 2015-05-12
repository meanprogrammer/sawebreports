using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Data;
using ADB.SA.Reports.Global;

namespace ADB.SA.Reports.Presenter.Content
{
    public class DetailBuilder2
    {
        public static object BuildDetail(EntityDTO dto)
        {
            DetailContext2 context = null;
            switch (dto.Type)
            {
                case 175:
                    context = new DetailContext2(new AcronymDetailStrategy2());
                    break;
                case 436:
                    context = new DetailContext2(new SectionNameDetailStrategy2());
                    break;
                case 156:
                    context = new DetailContext2(new RoleDetailStrategy2());
                    break;
                case 701:
                    context = new DetailContext2(new ReviewerApproverPositionDetailStrategy2());
                    break;
                case 603:
                    DetailStrategyBase2 strategy = ResolveBpmnDetailStrategy(dto);
                    context = new DetailContext2(strategy);
                    break;
                case 321:
                    context = new DetailContext2(new OrganizationUnitDetailStrategy2());
                    break;
                case 663:
                    context = new DetailContext2(new PersonDetailStrategy2());
                    break;
                case 3:
                    context = new DetailContext2(new ProcessDetailStrategy2());
                    break;
                case 178:
                    context = new DetailContext2(new ControlOwnerDetailStrategy2());
                    break;
                case 172:
                    context = new DetailContext2(new ControlObjectiveDetailStrategy2());
                    break;
                case 440:
                    context = new DetailContext2(new FrequencyforControlDetailStrategy2());
                    break;
                case 441:
                    context = new DetailContext2(new ControlApplicationNameDetailStrategy2());
                    break;
                default:
                    context = new DetailContext2(null);
                    break;
            }

            return context.BuildDetail(dto);
        }

        private static DetailStrategyBase2 ResolveBpmnDetailStrategy(EntityDTO dto)
        {
            if (SAWebContext.Request["ctl"] != null && SAWebContext.Request["ctl"] == "true")
            {
                return new BpmnDetailCTLStrategy2();
            }
            return new BpmnDetailStrategy2();
        }
    }
}
