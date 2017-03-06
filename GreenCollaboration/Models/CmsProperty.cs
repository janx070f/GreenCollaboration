using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenCollaboration.Models
{
    public class CmsProperty
    {
        [Key]
        public int PropertyId { get; set; }
        public int PageId { get; set; }
        public CmsPage Page { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public CmsPropType Type { get; set; }
        [AllowHtml]
        public string Value { get; set; }


    }

    public enum CmsPropType
    {
        TextBox,
        Editor,
        DatePicker,
        TextArea
    }
}