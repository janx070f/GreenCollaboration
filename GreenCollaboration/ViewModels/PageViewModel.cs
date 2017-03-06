using System;
using System.Collections.Generic;

namespace GreenCollaboration.ViewModels
{
    public class PageViewModel
    {
        public int PageId { get; set; }
        public dynamic Parent { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Url { get; set; }
        public bool ShowInMenu { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public string IconName { get; set; }
        public string Template { get; set; }
        public List<dynamic> Properties { get; set; }
        public List<dynamic> Children { get; set; }

    }
}