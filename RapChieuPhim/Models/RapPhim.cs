namespace RapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RapPhim")]
    public partial class RapPhimm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RapPhimm()
        {
            Phongs = new HashSet<Phongg>();
            Ves = new HashSet<Vee>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TenRapChieu { get; set; }

        public int TongSoPhong { get; set; }

        public string ThanhPho { get; set; }

        public string QuanHuyen { get; set; }

        public string PhuongXa { get; set; }

        public string KhungGio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phongg> Phongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vee> Ves { get; set; }
    }
}
