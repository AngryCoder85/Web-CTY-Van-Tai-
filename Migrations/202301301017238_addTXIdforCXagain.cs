namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTXIdforCXagain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChuyenXes", "TXId", "dbo.TaiXes");
            DropIndex("dbo.ChuyenXes", new[] { "TXId" });
            AlterColumn("dbo.ChuyenXes", "TXId", c => c.Long(nullable: false));
            CreateIndex("dbo.ChuyenXes", "TXId");
            AddForeignKey("dbo.ChuyenXes", "TXId", "dbo.TaiXes", "TXId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChuyenXes", "TXId", "dbo.TaiXes");
            DropIndex("dbo.ChuyenXes", new[] { "TXId" });
            AlterColumn("dbo.ChuyenXes", "TXId", c => c.Long());
            CreateIndex("dbo.ChuyenXes", "TXId");
            AddForeignKey("dbo.ChuyenXes", "TXId", "dbo.TaiXes", "TXId");
        }
    }
}
