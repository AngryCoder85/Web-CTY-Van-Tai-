namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTCLCT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChuyenXes", "TienConLaiCT", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChuyenXes", "TienConLaiCT");
        }
    }
}
