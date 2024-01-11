using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CTY_DVVT.Models
{
    public class Xe
    {
        [Key]
        public long XeId { get; set; }
        [Required(ErrorMessage = "Loại xe không được để trống")]
        public long LXID { get; set; }
        [Required(ErrorMessage = "Biển số xe không được để trống")]
        public string BSXe { get; set; }
        public virtual LoaiXe LoaiXe { get; set; }
    }
}