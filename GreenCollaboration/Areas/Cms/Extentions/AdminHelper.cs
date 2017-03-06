using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenCollaboration.Models;

namespace GreenCollaboration.Areas.Cms.Extentions
{
    public class AdminHelper
    {

        public static IEnumerable<SelectListItem> GetPropTypes()
        {
            var enums = Enum.GetValues(typeof(CmsPropType)).Cast<CmsPropType>();
            var selectlist = new List<SelectListItem>();
            foreach (var e in enums)
            {
                selectlist.Add(new SelectListItem
                {
                    Text = e.ToString(),
                    Value = e.ToString()
                });
            }
            return selectlist;
        }

        public static MvcHtmlString RenderPropType(CmsPropType type, string value, string alias)
        {
            switch (type)
            {
                case CmsPropType.TextBox:
                    return new MvcHtmlString("<input type='text' name ='" + alias + "' class='form-control' value='" + value + "' placeholder='" + alias + "'/>");
                case CmsPropType.DatePicker:
                    return new MvcHtmlString("<input type='date' name ='" + alias + "' class='form-control' value='" + value + "'/>");
                case CmsPropType.Editor:
                    return new MvcHtmlString("<textarea name='" + alias + "' class='editor' rows='10'>" + value + "</textarea>");
                case CmsPropType.TextArea:
                    return new MvcHtmlString("<textarea name='" + alias + "' class='form - control'>" + value + "</textarea>");
                default:
                    return new MvcHtmlString("No editor for this");
            }

        }


        /// <summary>
        /// NiceUrl
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToUrlName(string text)
        {
            var newUrlName = text.ToLower().Trim();

            newUrlName = newUrlName.Replace(",-", "");
            newUrlName = newUrlName.Replace(" ", "-");
            newUrlName = newUrlName.Replace("c#", "c-sharp");
            newUrlName = newUrlName.Replace("æ", "ae");
            newUrlName = newUrlName.Replace("ø", "oe");
            newUrlName = newUrlName.Replace("å", "aa");
            newUrlName = newUrlName.Replace("'", "");
            newUrlName = newUrlName.Replace("/", "");
            newUrlName = newUrlName.Replace("&", "");
            newUrlName = newUrlName.Replace(";", "");
            newUrlName = newUrlName.Replace(":", "");
            newUrlName = newUrlName.Replace(",", "");
            newUrlName = newUrlName.Replace(".", "");
            newUrlName = newUrlName.Replace("+", "");
            newUrlName = newUrlName.Replace("=", "");
            newUrlName = newUrlName.Replace("(", "");
            newUrlName = newUrlName.Replace(")", "");
            newUrlName = newUrlName.Replace("%", "");
            newUrlName = newUrlName.Replace("#", "");
            newUrlName = newUrlName.Replace("!", "");
            newUrlName = newUrlName.Replace("---", "-");
            newUrlName = newUrlName.Replace("--", "-");
            newUrlName = newUrlName.Replace("_", "-");

            return newUrlName;

        }
    }
}