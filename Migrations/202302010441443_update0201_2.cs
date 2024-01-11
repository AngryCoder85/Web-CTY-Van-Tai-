namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update0201_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaiXes", "XeId", c => c.Long(nullable: false));
            CreateIndex("dbo.TaiXes", "XeId");
            AddForeignKey("dbo.TaiXes", "XeId", "dbo.Xes", "XeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaiXes", "XeId", "dbo.Xes");
            DropIndex("dbo.TaiXes", new[] { "XeId" });
            DropColumn("dbo.TaiXes", "XeId");
        }
    }
}
