namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HHdecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChuyenXes", "KhoiLuongHH", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChuyenXes", "KhoiLuongHH", c => c.Double(nullable: false));
        }
    }
}
