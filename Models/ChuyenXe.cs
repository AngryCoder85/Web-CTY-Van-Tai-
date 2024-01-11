using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTY_DVVT.Models
{
    public class ChuyenXe
    {
        [Key]
        public long CXID { get; set; }
        [Required(ErrorMessage = "Khách hàng không được để trống")]
        public Nullable<long> KHId { get; set; }
        [Required(ErrorMessage = "Tài xế không được để trống")]
        public Nullable<long> TXId { get; set; }
        public System.DateTime NgayThang { get; set; }
        [Required(ErrorMessage = "Thời điểm không được để trống")]
        public string SangChieu { get; set; }
        [Required(ErrorMessage = "Nơi nhận không được để trống")]
        public string NoiNhanHang { get; set; }
        [Required(ErrorMessage = "Nơi trả không được để trống")]
        public string NoiTraHang { get; set; }
        [Required(ErrorMessage = "Sản phẩm không được để trống")]
        public string SanPham { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long DonGia { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public string KhoiLuongHH { get; set; }
        public long ThanhTien { get; set; }
        //public long TienConLai { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long TienCamDi { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long TienConLaiCT { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long TienSuaXe { get; set; }
        public string GhiChuSX { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long TienDoDau { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long PhiCD { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long TienCA { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long TienAn { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long TienThuocNuoc { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long BoiDuong { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long LamHang { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long DenNuoc { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu để trống")]
        public long PhatSinhThem { get; set; }
        public long Thu { get; set; }
        [Required]
        public long Chi { get; set; }
        [Required]
        public long Tong { get; set; }

        public virtual KhachHang KhachHang { get; set; }
        public virtual TaiXe TaiXe { get; set; }
    }
}