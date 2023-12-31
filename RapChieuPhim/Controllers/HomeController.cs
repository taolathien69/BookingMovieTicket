using RapChieuPhim.Dao;
using RapChieuPhim.Models;
using RapChieuPhim.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RapChieuPhim.Controllers
{
    public class HomeController : Controller
    {
        private PhimDao daoP = new PhimDao();
        public ActionResult Index()
        {
            List<PhimViewModel> list = daoP.GetListPhims();
            ViewData["TopView"] = list;
            List<PhimViewModel> listHD = daoP.GetListPhimsByHanhDong();
            List<PhimViewModel> listDC = daoP.GetListPhimsByDC();
            List<PhimViewModel> listHH = daoP.GetListPhimsByHoatHinh();
            List<PhimViewModel> listKD = daoP.GetListPhimsByKinhDi();
            //List<PhimViewModel> listHDSC = daoP.GetListPhimsByHanhDongSC();
            //List<PhimViewModel> listDCSC = daoP.GetListPhimsByDCSC();
            //List<PhimViewModel> listHHSC = daoP.GetListPhimsByHoatHinhSC();
            //List<PhimViewModel> listKDSC = daoP.GetListPhimsByKinhDiSC();
            ViewData["HanhDong"] = listHD;
            ViewData["listDC"] = listDC;
            ViewData["listHH"] = listHH;
            ViewData["listKD"] = listKD;
            ViewData["HanhDongSC"] = listHD;
            ViewData["listDCSC"] = listDC;
            ViewData["listHHSC"] = listHH;
            ViewData["listKDSC"] = listKD;
            DBcontext db = new DBcontext();
            List<Ghee> lisssst = db.Ghes.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private readonly TinTucDao _tinTucDao;

        public HomeController()
        {
            _tinTucDao = new TinTucDao(new DBcontext());
        }

        public ActionResult TinTuc()
        {
            var danhSachTinTuc = _tinTucDao.LayTatCaTinTuc();
            return View(danhSachTinTuc);
        }

    }
}