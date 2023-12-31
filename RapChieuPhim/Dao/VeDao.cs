using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapChieuPhim.Dao
{
    public class VeDao
    {
        private DBcontext db = new DBcontext();
        public Vee GetLoaiPhimFindByID(int id)
        {
            return db.Ves.Find(id);
        }
        public Vee AddVe(Vee ve)
        {
            return null;
        }

        public Vee SaveVe(Vee ve)
        {
            try
            {
                Vee ves = db.Ves.Add(ve);
                db.SaveChanges();
                return ves;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
    }
}