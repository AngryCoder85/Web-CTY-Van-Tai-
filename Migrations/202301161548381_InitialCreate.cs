namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        KHId = c.Long(nullable: false, identity: true),
                        KHName = c.String(),
                        KHSdt = c.String(),
                        KHDiaChi = c.String(),
                    })
                .PrimaryKey(t => t.KHId);
            
            CreateTable(
                "dbo.TaiXes",
                c => new
                    {
                        TXId = c.Long(nullable: false, identity: true),
                        TXName = c.String(),
                        TXSdt = c.String(),
                    })
                .PrimaryKey(t => t.TXId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaiXes");
            DropTable("dbo.KhachHangs");
        }
    }
}
