using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapChieuPhim.Dao
{
    public class LoaiPhimDao
    {
        private DBcontext db = new DBcontext();
        public LoaiPhimm GetLoaiPhimFindByID(int id)
        {
            return db.LoaiPhims.Find(id);
        }
    }
}