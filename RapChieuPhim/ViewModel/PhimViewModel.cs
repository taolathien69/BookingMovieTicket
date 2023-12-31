using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace RapChieuPhim.ViewModel
{


    public partial class PhimViewModel
    {
        [Key]
        [Column(Order = 0)]
        public string TenPhim { get; set; }

        [Key]
        [Column(Order = 1)]
        public string AnhPhim { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ThoiLuong { get; set; }

        public string MoTa { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool TinhTrang { get; set; }

        [Key]
        [Column(Order = 5)]
        public string DienVien { get; set; }

        [Key]
        [Column(Order = 6)]
        public string DaoDien { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime NgayCongChieu { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime NgayKetThuc { get; set; }

        [StringLength(50)]
        public string NamPhatHanh { get; set; }

        [StringLength(50)]
        public string ChatLuong { get; set; }

        [Key]
        [Column(Order = 9)]
        public string TenLoai { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string TenDanhMuc { get; set; }
        public List<BinhLuanViewModel> BinhLuans { get; set; }
    }
}
