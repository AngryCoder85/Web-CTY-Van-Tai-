using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CTY_DVVT.Models
{
    public class LoaiXe
    {
        [Key]
        public long LXID { get; set; }
        [Required(ErrorMessage = "Tên loại xe không được để trống")]
        public string LXName { get; set; }
    }
}