namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updTX : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaiXes", "TXName", c => c.String(nullable: false));
            AlterColumn("dbo.TaiXes", "TXSdt", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHangs", "KHName", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHangs", "KHSdt", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHangs", "KHDiaChi", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHangs", "KHDiaChi", c => c.String());
            AlterColumn("dbo.KhachHangs", "KHSdt", c => c.String());
            AlterColumn("dbo.KhachHangs", "KHName", c => c.String());
            AlterColumn("dbo.TaiXes", "TXSdt", c => c.String());
            AlterColumn("dbo.TaiXes", "TXName", c => c.String());
        }
    }
}
