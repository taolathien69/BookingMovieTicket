using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapChieuPhim.Dao
{
    public class LichChieuDao
    {
        private DBcontext db = new DBcontext();
        public LichChieuu GetLichChieuFindByID(int id)
        {
            return db.LichChieux.Find(id);
        }

        public LichChieuu UpdateLichChieu(LichChieuu lichChieu)
        {
            LichChieuu lich = db.LichChieux.Add(lichChieu);
            db.SaveChanges();
            return lich;
        }
    }
}