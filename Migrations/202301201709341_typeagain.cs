namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typeagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChuyenXes", "DonGia", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "KhoiLuongHH", c => c.String(nullable: false));
            AlterColumn("dbo.ChuyenXes", "ThanhTien", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "TienConLai", c => c.Long());
            AlterColumn("dbo.ChuyenXes", "TienCamDi", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "TienDoDau", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "PhiCD", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "TienCA", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "TienAn", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "TienThuocNuoc", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "BoiDuong", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "LamHang", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "DenNuoc", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "PhatSinhThem", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "Thu", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "Chi", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "Tong", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChuyenXes", "Tong", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "Chi", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "Thu", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "PhatSinhThem", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "DenNuoc", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "LamHang", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "BoiDuong", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "TienThuocNuoc", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "TienAn", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "TienCA", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "PhiCD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "TienDoDau", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "TienCamDi", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "TienConLai", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "ThanhTien", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ChuyenXes", "KhoiLuongHH", c => c.String());
            AlterColumn("dbo.ChuyenXes", "DonGia", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
