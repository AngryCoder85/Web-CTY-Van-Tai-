namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update0201_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaiXes", "Xe_XeId", "dbo.Xes");
            DropIndex("dbo.TaiXes", new[] { "Xe_XeId" });
            DropColumn("dbo.TaiXes", "XeId");
            DropColumn("dbo.TaiXes", "Xe_XeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaiXes", "Xe_XeId", c => c.Long());
            AddColumn("dbo.TaiXes", "XeId", c => c.String(nullable: false));
            CreateIndex("dbo.TaiXes", "Xe_XeId");
            AddForeignKey("dbo.TaiXes", "Xe_XeId", "dbo.Xes", "XeId");
        }
    }
}
