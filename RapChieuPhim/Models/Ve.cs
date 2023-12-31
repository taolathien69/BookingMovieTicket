namespace RapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ve")]
    public partial class Vee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vee()
        {
            Ghes = new HashSet<Ghee>();
        }

        public int Id { get; set; }

        public int? IdTaiKhoan { get; set; }

        public int? IdRap { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayDat { get; set; }

        public decimal? GiaVe { get; set; }

        public int? Id_LichChieu { get; set; }

        public int? Soluong { get; set; }
        public int? Id_Ghe {  get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ghee> Ghes { get; set; }

        public virtual LichChieuu LichChieu { get; set; }

        public virtual RapPhimm RapPhim { get; set; }

        public virtual TaiKhoann TaiKhoan { get; set; }
    }
}
