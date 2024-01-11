namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HHstr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChuyenXes", "KhoiLuongHH", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChuyenXes", "KhoiLuongHH", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
