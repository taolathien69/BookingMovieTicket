using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RapChieuPhim.ViewModel
{
    public class BinhLuanViewModel
    {
        public string NguoiDung { get; set; }
        public int Id { get; set; }
        public int? IdPhim { get; set; } // ?ây là ki?u int? trong model g?c, nên b?n c?n ph?i th? hi?n ?úng nó ? ?ây
        [Required(ErrorMessage = "Vui lòng ??a ra bình lu?n!")]
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
        public bool TinhTrang { get; set; }
        [Required(ErrorMessage = "Vui lòng nh?p ?i?m!")]
        public int DanhGia { get; set; }
    }

    // M?t l?p d?ch v? ho?c repository ?? l?y bình lu?n
    public class BinhLuanService
    {
        public List<BinhLuanViewModel> GetBinhLuans()
        {
            List<BinhLuanViewModel> binhLuanViewModels = new List<BinhLuanViewModel>();

            using (var context = new DBcontext()) // Thay th? 'DBcontext' b?ng tên th?c t? c?a context c?a b?n
            {
                var binhLuans = context.BinhLuans.Take(1000).ToList();
                foreach (var bl in binhLuans)
                {
                    binhLuanViewModels.Add(new BinhLuanViewModel
                    {
                        Id = bl.Id,
                        IdPhim = bl.IdPhim ?? 0, // S? d?ng toán t? ?? ?? x? lý giá tr? null
                        NoiDung = bl.NoiDung,
                        NgayDang = bl.NgayDang,
                        TinhTrang = bl.TinhTrang,
                        DanhGia = bl.DanhGia
                    });
                }
            }

            return binhLuanViewModels;
        }
    }
}
