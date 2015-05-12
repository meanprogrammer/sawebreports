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
    public class BpmnDetailStrategy : DetailStrategyBase
    {
        public override string BuildDetail(EntityDTO dto)
        {
            StringBuilder html = new StringBuilder();
            EntityData data = new EntityData();

            html.AppendFormat(Resources.TableStartTag, "grid");

            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableHeaderTag, 3, GlobalStringResource.SubprocessName);
            html.Append(Resources.TableRowEndTag);

            html.Append(Resources.TableRowStartTag);
            EntityDTO parent = data.GetActivityOverviewParent(dto.ID);
            //TODO:
            html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 3, parent.Name);
            html.Append(Resources.TableRowEndTag);

            //html.AppendFormat(Resources.TableHeaderTag, 3, dto.Name);
            //html.Append(base.BuildType(dto.Type, 2));

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
                RenderOption.Break));
            html.Append(Resources.TableRowEndTag);


            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableHeaderTag, 1, GlobalStringResource.ActivityVariation);
            html.AppendFormat(Resources.TableHeaderTag, 2, GlobalStringResource.Description);
            html.Append(Resources.TableRowEndTag);

            List<EntityDTO> variations = data.GetActivityVariations(dto.ID);

            if (variations.Count > 0)
            {
                foreach (EntityDTO variation in variations)
                {
                    variation.ExtractProperties();
                    html.Append(Resources.TableRowStartTag);
                    html.AppendFormat(Resources.TableCell, string.Empty, variation.Name);
                    html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2, variation.RenderHTML(GlobalStringResource.Description, RenderOption.Break));
                    html.Append(Resources.TableRowEndTag);
                }
            }

            //Business Rules
            //html.Append(Resources.TableRowStartTag);
            //html.AppendFormat(Resources.TableHeaderTag, 1, GlobalStringResource.BussinessRule);
            //html.AppendFormat(Resources.TableHeaderTag, 2, GlobalStringResource.Description);
            //html.Append(Resources.TableRowEndTag);

            //List<EntityDTO> businessRules = data.GetBusinessRules(dto.ID);

            //if (businessRules.Count > 0)
            //{
            //    businessRules.Sort((b1, b2) => string.Compare(b1.Name, b2.Name, true));
            //    foreach (EntityDTO document in businessRules)
            //    {
            //        document.ExtractProperties();
            //        html.Append(Resources.TableRowStartTag);
            //        html.AppendFormat(Resources.TableCell, string.Empty, document.Name);
            //        html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2, document.RenderHTML(GlobalStringResource.Description, RenderOption.Break));
            //        html.Append(Resources.TableRowEndTag);
            //    }
            //}
            //Business Rules


            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableHeaderTag, 1, GlobalStringResource.ParagraphName);
            html.AppendFormat(Resources.TableHeaderTag, 2, GlobalStringResource.ParagraphReference);
            html.Append(Resources.TableRowEndTag);
            List<EntityDTO> mappings = data.GetSubProcessParagraphs(dto.ID);

            if (mappings.Count > 0)
            {
                foreach (EntityDTO map in mappings)
                {
                    map.ExtractProperties();
                    html.Append(Resources.TableRowStartTag);
                    html.AppendFormat(Resources.TableCell, string.Empty, MappingToolUrlHelper.GenerateValidParagraphLinkMarkup(map.Name));
                    html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2, map.RenderHTMLAsAnchor(GlobalStringResource.ParagraphReference, RenderOption.Span, true));
                    html.Append(Resources.TableRowEndTag);
                }
            }

            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableHeaderTag, 1, GlobalStringResource.UseCaseID);
            html.AppendFormat(Resources.TableHeaderTag, 2, GlobalStringResource.Description);
            html.Append(Resources.TableRowEndTag);

            List<EntityDTO> useCases = data.GetUseCases(dto.ID);

            if (useCases.Count > 0)
            {
                foreach (EntityDTO useCase in useCases)
                {
                    useCase.ExtractProperties();
                    html.Append(Resources.TableRowStartTag);
                    html.AppendFormat(Resources.TableCell, string.Empty, useCase.Name);
                    html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2, useCase.RenderHTML(GlobalStringResource.Description, RenderOption.Break));
                    html.Append(Resources.TableRowEndTag);
                }
            }

            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableHeaderTag, 1, GlobalStringResource.RequiredData);
            html.AppendFormat(Resources.TableHeaderTag, 2, GlobalStringResource.Description);
            html.Append(Resources.TableRowEndTag);



            List<EntityDTO> requiredData = data.GetRequiredData(dto.ID);

            if (requiredData.Count > 0)
            {
                requiredData.Sort((b1, b2) => string.Compare(b1.Name, b2.Name, true));
                foreach (EntityDTO document in requiredData)
                {
                    document.ExtractProperties();
                    html.Append(Resources.TableRowStartTag);
                    html.AppendFormat(Resources.TableCell, string.Empty, document.Name);
                    html.AppendFormat(Resources.TableCellWithColSpan, string.Empty, 2, document.RenderHTML(GlobalStringResource.Description, RenderOption.Break));
                    html.Append(Resources.TableRowEndTag);
                }
            }


            html.Append(Resources.TableRowStartTag);
            html.AppendFormat(Resources.TableHeaderTag, 1, GlobalStringResource.SampleReference);
            html.AppendFormat(Resources.TableHeaderTag, 1, GlobalStringResource.Description);
            html.AppendFormat(Resources.TableHeaderTag, 1, GlobalStringResource.ReferenceLink);
            html.Append(Resources.TableRowEndTag);

            List<EntityDTO> sampleReferences = data.GetSampleReference(dto.ID);

            if (sampleReferences.Count > 0)
            {
                foreach (EntityDTO reference in sampleReferences)
                {
                    reference.ExtractProperties();
                    html.Append(Resources.TableRowStartTag);
                    html.AppendFormat(Resources.TableCell, string.Empty, reference.Name);
                    html.AppendFormat(Resources.TableCell, string.Empty, reference.RenderHTML(GlobalStringResource.Description, RenderOption.Break));
                    html.AppendFormat(Resources.TableCell, string.Empty, reference.RenderHTMLAsAnchor(GlobalStringResource.ReferenceLink, RenderOption.Span, true));
                    html.Append(Resources.TableRowEndTag);
                }
            }



            html.Append(Resources.TableEndTag);
            return html.ToString();
        }
    }
}
