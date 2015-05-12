using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Data;
using ADB.SA.Reports.Entities.Enums;
using ADB.SA.Reports.Presenter.Utils;
using ADB.SA.Reports.Utilities;
using ADB.SA.Reports.Global;
using ADB.SA.Reports.Entities.Utils;

namespace ADB.SA.Reports.Presenter.Content
{
    public class BpmnDetailCTLStrategy : DetailStrategyBase
    {
        EntityData entityData = null;

        public BpmnDetailCTLStrategy()
        {
            entityData = new EntityData();
        }

        public override string BuildDetail(ADB.SA.Reports.Entities.DTO.EntityDTO dto)
        {
            StringBuilder html = new StringBuilder();

            html.AppendFormat(Resources.TableStartTag, "grid");
            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableHeaderTag, 3, GlobalStringResource.SubprocessName);
            html.Append(Resources.TableRowEndTag);

            List<EntityDTO> relatedCtlSubProcess = entityData.GetCtlSubProcess(dto.ID);

            if (relatedCtlSubProcess.Count > 0)
            {
                foreach (var ctl in relatedCtlSubProcess)
                {
                    html.Append(Resources.TableRowStartTag);
                    html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 3, ctl.Name);
                    html.Append(Resources.TableRowEndTag);
                }
            }

