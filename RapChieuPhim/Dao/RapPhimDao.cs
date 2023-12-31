using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapChieuPhim.Dao
{
    public class RapPhimDao
    {
        private DBcontext db = new DBcontext();
        public RapPhimm GetRapPhimFindByID(int id)
        {
            return db.RapPhims.Find(id);
        }
    }
}