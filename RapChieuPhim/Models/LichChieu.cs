namespace RapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichChieu")]
    public partial class LichChieuu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichChieuu()
        {
            Ves = new HashSet<Vee>();
        }

        public int Id { get; set; }

        public int? IdPhong { get; set; }

        public DateTime NgayChieu { get; set; }

        [Required]
        [StringLength(50)]
        public string GioBatDau { get; set; }

        [Required]
        [StringLength(50)]
        public string GioKetThuc { get; set; }

        public int? IdPhim { get; set; }

        public virtual Phimm Phim { get; set; }

        public virtual Phongg Phong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vee> Ves { get; set; }
    }
}
