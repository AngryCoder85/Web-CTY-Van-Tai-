using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CTY_DVVT.Models
{
    public class DVVTDBContext : DbContext
    {
        public DVVTDBContext() : base("DVVTConnectionString") { }
        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<TaiXe> taiXes { get; set; }
        public DbSet<ChuyenXe> ChuyenXes { get; set; }
        public DbSet<ChamCong> chamCongs { get; set; }
        public DbSet<HoaDonDo> hoaDonDos { get; set; }
        public DbSet<Xe> xes { get; set; }
        public DbSet<BaoCaoXe> BaoCaoXes { get; set; }
        public DbSet<LoaiXe> loaiXes { get; set; }
    }
}