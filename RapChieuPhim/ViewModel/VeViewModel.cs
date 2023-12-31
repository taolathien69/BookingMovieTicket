namespace RapChieuPhim.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VeViewModel
    {
        public string TenNguoiDung { get; set; }

        [Key]
        [Column(Order = 0)]
        public string DiaChi { get; set; }

        [Key]
        [Column(Order = 1)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string TenRapChieu { get; set; }

        public string ThanhPho { get; set; }

        public string QuanHuyen { get; set; }

        public string PhuongXa { get; set; }

        [Key]
        [Column(Order = 3)]
        public string TenDangNhap { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayDat { get; set; }

        public decimal? GiaVe { get; set; }

        public int? Soluong { get; set; }
        public int? Id_Ghe { get; set; }
        public string TenGhe { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime NgayChieu { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string GioBatDau { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string GioKetThuc { get; set; }

        [Key]
        [Column(Order = 7)]
        public string TenLoaiGhe { get; set; }

        [Key]
        [Column(Order = 8)]
        public string TenPhong { get; set; }
    }
}
