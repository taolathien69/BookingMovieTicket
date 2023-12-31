using RapChieuPhim.Dao;
using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCrypt.Net;

namespace RapChieuPhim.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        [HttpPost]
public ActionResult Login(string username, string password)
{
    var dao = new TaiKhoanDao();
    TaiKhoann taiKhoan = dao.checkTaikhoan(username, password);

    if (taiKhoan != null)
    {
        if (taiKhoan.TinhTrang)
        {
            // Tài khoản hợp lệ và hoạt động, lưu vào phiên (session)
            Session["USERSESSIO"] = taiKhoan;
            return Json(new { success = true });
        }
        else
        {
            // Tài khoản không hoạt động
            return Json(new { success = false, message = "inactive" });
        }
    }

    // Tài khoản không hợp lệ
    return Json(new { success = false, message = "invalid" });
}

        [HttpPost]
        public ActionResult Register(string username, string email, string password)
        {
            var dao = new TaiKhoanDao();

            // Kiểm tra xem email đã tồn tại trong cơ sở dữ liệu chưa
            if (dao.IsEmailExists(email))
            {
                return Json(new { success = false, message = "Email đã được sử dụng" });
            }

            // Tiếp tục tiến trình đăng ký nếu email không trùng
            var daoTT = new ThongTinDao();

            TaiKhoann taiKhoan = new TaiKhoann();
            ThongTinn thongTin = new ThongTinn();
            thongTin.TenNguoiDung = username;
            thongTin.NgaySinh = DateTime.Now;
            thongTin.Email = email;
            ThongTinn ttsave = daoTT.SaveTT(thongTin);
            taiKhoan.TenDangNhap = email;
            taiKhoan.MatKhau = password;
            taiKhoan.TinhTrang = true;
            taiKhoan.NgayDangKy = DateTime.Now;
            taiKhoan.PhanQuyen = "USER";
            taiKhoan.id_ThongTin = ttsave.ThongTin_id;
            dao.SaveTaiKhoan(taiKhoan);

            return Json(new { success = true, message = "Đăng ký thành công" });
        }

        public ActionResult Logout(string username, string email, string password)
        {

            Session.RemoveAll();

            return Redirect("/Home");

        }

    }
}