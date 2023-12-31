namespace RapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoann
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoann()
        {
            NoiDungs = new HashSet<NoiDungg>();
            Ves = new HashSet<Vee>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(60)]
        public string MatKhau { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDangKy { get; set; }

        public bool TinhTrang { get; set; }

        [Required]
        [StringLength(50)]
        public string PhanQuyen { get; set; }

        public int? id_ThongTin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoiDungg> NoiDungs { get; set; }

        public virtual ThongTinn ThongTin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vee> Ves { get; set; }
    }
}
