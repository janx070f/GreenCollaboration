using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenCollaboration.Models
{
    public class CmsTemplate
    {
        [Key]
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

    }
}