using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CTY_DVVT.Models
{
    public class TaiXe
    {
        [Key]
        public long TXId { get; set; }
        [Required(ErrorMessage = "Biển số xe không được để trống")]
        public long XeId { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        public string TXName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string TXSdt { get; set; }

        public virtual Xe Xe { get; set; }
    }
}