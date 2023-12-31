using RapChieuPhim.Dao;
using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RapChieuPhim.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public String LoginAdmin(string username, string password)
        {
            var dao = new TaiKhoanDao();
            string check = "0"; 
            TaiKhoann taiKhoan = dao.checkTaikhoan(username, password);
            if (taiKhoan != null && taiKhoan.PhanQuyen.Equals("USER"))
            {
                check = "1";
                return check;
            }
            else if (taiKhoan != null && (taiKhoan.PhanQuyen.Equals("ADMIN") || taiKhoan.PhanQuyen.Equals("MANAGA")))
            {
                Session.Add("USERSESSIO", taiKhoan);
                check = "2";
                return check;
            }

            return check;


        }
    }
}