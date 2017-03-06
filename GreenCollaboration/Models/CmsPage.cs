using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenCollaboration.Models
{
    public class CmsPage
    {
        [Key]
        public int PageId { get; set; }
        public int? ParentId { get; set; }
        public CmsPage Parent { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Url { get; set; }
        public bool ShowInMenu { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public string IconName { get; set; } = "fa-folder";
        public int TemplateId { get; set; }
        public CmsTemplate Template { get; set; }
        public List<CmsProperty> Properties { get; set; } = new List<CmsProperty>();
        public List<CmsPage> Children { get; set; } = new List<CmsPage>();

    }
}