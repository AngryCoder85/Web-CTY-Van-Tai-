namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgtTX : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChamCongs", "TXId", "dbo.TaiXes");
            DropIndex("dbo.ChamCongs", new[] { "TXId" });
            AlterColumn("dbo.ChamCongs", "TXId", c => c.Long(nullable: false));
            CreateIndex("dbo.ChamCongs", "TXId");
            AddForeignKey("dbo.ChamCongs", "TXId", "dbo.TaiXes", "TXId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChamCongs", "TXId", "dbo.TaiXes");
            DropIndex("dbo.ChamCongs", new[] { "TXId" });
            AlterColumn("dbo.ChamCongs", "TXId", c => c.Long());
            CreateIndex("dbo.ChamCongs", "TXId");
            AddForeignKey("dbo.ChamCongs", "TXId", "dbo.TaiXes", "TXId");
        }
    }
}
