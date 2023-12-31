using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapChieuPhim.Dao
{
    public class LoaiGheDao
    {
        private DBcontext db = new DBcontext();
        public LoaiGhee GetLoaiGheFindByID(int id)
        {
            return db.LoaiGhes.Find(id);
        }
    }
}