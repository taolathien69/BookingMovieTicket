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
        public int? IdPhim { get; set; } // ?�y l� ki?u int? trong model g?c, n�n b?n c?n ph?i th? hi?n ?�ng n� ? ?�y
        [Required(ErrorMessage = "Vui l�ng ??a ra b�nh lu?n!")]
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
        public bool TinhTrang { get; set; }
        [Required(ErrorMessage = "Vui l�ng nh?p ?i?m!")]
        public int DanhGia { get; set; }
    }

    // M?t l?p d?ch v? ho?c repository ?? l?y b�nh lu?n
    public class BinhLuanService
    {
        public List<BinhLuanViewModel> GetBinhLuans()
        {
            List<BinhLuanViewModel> binhLuanViewModels = new List<BinhLuanViewModel>();

            using (var context = new DBcontext()) // Thay th? 'DBcontext' b?ng t�n th?c t? c?a context c?a b?n
            {
                var binhLuans = context.BinhLuans.Take(1000).ToList();
                foreach (var bl in binhLuans)
                {
                    binhLuanViewModels.Add(new BinhLuanViewModel
                    {
                        Id = bl.Id,
                        IdPhim = bl.IdPhim ?? 0, // S? d?ng to�n t? ?? ?? x? l� gi� tr? null
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