            html.AppendFormat(Resources.TableHeaderTag, 3, GlobalStringResource.Details);

            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableCellLabel, string.Empty, GlobalStringResource.User);
            html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2,
                dto.RenderHTML(GlobalStringResource.User, RenderOption.Break));
            html.Append(Resources.TableRowEndTag);

            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableCellLabel, string.Empty, GlobalStringResource.ActivityNature);
            html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2,
                dto.RenderHTML(GlobalStringResource.ActivityNature, RenderOption.Break));
            html.Append(Resources.TableRowEndTag);

            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableCellLabel, string.Empty, GlobalStringResource.TriggerInput);
            html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2, dto.RenderHTML(GlobalStringResource.TriggerInput, RenderOption.Break));
            html.Append(Resources.TableRowEndTag);

            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableCellLabel, string.Empty, GlobalStringResource.Output);
            html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2, dto.RenderHTML(GlobalStringResource.Output, RenderOption.Break));
            html.Append(Resources.TableRowEndTag);

            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableCellLabel, string.Empty, GlobalStringResource.ActivityStepDescription);
            html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2, dto.RenderHTML(GlobalStringResource.ActivityStepDescription, RenderOption.Break));
            html.Append(Resources.TableRowEndTag);

            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableCellLabel, string.Empty, GlobalStringResource.ActivityNarrative);
            html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2, dto.RenderHTML(GlobalStringResource.ActivityNarrative,
                RenderOption.Paragraph));
            html.Append(Resources.TableRowEndTag);

            html.Append(Resources.TableEndTag);

            html.AppendFormat(Resources.TableStartTag, "grid");

            List<EntityDTO> controTypes = entityData.GetControlTypesCtl(dto.ID);
            if (controTypes.Count > 0)
            {
                html.AppendFormat(Resources.TableHeaderTag, 9, "Control Details");

                html.Append(Resources.TableRowStartTag);
                html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 9, "Control Objectives Legend:</br>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<b>C</b> - Completeness&emsp;&emsp;&emsp;<b>A</b> - Accuracy&emsp;&emsp;&emsp;<b>V</b> - Validity&emsp;&emsp;&emsp;<b>R</b> - Restricted Access"); 
                html.Append(Resources.TableRowEndTag);

                html.Append(Resources.TableRowStartTag);
                html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 9, "");
                html.Append(Resources.TableRowEndTag);
                
                html.Append(Resources.TableRowStartTag);
                html.AppendFormat(Resources.TableCell, "td-head", "Control Name");
                html.AppendFormat(Resources.TableCell, "td-head", "Control Description");
                html.AppendFormat(Resources.TableCell, "td-head", "C");
                html.AppendFormat(Resources.TableCell, "td-head", "A");
                html.AppendFormat(Resources.TableCell, "td-head", "V");
                html.AppendFormat(Resources.TableCell, "td-head", "R");
                html.AppendFormat(Resources.TableCell, "td-head", "Control Type");
                html.AppendFormat(Resources.TableCell, "td-head", "Control Kind");
                html.AppendFormat(Resources.TableCell, "td-head", "Control Owner");
                html.Append(Resources.TableRowEndTag);

                foreach (EntityDTO control in controTypes)
                {
                    control.ExtractProperties();
                    html.Append(Resources.TableRowStartTag);
                    html.AppendFormat(Resources.TableCell, string.Empty, control.Name);
                    html.AppendFormat(Resources.TableCell, string.Empty, control.RenderHTML("Description", RenderOption.None));
                    html.AppendFormat(Resources.TableCell, string.Empty, GetImageTag(control.RenderHTML("Completeness", RenderOption.None)));
                    html.AppendFormat(Resources.TableCell, string.Empty, GetImageTag(control.RenderHTML("Accuracy", RenderOption.None)));
                    html.AppendFormat(Resources.TableCell, string.Empty, GetImageTag(control.RenderHTML("Validity", RenderOption.None)));
                    html.AppendFormat(Resources.TableCell, string.Empty, GetImageTag(control.RenderHTML("Restricted Access", RenderOption.None)));
                    html.AppendFormat(Resources.TableCell, string.Empty, control.RenderHTML("Control Type", RenderOption.None));
                    html.AppendFormat(Resources.TableCell, string.Empty, control.RenderHTML("Control Kind", RenderOption.None));
                    html.AppendFormat(Resources.TableCell, string.Empty, control.RenderHTML("WHO",RenderOption.None));
                    html.Append(Resources.TableRowEndTag);


                    html.Append(Resources.TableRowStartTag);
                    html.Append("<td colspan='9'>");
                    html.Append(Resources.TableStartTag);
                    html.Append(Resources.TableRowStartTag);
                    
                    StringBuilder controlHtml = CreateControlDetailsHtml(control);
                    html.AppendFormat("<td valign=\"top\" style=\"width:50%;border:0 !important;\">{0}</td>", controlHtml);
                    //html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 3, controlHtml.ToString());
                    StringBuilder riskHtml = CreateRiskDetails(control);
                    html.AppendFormat("<td valign=\"top\" style=\"width:50%;border:0 !important;\">{0}</td>", riskHtml);
                    //html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 6, riskHtml.ToString());


                    html.Append(Resources.TableRowEndTag);
                    html.Append(Resources.TableEndTag);
                    html.Append("</td>");
                    html.Append(Resources.TableRowEndTag);
                }
            }

            html.Append(Resources.TableEndTag);
            

            return html.ToString();
        }

        private StringBuilder CreateRiskDetails(EntityDTO control)
        {
            StringBuilder riskHtml = new StringBuilder();

            EntityDTO relatedRisk = entityData.GetControlRelatedRisk(control.ID);
            if (relatedRisk != null)
            {
                relatedRisk.ExtractProperties();
                riskHtml.AppendFormat(Resources.TableStartTag, "grid");


                riskHtml.Append(Resources.TableRowStartTag);
                riskHtml.AppendFormat(Resources.TableHeaderTag, 2, string.Format("Risk - {0}", relatedRisk.Name));
                riskHtml.Append(Resources.TableRowEndTag);

                //Consequence
                riskHtml.Append(Resources.TableRowStartTag);
                riskHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Consequence");
                riskHtml.AppendFormat(Resources.TableCell, string.Empty, relatedRisk.RenderHTML("Consequence", RenderOption.Break));
                riskHtml.Append(Resources.TableRowEndTag);

                //Completeness
                riskHtml.Append(Resources.TableRowStartTag);
                riskHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Completeness");
                riskHtml.AppendFormat(Resources.TableCell, string.Empty, relatedRisk.RenderHTML("Completeness", RenderOption.Break));
                riskHtml.Append(Resources.TableRowEndTag);

                //Existence/Occurrence
                riskHtml.Append(Resources.TableRowStartTag);
                riskHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Existence/Occurrence");
                riskHtml.AppendFormat(Resources.TableCell, string.Empty, relatedRisk.RenderHTML("Existence/Occurrence", RenderOption.Break));
                riskHtml.Append(Resources.TableRowEndTag);

                //Valuation or Allocation
                riskHtml.Append(Resources.TableRowStartTag);
                riskHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Valuation or Allocation");
                riskHtml.AppendFormat(Resources.TableCell, string.Empty, relatedRisk.RenderHTML("Valuation or Allocation", RenderOption.Break));
                riskHtml.Append(Resources.TableRowEndTag);

                //Rights and Obligations
                riskHtml.Append(Resources.TableRowStartTag);
                riskHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Rights and Obligations");
                riskHtml.AppendFormat(Resources.TableCell, string.Empty, relatedRisk.RenderHTML("Rights and Obligations", RenderOption.Break));
                riskHtml.Append(Resources.TableRowEndTag);

                //Presentation and Disclosure
                riskHtml.Append(Resources.TableRowStartTag);
                riskHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Presentation and Disclosure");
                riskHtml.AppendFormat(Resources.TableCell, string.Empty, relatedRisk.RenderHTML("Presentation and Disclosure", RenderOption.Break));
                riskHtml.Append(Resources.TableRowEndTag);

                //Description
                riskHtml.Append(Resources.TableRowStartTag);
                riskHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Description");
                riskHtml.AppendFormat(Resources.TableCell, string.Empty, relatedRisk.RenderHTML("Description", RenderOption.Break));
                riskHtml.Append(Resources.TableRowEndTag);

                //Reference Documents
                riskHtml.Append(Resources.TableRowStartTag);
                riskHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Reference Documents");
                riskHtml.AppendFormat(Resources.TableCell, string.Empty, relatedRisk.RenderHTML("Reference Documents", RenderOption.Break));
                riskHtml.Append(Resources.TableRowEndTag);

                riskHtml.Append(Resources.TableEndTag);
            }
            return riskHtml;
        }

        private StringBuilder CreateControlDetailsHtml(EntityDTO control)
        {
            StringBuilder controlHtml = new StringBuilder();
            controlHtml.AppendFormat(Resources.TableStartTag, "grid");

            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableHeaderTag, 2, "Control");
            controlHtml.Append(Resources.TableRowEndTag);

            //Mitigates Risk
            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Mitigates Risk");
            controlHtml.AppendFormat(Resources.TableCell, string.Empty, control.RenderHTML("Mitigates Risk", RenderOption.Break));
            controlHtml.Append(Resources.TableRowEndTag);

            //Evidence
            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Evidence");
            controlHtml.AppendFormat(Resources.TableCell, string.Empty, control.RenderHTML("Evidence", RenderOption.Break));
            controlHtml.Append(Resources.TableRowEndTag);

            //Business Unit
            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Business Unit");

            List<EntityDTO> relatedBusinessUnit = entityData.GetRelatedBusinessUnit(control.ID);

            string rbuhtml = RenderControlRelatedProperties(relatedBusinessUnit);

            controlHtml.AppendFormat(Resources.TableCell, string.Empty, rbuhtml);
            controlHtml.Append(Resources.TableRowEndTag);

            //WHO - (control owner)
            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "WHO - (control owner)");

            List<EntityDTO> relatedControlOwners = entityData.GetRelatedControlOwner(control.ID);
            string rcoHtml = RenderControlRelatedProperties(relatedControlOwners);

            controlHtml.AppendFormat(Resources.TableCell, string.Empty, rcoHtml);
            controlHtml.Append(Resources.TableRowEndTag);

            //Control Objectives
            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Control Objectives");

            List<EntityDTO> relatedControlObj = entityData.GetRelatedControlObjectives(control.ID);
            string rcObj = RenderControlRelatedProperties(relatedControlObj);

            controlHtml.AppendFormat(Resources.TableCell, string.Empty, rcObj);
            controlHtml.Append(Resources.TableRowEndTag);

            //Frequency
            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Frequency");

            List<EntityDTO> relatedFrequency = entityData.GetRelatedFrequency(control.ID);
            string rcfHtml = RenderControlRelatedProperties(relatedFrequency);

            controlHtml.AppendFormat(Resources.TableCell, string.Empty, rcfHtml);
            controlHtml.Append(Resources.TableRowEndTag);

            //Application Name
            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Application Name");

            List<EntityDTO> relatedApplications = entityData.GetRelatedControlApplications(control.ID);
            string raHtml = RenderControlRelatedProperties(relatedApplications);

            controlHtml.AppendFormat(Resources.TableCell, string.Empty, raHtml);
            controlHtml.Append(Resources.TableRowEndTag);

            //Control Category
            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Control Category");
            controlHtml.AppendFormat(Resources.TableCell, string.Empty, control.RenderHTML("Control Category", RenderOption.Break));
            controlHtml.Append(Resources.TableRowEndTag);

            //Corrective
            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Corrective");
            controlHtml.AppendFormat(Resources.TableCell, string.Empty, control.RenderHTML("Corrective", RenderOption.Break));
            controlHtml.Append(Resources.TableRowEndTag);

            //Reference Documents
            controlHtml.Append(Resources.TableRowStartTag);
            controlHtml.AppendFormat(Resources.TableCellLabel, string.Empty, "Reference Documents");
            controlHtml.AppendFormat(Resources.TableCell, string.Empty, control.RenderHTML("Reference Documents", RenderOption.Break));
            controlHtml.Append(Resources.TableRowEndTag);

            controlHtml.Append(Resources.TableEndTag);
            return controlHtml;
        }

        private string RenderControlRelatedProperties(List<EntityDTO> controlRelatedEntity)
        {
            StringBuilder html = new StringBuilder();
            if (controlRelatedEntity.Count > 0)
            {
                html.Append("<ul style=\"list-style:none;margin:0;padding:0;\">");
                foreach (EntityDTO entity in controlRelatedEntity)
                {
                    entity.ExtractProperties();
                    html.Append("<li>");
                    html.AppendFormat("<a tag=\"{0}\">{1}</a>", entity.ID, entity.Name);
                    html.AppendFormat("<div id=\"div_{0}\" class=\"tooltip-holder\">", entity.ID);
                    html.Append(DetailBuilder.BuildDetail(entity));
                    html.Append("</div>");
                    html.Append("</li>");
                }
                html.Append("</ul>");
            }
            return html.ToString();
        }

        private static string GetImageTag(string value)
        {
            if (value.ToUpper() == "T")
            {
                return "<img src=\"images/tick-icon.png\" alt=\"\" />";
            }
            return "<img src=\"images/cross-icon.png\" alt=\"\" />";
        }
    }
}
