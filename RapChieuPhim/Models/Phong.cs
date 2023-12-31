namespace RapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phongg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phongg()
        {
            Ghes = new HashSet<Ghee>();
            LichChieux = new HashSet<LichChieuu>();
        }

        public int Id { get; set; }

        public int? IdRapChieu { get; set; }

        [Required]
        public string TenPhong { get; set; }

        public int SoLuong { get; set; }

        public bool TrinhTrang { get; set; }

        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ghee> Ghes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichChieuu> LichChieux { get; set; }

        public virtual RapPhimm RapPhim { get; set; }
    }
}
