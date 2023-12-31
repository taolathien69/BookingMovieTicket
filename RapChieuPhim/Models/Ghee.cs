namespace RapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("Ghe")]
    public partial class Ghee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ghe_id { get; set; }

        public int? Loai_id { get; set; }

        public bool TringTrang { get; set; }

        public int? Id_phong { get; set; }

        public int? Id_Ve { get; set; }
        public string TenGhe { get; set; }

        public virtual LoaiGhee LoaiGhe { get; set; }

        public virtual Phongg Phong { get; set; }

        public virtual Vee Ve { get; set; }


    }
}
