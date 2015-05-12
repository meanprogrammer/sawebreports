using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADB.SA.Reports.Entities.DTO;

namespace ADB.SA.Reports.Presenter.Content
{
    public class ContentBuilder
    {
        public static string BuildContent(EntityDTO dto)
        {
            ContentContext context = null;
            switch (dto.Type)
            {
                case 111:
                    context = new ContentContext(new ProcessStrategy());
                    break;
                case 142:
                    context = new ContentContext(new SubProcessContentStrategy());
                    break;
                //case 79:
                //    context = new ContentContext(new SystemArchitectureContentStrategy());
                //    break;
                case 145:
                    context = new ContentContext(new Strategy2020ContentStrategy());
                    break;
                default:
                    context = new ContentContext(new GenericContentStrategy());
                    break;
            }
            
            return context.BuildContent(dto);
        }
    }
}
