namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTXIdforCX : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChuyenXes", "TXId", c => c.Long());
            CreateIndex("dbo.ChuyenXes", "TXId");
            AddForeignKey("dbo.ChuyenXes", "TXId", "dbo.TaiXes", "TXId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChuyenXes", "TXId", "dbo.TaiXes");
            DropIndex("dbo.ChuyenXes", new[] { "TXId" });
            DropColumn("dbo.ChuyenXes", "TXId");
        }
    }
}
