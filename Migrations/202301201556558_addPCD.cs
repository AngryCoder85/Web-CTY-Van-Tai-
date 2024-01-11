namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPCD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChuyenXes", "KHId", "dbo.KhachHangs");
            DropIndex("dbo.ChuyenXes", new[] { "KHId" });
            AddColumn("dbo.ChuyenXes", "PhiCD", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "KHId", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "SangChieu", c => c.String(nullable: false));
            AlterColumn("dbo.ChuyenXes", "NoiNhanHang", c => c.String(nullable: false));
            AlterColumn("dbo.ChuyenXes", "NoiTraHang", c => c.String(nullable: false));
            AlterColumn("dbo.ChuyenXes", "SanPham", c => c.String(nullable: false));
            AlterColumn("dbo.ChuyenXes", "Thu", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "Chi", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "Tong", c => c.Long(nullable: false));
            CreateIndex("dbo.ChuyenXes", "KHId");
            AddForeignKey("dbo.ChuyenXes", "KHId", "dbo.KhachHangs", "KHId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChuyenXes", "KHId", "dbo.KhachHangs");
            DropIndex("dbo.ChuyenXes", new[] { "KHId" });
            AlterColumn("dbo.ChuyenXes", "Tong", c => c.Long());
            AlterColumn("dbo.ChuyenXes", "Chi", c => c.Long());
            AlterColumn("dbo.ChuyenXes", "Thu", c => c.Long());
            AlterColumn("dbo.ChuyenXes", "SanPham", c => c.String());
            AlterColumn("dbo.ChuyenXes", "NoiTraHang", c => c.String());
            AlterColumn("dbo.ChuyenXes", "NoiNhanHang", c => c.String());
            AlterColumn("dbo.ChuyenXes", "SangChieu", c => c.String());
            AlterColumn("dbo.ChuyenXes", "KHId", c => c.Long());
            DropColumn("dbo.ChuyenXes", "PhiCD");
            CreateIndex("dbo.ChuyenXes", "KHId");
            AddForeignKey("dbo.ChuyenXes", "KHId", "dbo.KhachHangs", "KHId");
        }
    }
}
