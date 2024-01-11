namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLX : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiXes",
                c => new
                    {
                        LXID = c.Long(nullable: false, identity: true),
                        LXName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LXID);
            
            AddColumn("dbo.ChuyenXes", "GhiChuSX", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChuyenXes", "GhiChuSX");
            DropTable("dbo.LoaiXes");
        }
    }
}
