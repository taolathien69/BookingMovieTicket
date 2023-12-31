using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RapChieuPhim.Dao
{
    public class TinTucDao
    {
        private readonly DBcontext _context;

        public TinTucDao(DBcontext context)
        {
            _context = context;
        }

        public List<TinTuc> LayTatCaTinTuc()
        {
            return _context.TinTucs.ToList();
        }

        // Thêm các phương thức khác nếu cần
    }
}
