namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delTCL : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ChuyenXes", "TienConLai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChuyenXes", "TienConLai", c => c.Long(nullable: false));
        }
    }
}
