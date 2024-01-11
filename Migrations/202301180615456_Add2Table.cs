namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add2Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChamCongs",
                c => new
                    {
                        ChamCongID = c.Long(nullable: false, identity: true),
                        NgayThang = c.DateTime(nullable: false),
                        TXId = c.Long(),
                        Luong = c.Long(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ChamCongID)
                .ForeignKey("dbo.TaiXes", t => t.TXId)
                .Index(t => t.TXId);
            
            CreateTable(
                "dbo.ChuyenXes",
                c => new
                    {
                        CXID = c.Long(nullable: false, identity: true),
                        KHId = c.Long(),
                        NgayThang = c.DateTime(nullable: false),
                        SangChieu = c.String(),
                        NoiNhanHang = c.String(),
                        NoiTraHang = c.String(),
                        SanPham = c.String(),
                        DonGia = c.Long(nullable: false),
                        KhoiLuongHH = c.Single(nullable: false),
                        ThanhTien = c.Long(nullable: false),
                        TienConLai = c.Long(),
                        TienCamDi = c.Long(nullable: false),
                        TienDoDau = c.Long(nullable: false),
                        TienCA = c.Long(nullable: false),
                        TienAn = c.Long(nullable: false),
                        TienThuocNuoc = c.Long(nullable: false),
                        BoiDuong = c.Long(nullable: false),
                        LamHang = c.Long(nullable: false),
                        DenNuoc = c.Long(nullable: false),
                        PhatSinhThem = c.Long(nullable: false),
                        Thu = c.Long(),
                        Chi = c.Long(),
                        Tong = c.Long(),
                    })
                .PrimaryKey(t => t.CXID)
                .ForeignKey("dbo.KhachHangs", t => t.KHId)
                .Index(t => t.KHId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChuyenXes", "KHId", "dbo.KhachHangs");
            DropForeignKey("dbo.ChamCongs", "TXId", "dbo.TaiXes");
            DropIndex("dbo.ChuyenXes", new[] { "KHId" });
            DropIndex("dbo.ChamCongs", new[] { "TXId" });
            DropTable("dbo.ChuyenXes");
            DropTable("dbo.ChamCongs");
        }
    }
}
