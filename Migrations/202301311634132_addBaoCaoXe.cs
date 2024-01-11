namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBaoCaoXe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaoCaoXes",
                c => new
                    {
                        BCXId = c.Long(nullable: false, identity: true),
                        XeId = c.String(nullable: false),
                        GhiChu = c.String(nullable: false),
                        Xe_XeId = c.Long(),
                    })
                .PrimaryKey(t => t.BCXId)
                .ForeignKey("dbo.Xes", t => t.Xe_XeId)
                .Index(t => t.Xe_XeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaoCaoXes", "Xe_XeId", "dbo.Xes");
            DropIndex("dbo.BaoCaoXes", new[] { "Xe_XeId" });
            DropTable("dbo.BaoCaoXes");
        }
    }
}
