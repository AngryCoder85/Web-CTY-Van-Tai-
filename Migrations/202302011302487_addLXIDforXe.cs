namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLXIDforXe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Xes", "LXID", c => c.Long(nullable: false));
            CreateIndex("dbo.Xes", "LXID");
            AddForeignKey("dbo.Xes", "LXID", "dbo.LoaiXes", "LXID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Xes", "LXID", "dbo.LoaiXes");
            DropIndex("dbo.Xes", new[] { "LXID" });
            DropColumn("dbo.Xes", "LXID");
        }
    }
}
