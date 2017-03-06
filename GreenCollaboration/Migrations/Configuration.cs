using GreenCollaboration.Models;

namespace GreenCollaboration.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GreenCollaboration.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GreenCollaboration.Models.ApplicationDbContext context)
        {
            var layout = new CmsTemplate
            {
                Name = "Layout",
                Alias = "layout"
            };
            var index = new CmsTemplate
            {
                Name = "Index",
                Alias = "index"
            };

            context.CmsTemplates.Add(layout);
            context.CmsTemplates.Add(index);

            var defaultroot = new CmsPage
            {
                Name = "Default",
                Alias = "default",
                IconName = "",
                Level = 0,
                Order = 0,
                Url = string.Empty,
                ShowInMenu = false,
                Template = layout
            };

            var indexpage = new CmsPage
            {
                Name = "Default",
                Alias = "default",
                Level = 1,
                Order = 0,
                Url = "/",
                ShowInMenu = true,
                Template = index,
                IconName = "fa-home",
                Parent = defaultroot
            };

            var prop = new CmsProperty
            {
                Name = "Textbox1",
                Alias = "textbox1",
                Type = "text",
                Value = string.Empty,
                Page = indexpage

            };

            context.CmsPages.Add(defaultroot);
            context.CmsPages.Add(indexpage);
            context.CmsProperties.Add(prop);

            context.SaveChanges();

        }
    }
}
