using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CTY_DVVT.Models
{
    public class ChamCong
    {
        [Key]
        public long ChamCongID { get; set; }
        public System.DateTime NgayThang { get; set; }
        [Required(ErrorMessage = "Tài xế không được để trống")]
        public Nullable<long> TXId { get; set; }
        public long Luong { get; set; }
        public string GhiChu { get; set; }
        
        public virtual TaiXe TaiXe { get; set; }
    }
}