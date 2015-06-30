using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADB.SA.Reports.Entities.DTO
{
    /// <summary>
    /// Class represents each item in the navigation.
    /// </summary>
    public class SAMenuItemDTO
    {
        /// <summary>
        /// Default constructor, initializes child items.
        /// </summary>
        public SAMenuItemDTO()
        {
            ChildItems = new List<SAMenuItemDTO>();
        }

        /// <summary>
        /// The diagram id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The label.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// List of child items.
        /// </summary>
        public List<SAMenuItemDTO> ChildItems { get; set; }
    }
}
