namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update0201 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaiXes", "XeId", c => c.String(nullable: false));
            AddColumn("dbo.TaiXes", "Xe_XeId", c => c.Long());
            CreateIndex("dbo.TaiXes", "Xe_XeId");
            AddForeignKey("dbo.TaiXes", "Xe_XeId", "dbo.Xes", "XeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaiXes", "Xe_XeId", "dbo.Xes");
            DropIndex("dbo.TaiXes", new[] { "Xe_XeId" });
            DropColumn("dbo.TaiXes", "Xe_XeId");
            DropColumn("dbo.TaiXes", "XeId");
        }
    }
}
