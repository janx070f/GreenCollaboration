﻿using System.ComponentModel.DataAnnotations;

namespace GreenCollaboration.Areas.Cms.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string LinkName { get; set; }
        public string MenuUrl { get; set; }
        public int SortOrder { get; set; }
    }
}