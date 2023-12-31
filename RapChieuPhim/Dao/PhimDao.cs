using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RapChieuPhim.Models;
using RapChieuPhim.ViewModel;
using PagedList;

namespace RapChieuPhim.Dao
{
    public class PhimDao

    {
        private DBcontext db = new DBcontext();



        public List<PhimViewModel> GetListPhims()
        {
            List<Phimm> phims = db.Phims.Include(p => p.LoaiPhim).ToList();
            List<PhimViewModel> list = new List<PhimViewModel>();
            foreach (var phim in phims)
            {
                PhimViewModel phimView = new PhimViewModel();
                phimView.Id = phim.Id;
                phimView.TenPhim = phim.TenPhim;
                phimView.AnhPhim = phim.AnhPhim;
                phimView.DaoDien = phim.DaoDien;
                phimView.DienVien = phim.DienVien;
                phimView.ChatLuong = phim.ChatLuong;
                phimView.NgayCongChieu = phim.NgayCongChieu;
                phimView.NamPhatHanh = phim.NamPhatHanh;
                phimView.NgayKetThuc = phim.NgayKetThuc;
                phimView.TenLoai = phim.LoaiPhim.TenLoai;
                phimView.ThoiLuong = phim.ThoiLuong;
                phimView.TinhTrang = phim.TinhTrang;
                phimView.MoTa = phim.MoTa;
                list.Add(phimView);
            }
            return list;

        }

        public PhimViewModel getPhimFindbyId(int? id)
        {
            Phimm phim = db.Phims.Find(id);
            if (phim == null)
            {
                // Handle the situation where the phim object is null
                return null;
            }

            PhimViewModel phimView = new PhimViewModel();
            phimView.Id = phim.Id;
            phimView.TenPhim = phim.TenPhim;
            phimView.AnhPhim = phim.AnhPhim;
            phimView.DaoDien = phim.DaoDien;
            phimView.DienVien = phim.DienVien;
            phimView.ChatLuong = phim.ChatLuong;
            phimView.NgayCongChieu = phim.NgayCongChieu;
            phimView.NamPhatHanh = phim.NamPhatHanh;
            phimView.NgayKetThuc = phim.NgayKetThuc;
            phimView.TenLoai = phim.LoaiPhim.TenLoai;
            phimView.ThoiLuong = phim.ThoiLuong;
            phimView.TinhTrang = phim.TinhTrang;
            phimView.MoTa = phim.MoTa;
            return phimView;
        }


