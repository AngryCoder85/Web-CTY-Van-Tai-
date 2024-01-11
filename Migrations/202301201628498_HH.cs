namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HH : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChuyenXes", "KhoiLuongHH", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChuyenXes", "KhoiLuongHH", c => c.Single(nullable: false));
        }
    }
}
