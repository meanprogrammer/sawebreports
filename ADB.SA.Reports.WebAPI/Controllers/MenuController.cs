using ADB.SA.Reports.Configuration;
using ADB.SA.Reports.Data;
using ADB.SA.Reports.Entities.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ADB.SA.Reports.WebAPI.Controllers
{
    public class MenuController : ApiController
    {
        //
        // GET: /Menu/
        public List<SAMenuItemDTO> Get()
        {
            List<SAMenuItemDTO> arrangedMenuItems = new List<SAMenuItemDTO>();
            NavigationData data = new NavigationData();

            MenuFilterSection menu = MenuFilterSection.GetConfig();
            List<string> ids = menu.GetItemsToBeRemove();

            string filter = string.Join(",", ids.ToArray());
            MenuOrderSection menuOrder = MenuOrderSection.GetConfig();
            List<SAMenuItemDTO> menuItems = data.GetAllUsedDiagrams(filter);

            if (menuOrder.MenuOrders.Count > 0)
            {
                foreach (MenuOrder item in menuOrder.MenuOrders)
                {
                    SAMenuItemDTO order = menuItems.FirstOrDefault(c => c.ID == item.Id);
                    if (order != null)
                    {
                        arrangedMenuItems.Insert(item.Order, order);
                    }
                }

                if (menuItems.Count > menuOrder.MenuOrders.Count)
                {
                    foreach (MenuOrder item in menuOrder.MenuOrders)
                    {
                        var order = menuItems.FirstOrDefault(c => c.ID == item.Id);
                        if (order != null)
                        {
                            menuItems.Remove(order);
                        }
                    }
                    arrangedMenuItems.AddRange(menuItems);
                }
            }
            else
            {
                arrangedMenuItems = menuItems.OrderBy(diag => diag.Text).ToList();
            }

           // var json = JsonConvert.SerializeObject(arrangedMenuItems);
            //return new JsonResult() { Data = arrangedMenuItems, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return arrangedMenuItems;
        }

    }
}
