using ADB.SA.Reports.Configuration;
using ADB.SA.Reports.Data;
using ADB.SA.Reports.Entities.DTO;
using ADB.SA.Reports.Entities.Enums;
using ADB.SA.Reports.Global;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ADB.SA.Reports.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        EntityData data = new EntityData();
        [HttpGet]
        public JsonResult Index()
        {
            var id = WebConfigurationManager.AppSettings.Get("HOMEPAGE_ID");
            /*
            EntityDTO dto = data.GetOneEntity(int.Parse(id));
            return new JsonResult() { Data = dto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };*/
            AsIsData asIsData = new AsIsData();
            EntityData entityData = new EntityData();
            List<HomeDiagramItemDTO> sectionList = asIsData.GetSections();

            //StringBuilder html = new StringBuilder();

            EntityDTO mainDto = entityData.GetOneEntity(int.Parse(id));
            List<EntityDTO> symbols = asIsData.GetAllAsIsSymbols(int.Parse(id));

            foreach (EntityDTO symbol in symbols)
            {
                EntityDTO defDto = entityData.GetRelatedDefinition(symbol.ID);

                //04-07-2013
                //Added this check in order to ignore
                //symbols which doesnt have definition
                if (defDto == null)
                {
                    continue;
                }

                defDto.ExtractProperties();

                string group = defDto.RenderHTML(GlobalStringResource.ProcessModelGroup,
                    RenderOption.None);
                int itemorder = 0;
                string order = defDto.RenderHTML("Item Order",
                    RenderOption.None);

                if (!string.IsNullOrEmpty(order))
                {
                    int.TryParse(order, out itemorder);
                }

                List<EntityDTO> relatedDiagramDto = entityData.GetChildDiagrams(symbol.ID);

                if (sectionList.Where(c=>c.Key == group) != null)
                {
                    sectionList.Where(c=>c.Key == group).FirstOrDefault().ChildItems.Add(
                        new AsIsItemEntity()
                        {
                            DefinitionDTO = defDto,
                            DiagramDTO = relatedDiagramDto,
                            ItemOrder = itemorder
                        });
                }
            }


            /*
             * Arrange the items per group
             * if the item order is 0 then group the zeroes the arrange them alphabetically
             * then group the ones with orders then arrange them
             * clear the original list
             * append the zeroes first then the ordered
             */
            foreach (HomeDiagramItemDTO section in sectionList)
            {
                var list = section.ChildItems;
                var zeroes = list.Where(c => c.ItemOrder == 0)
                                 .OrderBy(d => d.DefinitionDTO.Name).ToList();
                var ordered = list.Where(x => x.ItemOrder > 0)
                                  .OrderBy(y => y.ItemOrder).ToList();
                section.ChildItems.Clear();
                section.ChildItems.AddRange(zeroes);
                section.ChildItems.AddRange(ordered);

            }

            //html.Append(BreadcrumbHelper.BuildBreadcrumb(mainDto));
            //html.Append(Resources.Split);
            //html.Append(mainDto.Name);
            //html.Append(Resources.Split);



            AsIsDiagramSection diagrams = AsIsDiagramSection.GetConfig();

            HomePageContentDTO home = new HomePageContentDTO();
            home.DiagramSection = convertConfigValues(diagrams);
            home.SectionList = sectionList;

            home.LeftGroupName = diagrams.LeftGroup.Name;
            home.LeftGroupCssClass = diagrams.LeftGroup.CssClass;
            home.RightGroupName = diagrams.RightGroup.Name;
            home.RightGroupCssClass = diagrams.RightGroup.CssClass;
            home.CurrentID = int.Parse(id);
            home.Title = mainDto.Name;
            if (ShowInformationBox())
            {
                //adds the info box on the homepage
                home.HomeInformation = ADB.SA.Reports.Utilities.AppSettingsReader.GetValue("HOME_DESCRIPTION");
            }

            return Json(home, JsonRequestBehavior.AllowGet);
        }

        private HomeDiagramContentDTO convertConfigValues(AsIsDiagramSection section)
        {
            HomeDiagramContentDTO dto = new HomeDiagramContentDTO();
            dto.LeftGroup = new List<HomeDiagramGroupDTO>();
            foreach (TopGroupElement left in section.LeftGroup)
            {
                dto.LeftGroup.Add(
                        new HomeDiagramGroupDTO() { 
                            CssClass = left.Color,
                            Name = left.Name
                        }
                    );
            }

            dto.RightGroup = new List<HomeDiagramGroupDTO>();
            foreach (TopGroupElement right in section.RightGroup)
            {
                dto.RightGroup.Add(
                        new HomeDiagramGroupDTO()
                        {
                            CssClass = right.Color,
                            Name = right.Name
                        }
                    );
            }

            return dto;
        }

        private bool ShowInformationBox()
        {
            bool result = true;
            if (SAWebContext.Request.Cookies.AllKeys.Contains("hide_home_box"))
            {
                result = false;
            }
            return result;
        }
    }
}
