using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CTY_DVVT.Models
{
    public class HoaDonDo
    {
        [Key]
        public long HoaDonDoID { get; set; }
        public System.DateTime NgayThang { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu bỏ trống")]
        public long HDXuat { get; set; }
        [Required(ErrorMessage = "Điền vào 0 nếu bỏ trống")]
        public long HDNhap { get; set; }
        public string GhiChu { get; set; }
    }
}