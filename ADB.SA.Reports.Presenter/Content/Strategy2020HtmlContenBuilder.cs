using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Global;
using ADB.SA.Reports.Presenter.Utils;

namespace ADB.SA.Reports.Presenter.Content
{
    public class Strategy2020HtmlContenBuilder
    {
        const string TABLETAG = "<table border=0 class='strategy-table'>";
        const string ENDTABLETAG = "</table>";

        public string BuildHtml(List<Strategy2020DTO> strategyList)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<div id='float-header'>");
            html.Append("<table border='0'>");
            html.Append("<tr><td colspan='100'><strong>Strategy 2020 and its elements</strong></td></tr>");
            html.Append("<tr>");
            html.Append("<td class='strategy-table-header width-100'>Agenda</td>");
            html.Append("<td><table border='0' width='100%'><tr><td class='strategy-table-header width-150'>Business Policy</td><td class='strategy-table-header width-200'>Business Rule</td><td class='strategy-table-header width-100'>Process</td><td class='strategy-table-header width-150' style='text-indent:5px;'>Application</td><td class='strategy-table-header width-200' style='text-indent:5px;'>Sub-Process</td><td class='strategy-table-header width-250' style='text-indent:5px;'>Module</td></tr></table></td>");
            html.Append("</tr>");
            html.Append("</table>");
            html.Append("</div>");

            html.Append("<div id='ia-holder'>");
            html.Append("<table border=0 class='strategy-table'>");

            if (strategyList.Count > 0)
            {
                int ctr0 = 0;
                foreach (var item in strategyList)
                {
                    StringBuilder policies = new StringBuilder();

                    policies.Append("<table border=0 class='strategy-table business-policy-table'>");
                    int ctr1 = 0;
                    foreach (var ip in item.Policies)
                    {
                        policies.Append("<tr>");
                        policies.AppendFormat("<td class='{0} width-150'>{1}</td>", DetermineCSS(ctr1), ip.BusinessPolicyName);

                        ctr1++;
                        policies.Append("<td>");
                        policies.Append("<table border=0 class='strategy-table rule-table'>");

                        int ctr2 = 0;
                        foreach (var r in ip.Rules)
                        {
                            policies.Append("<tr>");
                            policies.AppendFormat("<td class='{0} width-200'>{1}</td>", 
                                DetermineCSS(ctr2), 
                                string.Format(GlobalStringResource.Presenter_ParagraphReferenceLinkMarkupFormat, 
                                MappingToolUrlHelper.GenerateValidSectionLinkOnly(r.ShortBusinessRuleName), 
                                r.BusinessRuleName));

                            ctr2++;
                            policies.Append("<td>");

                            policies.Append("<table border=0 class='strategy-table process-table'>");
                            int ctr3 = 0;
                            foreach (var p in r.Processes)
                            {
                                policies.Append("<tr>");
                                if (p.ProcessDiagramID > 0)
                                {
                                    policies.AppendFormat("<td class='{0} width-200'><a href=\"Default.aspx?id={1}\" target=\"_blank\">{2}</a></td>", DetermineCSS(ctr3), p.ProcessDiagramID, p.ProcessName);
                                }
                                else
                                {
                                    policies.AppendFormat("<td class='{0} width-100'>{1}</td>", DetermineCSS(ctr3), p.ProcessName);
                                }

                                ctr3++;

                                if (p.Application.Count == 1)
                                {
                                    policies.AppendFormat(
                                        "<td class='width-150'>{0}</td>",
                                        p.Application.FirstOrDefault().ApplicationName
                                        );
                                }
                                else
                                {
                                    policies.Append("<td class='width-150'>");
                                    //policies.Append("<ul class='table-ul'>");
                                    int ctr4 = 0;
                                    foreach (var app in p.Application)
                                    {
                                        //policies.Append("<tr>");
                                        //policies.AppendFormat("<li class='{0} width-150 table-li'>{1}</li>", DetermineCSS(ctr4), app.ApplicationName);
                                        //policies.Append("</tr>");
                                        policies.AppendFormat("<span class='width-150'>{0}</span><br />", app.ApplicationName);
                                        ctr4++;
                                    }
                                    //policies.Append("</ul>");
                                    policies.Append("</td>");
                                }

                                    policies.Append("<td>");
                                    policies.Append("<table class='strategy-table sp-table' border=0 width='100%'>");
                                    int ctr5 = 0;
                                    foreach (var sp in p.SubProcesses)
                                    {
                                        policies.Append("<tr>");
                                        if (sp.SubProcessDiagramID > 0)
                                        {
                                            policies.AppendFormat("<td class='{0} width-200'><a href=\"Default.aspx?id={1}\" target=\"_blank\">{2}</a></td>", DetermineCSS(ctr5), sp.SubProcessDiagramID, sp.SubProcessName);
                                        }
                                        else
                                        {
                                            policies.AppendFormat("<td class='{0} width-200'>{1}</td>", DetermineCSS(ctr5), sp.SubProcessName);
                                        }
                                        ctr5++;

                                            policies.Append("<td>");

                                            policies.Append("<table class='strategy-table module-table' border=0 width='100%'>");
                                            int ctr6 = 0;
                                            foreach (var mod in sp.Modules)
                                            {
                                                policies.Append("<tr>");
                                                policies.AppendFormat("<td class='{0} width-300'>{1}</td>", DetermineCSS(ctr6), mod.ModuleName);
                                                policies.Append("</tr>");
                                                ctr6++;
                                            }
                                            policies.Append(ENDTABLETAG);
                                            policies.Append("</td>");
                                        
                                        policies.Append("</tr>");
                                    }
                                    policies.Append(ENDTABLETAG);

                                    policies.Append("</td>");


                                policies.Append("</tr>");
                            }
                            policies.Append(ENDTABLETAG);
                            policies.Append("</td>");
                            policies.Append("</tr>");
                        }
                        policies.Append(ENDTABLETAG);
                        policies.Append("</td>");
                        policies.Append("</tr>");
                    }
                    policies.Append(ENDTABLETAG);
                    string css0 = DetermineCSS(ctr0);
                    html.AppendFormat(
                        "<tr><td class='{0} width-100 agenda-column'>{1}</td><td>{2}</td></tr>",
                        css0,
                        item.Agenda,
                        policies.ToString()
                        );

                }
            }
            else
            {
                html.Append("<tr><td colspan='4'>No Data Found!<td></tr>");
            }
            html.Append(ENDTABLETAG);
            html.Append("</div>");

            return html.ToString();
        }

        private string DetermineCSS(int counter)
        {
            string css = string.Empty;

            if (counter % 2 == 0)
                css = "even-td";
            else
                css = "odd-td";

            return css;
        }
    }
}