        public List<PhimViewModel> GetListPhimsByHanhDong()
        {
            List<Phimm> phims = db.Phims.Include(p => p.LoaiPhim).Where(l => l.IdLoaiPhim == 1).ToList();
            List<PhimViewModel> list = new List<PhimViewModel>();
            foreach (var phim in phims)
            {
                PhimViewModel phimView = new PhimViewModel();
                phimView.Id = phim.Id;
                phimView.TenPhim = phim.TenPhim;
                phimView.AnhPhim = phim.AnhPhim;
                phimView.DaoDien = phim.DaoDien;
                phimView.DienVien = phim.DienVien;
                phimView.ChatLuong = phim.ChatLuong;
                phimView.NgayCongChieu = phim.NgayCongChieu;
                phimView.NamPhatHanh = phim.NamPhatHanh;
                phimView.NgayKetThuc = phim.NgayKetThuc;
                phimView.TenLoai = phim.LoaiPhim.TenLoai;
                phimView.ThoiLuong = phim.ThoiLuong;
                phimView.TinhTrang = phim.TinhTrang;
                phimView.MoTa = phim.MoTa;
                list.Add(phimView);
            }
            return list;

        }
        public List<PhimViewModel> GetListPhimsByDC()
        {
            List<Phimm> phims = db.Phims.Include(p => p.LoaiPhim).Where(l => l.IdLoaiPhim == 2).ToList();
            List<PhimViewModel> list = new List<PhimViewModel>();
            foreach (var phim in phims)
            {
                PhimViewModel phimView = new PhimViewModel();
                phimView.Id = phim.Id;
                phimView.TenPhim = phim.TenPhim;
                phimView.AnhPhim = phim.AnhPhim;
                phimView.DaoDien = phim.DaoDien;
                phimView.DienVien = phim.DienVien;
                phimView.ChatLuong = phim.ChatLuong;
                phimView.NgayCongChieu = phim.NgayCongChieu;
                phimView.NamPhatHanh = phim.NamPhatHanh;
                phimView.NgayKetThuc = phim.NgayKetThuc;
                phimView.TenLoai = phim.LoaiPhim.TenLoai;
                phimView.ThoiLuong = phim.ThoiLuong;
                phimView.TinhTrang = phim.TinhTrang;
                phimView.MoTa = phim.MoTa;
                list.Add(phimView);
            }
            return list;

        }
        public List<PhimViewModel> GetListPhimsByHoatHinh()
        {
            List<Phimm> phims = db.Phims.Include(p => p.LoaiPhim).Where(l => l.IdLoaiPhim == 3).ToList();
            List<PhimViewModel> list = new List<PhimViewModel>();
            foreach (var phim in phims)
            {
                PhimViewModel phimView = new PhimViewModel();
                phimView.Id = phim.Id;
                phimView.TenPhim = phim.TenPhim;
                phimView.AnhPhim = phim.AnhPhim;
                phimView.DaoDien = phim.DaoDien;
                phimView.DienVien = phim.DienVien;
                phimView.ChatLuong = phim.ChatLuong;
                phimView.NgayCongChieu = phim.NgayCongChieu;
                phimView.NamPhatHanh = phim.NamPhatHanh;
                phimView.NgayKetThuc = phim.NgayKetThuc;
                phimView.TenLoai = phim.LoaiPhim.TenLoai;
                phimView.ThoiLuong = phim.ThoiLuong;
                phimView.TinhTrang = phim.TinhTrang;
                phimView.MoTa = phim.MoTa;
                list.Add(phimView);
            }
            return list;

        }
        public List<PhimViewModel> GetListPhimsByKinhDi()
        {
            List<Phimm> phims = db.Phims.Include(p => p.LoaiPhim).Where(l => l.IdLoaiPhim == 4).ToList();
            List<PhimViewModel> list = new List<PhimViewModel>();
            foreach (var phim in phims)
            {
                PhimViewModel phimView = new PhimViewModel();
                phimView.Id = phim.Id;
                phimView.TenPhim = phim.TenPhim;
                phimView.AnhPhim = phim.AnhPhim;
                phimView.DaoDien = phim.DaoDien;
                phimView.DienVien = phim.DienVien;
                phimView.ChatLuong = phim.ChatLuong;
                phimView.NgayCongChieu = phim.NgayCongChieu;
                phimView.NamPhatHanh = phim.NamPhatHanh;
                phimView.NgayKetThuc = phim.NgayKetThuc;
                phimView.TenLoai = phim.LoaiPhim.TenLoai;
                phimView.ThoiLuong = phim.ThoiLuong;
                phimView.TinhTrang = phim.TinhTrang;
                phimView.MoTa = phim.MoTa;
                list.Add(phimView);
            }
            return list;

        }
        public List<PhimViewModel> GetListPhimsByHanhDongSC()
        {
            List<Phimm> phims = db.Phims.Include(p => p.LoaiPhim).Where(l => l.IdLoaiPhim == 1 && l.TinhTrang == false).ToList();
            List<PhimViewModel> list = new List<PhimViewModel>();
            foreach (var phim in phims)
            {
                PhimViewModel phimView = new PhimViewModel();
                phimView.Id = phim.Id;
                phimView.TenPhim = phim.TenPhim;
                phimView.AnhPhim = phim.AnhPhim;
                phimView.DaoDien = phim.DaoDien;
                phimView.DienVien = phim.DienVien;
                phimView.ChatLuong = phim.ChatLuong;
                phimView.NgayCongChieu = phim.NgayCongChieu;
                phimView.NamPhatHanh = phim.NamPhatHanh;
                phimView.NgayKetThuc = phim.NgayKetThuc;
                phimView.TenLoai = phim.LoaiPhim.TenLoai;
                phimView.ThoiLuong = phim.ThoiLuong;
                phimView.TinhTrang = phim.TinhTrang;
                phimView.MoTa = phim.MoTa;
                list.Add(phimView);
            }
            return list;

        }
        public List<PhimViewModel> GetListPhimsByDCSC()
        {
            List<Phimm> phims = db.Phims.Include(p => p.LoaiPhim).Where(l => l.IdLoaiPhim == 2 && l.TinhTrang == false).ToList();
            List<PhimViewModel> list = new List<PhimViewModel>();
            foreach (var phim in phims)
            {
                PhimViewModel phimView = new PhimViewModel();
                phimView.Id = phim.Id;
                phimView.TenPhim = phim.TenPhim;
                phimView.AnhPhim = phim.AnhPhim;
                phimView.DaoDien = phim.DaoDien;
                phimView.DienVien = phim.DienVien;
                phimView.ChatLuong = phim.ChatLuong;
                phimView.NgayCongChieu = phim.NgayCongChieu;
                phimView.NamPhatHanh = phim.NamPhatHanh;
                phimView.NgayKetThuc = phim.NgayKetThuc;
                phimView.TenLoai = phim.LoaiPhim.TenLoai;
                phimView.ThoiLuong = phim.ThoiLuong;
                phimView.TinhTrang = phim.TinhTrang;
                phimView.MoTa = phim.MoTa;
                list.Add(phimView);
            }
            return list;

        }
        public List<PhimViewModel> GetListPhimsByHoatHinhSC()
        {
            List<Phimm> phims = db.Phims.Include(p => p.LoaiPhim).Where(l => l.IdLoaiPhim == 3 && l.TinhTrang == false).ToList();
            List<PhimViewModel> list = new List<PhimViewModel>();
            foreach (var phim in phims)
            {
                PhimViewModel phimView = new PhimViewModel();
                phimView.Id = phim.Id;
                phimView.TenPhim = phim.TenPhim;
                phimView.AnhPhim = phim.AnhPhim;
                phimView.DaoDien = phim.DaoDien;
                phimView.DienVien = phim.DienVien;
                phimView.ChatLuong = phim.ChatLuong;
                phimView.NgayCongChieu = phim.NgayCongChieu;
                phimView.NamPhatHanh = phim.NamPhatHanh;
                phimView.NgayKetThuc = phim.NgayKetThuc;
                phimView.TenLoai = phim.LoaiPhim.TenLoai;
                phimView.ThoiLuong = phim.ThoiLuong;
                phimView.TinhTrang = phim.TinhTrang;
                phimView.MoTa = phim.MoTa;
                list.Add(phimView);
            }
            return list;

        }
        public List<PhimViewModel> GetListPhimsByKinhDiSC()
        {
            List<Phimm> phims = db.Phims.Include(p => p.LoaiPhim).Where(l => l.IdLoaiPhim == 4 && l.TinhTrang == false).ToList();
            List<PhimViewModel> list = new List<PhimViewModel>();
            foreach (var phim in phims)
            {
                PhimViewModel phimView = new PhimViewModel();
                phimView.Id = phim.Id;
                phimView.TenPhim = phim.TenPhim;
                phimView.AnhPhim = phim.AnhPhim;
                phimView.DaoDien = phim.DaoDien;
                phimView.DienVien = phim.DienVien;
                phimView.ChatLuong = phim.ChatLuong;
                phimView.NgayCongChieu = phim.NgayCongChieu;
                phimView.NamPhatHanh = phim.NamPhatHanh;
                phimView.NgayKetThuc = phim.NgayKetThuc;
                phimView.TenLoai = phim.LoaiPhim.TenLoai;
                phimView.ThoiLuong = phim.ThoiLuong;
                phimView.TinhTrang = phim.TinhTrang;
                phimView.MoTa = phim.MoTa;
                list.Add(phimView);
            }
            return list;

        }
        public IEnumerable<Phimm> GetListPageListPhims(int page, int pageSize)
        {

            return db.Phims.OrderByDescending(p => p.Id).ToPagedList(page, pageSize);

        }
        public IEnumerable<Phimm> GetPhims()
        {
            return db.Phims.ToList();
        }
        public List<BinhLuanViewModel> GetBinhLuansForPhim(int phimId)
        {
            // Triển khai logic để lấy danh sách bình luận cho phim với Id là phimId.
            // Trả về danh sách BinhLuanViewModel tương ứng.
            var binhLuans = db.BinhLuans.Where(bl => bl.IdPhim == phimId).ToList();
            List<BinhLuanViewModel> binhLuanViewModels = new List<BinhLuanViewModel>();

            foreach (var bl in binhLuans)
            {
                binhLuanViewModels.Add(new BinhLuanViewModel
                {
                    Id = bl.Id,
                    IdPhim = bl.IdPhim,
                    NoiDung = bl.NoiDung,
                    NgayDang = bl.NgayDang,
                    TinhTrang = bl.TinhTrang,
                    DanhGia = bl.DanhGia
                });
            }

            return binhLuanViewModels;
        }
    }
}