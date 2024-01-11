using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CTY_DVVT.Models
{
    public class BaoCaoXe
    {
        [Key]
        public long BCXId { get; set; }
        [Required(ErrorMessage = "Ngày tháng không được để trống")]
        public System.DateTime NgayThang { get; set; }
        [Required(ErrorMessage = "Tên xe không được để trống")]
        public long XeId { get; set; }
        [Required(ErrorMessage = "Điền 0 nếu để trống")]
        public long Tien { get; set; }
        [Required(ErrorMessage = "Báo cáo không được để trống")]
        public string GhiChu { get; set; }
        public virtual Xe Xe { get; set; }
    }
}