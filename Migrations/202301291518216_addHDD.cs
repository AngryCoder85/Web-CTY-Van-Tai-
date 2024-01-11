namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHDD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HoaDonDoes",
                c => new
                    {
                        HoaDonDoID = c.Long(nullable: false, identity: true),
                        NgayThang = c.DateTime(nullable: false),
                        HDXuat = c.Long(nullable: false),
                        HDNhap = c.Long(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.HoaDonDoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HoaDonDoes");
        }
    }
}
