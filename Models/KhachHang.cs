using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CTY_DVVT.Models
{
    public class KhachHang
    {
        [Key]
        public long KHId { get; set; }
        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        public string KHName { get; set; }
        [Required(ErrorMessage = "SĐT không được để trống")]
        public string KHSdt { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string KHDiaChi { get; set; }
    }
}