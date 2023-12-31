namespace RapChieuPhim.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaiKhoanViewModel
    {
        [Key]
        [Column(Order = 0)]
        public string TenDangNhap { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(60)]
        public string MatKhau { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime NgayDangKy { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool TinhTrang { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string PhanQuyen { get; set; }

        public string TenNguoiDung { get; set; }

        [Key]
        [Column(Order = 5)]
        public string DiaChi { get; set; }

        [Key]
        [Column(Order = 6)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime NgaySinh { get; set; }
    }
}
