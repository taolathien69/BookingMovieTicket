using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RapChieuPhim.Dao
{
    public class GheDao
    {
        private DBcontext db = new DBcontext();
        public Ghee GetGheFindByID(int id)
        {
            return db.Ghes.Find(id);
        }
        public Ghee UpdateGhe(Ghee ghe)
        {
            db.Entry(ghe).State = EntityState.Modified;
            db.SaveChanges();

            return ghe;
        }
    }
}