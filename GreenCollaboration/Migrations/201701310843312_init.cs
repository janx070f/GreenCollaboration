namespace GreenCollaboration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CmsPages",
                c => new
                {
                    PageId = c.Int(nullable: false, identity: true),
                    ParentId = c.Int(),
                    CreateDate = c.DateTime(nullable: false),
                    Name = c.String(),
                    Alias = c.String(),
                    Url = c.String(),
                    ShowInMenu = c.Boolean(nullable: false),
                    Level = c.Int(nullable: false),
                    Order = c.Int(nullable: false),
                    IconName = c.String(),
                    TemplateId = c.Int(nullable: false),
                    CmsPage_PageId = c.Int(),
                })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.CmsPages", t => t.CmsPage_PageId)
                .ForeignKey("dbo.CmsPages", t => t.ParentId)
                .ForeignKey("dbo.CmsTemplates", t => t.TemplateId, cascadeDelete: false)
                .Index(t => t.ParentId)
                .Index(t => t.TemplateId)
                .Index(t => t.CmsPage_PageId);

            CreateTable(
                "dbo.CmsProperties",
                c => new
                {
                    PropertyId = c.Int(nullable: false, identity: true),
                    PageId = c.Int(nullable: false),
                    Alias = c.String(),
                    Type = c.String(),
                    Value = c.String(),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("dbo.CmsPages", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);

            CreateTable(
                "dbo.CmsTemplates",
                c => new
                {
                    TemplateId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Alias = c.String(),
                })
                .PrimaryKey(t => t.TemplateId);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CmsPages", "TemplateId", "dbo.CmsTemplates");
            DropForeignKey("dbo.CmsProperties", "PageId", "dbo.CmsPages");
            DropForeignKey("dbo.CmsPages", "ParentId", "dbo.CmsPages");
            DropForeignKey("dbo.CmsPages", "CmsPage_PageId", "dbo.CmsPages");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CmsProperties", new[] { "PageId" });
            DropIndex("dbo.CmsPages", new[] { "CmsPage_PageId" });
            DropIndex("dbo.CmsPages", new[] { "TemplateId" });
            DropIndex("dbo.CmsPages", new[] { "ParentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.CmsTemplates");
            DropTable("dbo.CmsProperties");
            DropTable("dbo.CmsPages");
        }
    }
}
