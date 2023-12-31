namespace RapChieuPhim.Models
{
    using RapChieuPhim.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuann
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BinhLuann()
        {
            NoiDungs = new HashSet<NoiDungg>();
        }

        public int Id { get; set; }

        public int? IdPhim { get; set; }

        [Required(ErrorMessage = "Vui lòng đưa ra bình luận!")]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDang { get; set; }

        public bool TinhTrang { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm!")]
        public int DanhGia { get; set; }

        public virtual Phimm Phim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoiDungg> NoiDungs { get; set; }
    }
}
