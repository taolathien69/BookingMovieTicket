using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace RapChieuPhim.Models
{
    [Table("BaiViet")]
    public class TinTuc
    {
        [Key]
        public int BaiVietID { get; set; }

        [Required]
        [StringLength(255)]
        public string TieuDe { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [StringLength(255)]
        public string TomTat { get; set; }

        public DateTime NgayDang { get; set; }

        [StringLength(100)]
        public string TacGia { get; set; }

        [StringLength(100)]
        public string DanhMuc { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(255)]
        public string URLHinhAnh { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        public int LuotXem { get; set; }
    }
}