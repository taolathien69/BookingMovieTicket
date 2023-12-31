namespace RapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoiDung")]
    public partial class NoiDungg
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? Id_binhLuan { get; set; }

        public int? Id_TaiKhoan { get; set; }

        public virtual BinhLuann BinhLuan { get; set; }

        public virtual TaiKhoann TaiKhoan { get; set; }
    }
}
