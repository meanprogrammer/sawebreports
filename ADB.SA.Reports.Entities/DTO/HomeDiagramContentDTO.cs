using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADB.SA.Reports.Entities.DTO
{
    public class HomeDiagramContentDTO
    {
        public List<HomeDiagramGroupDTO> LeftGroup { get; set; }
        public List<HomeDiagramGroupDTO> RightGroup { get; set; }
    }

    public class HomeDiagramGroupDTO
    {
        public string Name { get; set; }
        public string CssClass { get; set; }
        public int ID { get; set; }
    }

    public class HomeDiagramItemDTO 
    {
        public string Key { get; set; }
        public List<AsIsItemEntity> ChildItems { get; set; } 
    }
}
