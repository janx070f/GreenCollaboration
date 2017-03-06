namespace GreenCollaboration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Updat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CmsProperties", "Type", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.CmsProperties", "Type", c => c.String());
        }
    }
}
