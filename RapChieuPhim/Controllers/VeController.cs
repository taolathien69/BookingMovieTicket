using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RapChieuPhim.Areas.Admin.Controllers;
using RapChieuPhim.Dao;
using RapChieuPhim.Models;
using RapChieuPhim.Models.Payments;
using RapChieuPhim.ViewModel;
using VNPAY_CS_ASPX;

namespace RapChieuPhim.Controllers
{
    public class VeController : BaseController
    {

        private DBcontext db = new DBcontext();
        private string hashSecret = ConfigurationManager.AppSettings["HashSecret"];

        // GET: Ve
        public ActionResult Index(int id)
        {
            var dao = new PhimDao();
            PhimViewModel phimmodel = dao.getPhimFindbyId(id);
            Session.Add("PHIM", phimmodel);
            ViewData["listCinema"] = db.RapPhims.ToList();
            ViewData["listChair"] = db.Ghes.ToList();
            ViewData["Showtimes"] = db.LichChieux.ToList();
            ViewData["phimmodel"] = phimmodel;

            return View();
        }

        public ActionResult Create(string username, string email, string showtimes, string chair, string cinema, string numberchair, string payment)
        {
            int idLC = Int32.Parse(showtimes);
            int idRap = Int32.Parse(cinema);
            int idGe = Int32.Parse(chair);
            int soluong = Int32.Parse(numberchair);
            Session.Add("IDG", idGe);
            var phims = (PhimViewModel)Session["PHIM"];
            var user = (TaiKhoann)Session["USERSESSIO"];
            var rapphim = new RapPhimDao().GetRapPhimFindByID(idRap);

            var vedao = new VeDao();
            var lichDao = new LichChieuDao();
            var gheDao = new GheDao();
            LichChieuu lichChieu = lichDao.GetLichChieuFindByID(idLC);
            lichChieu.IdPhim = phims.Id;
            lichDao.UpdateLichChieu(lichChieu);
            Ghee ghe = gheDao.GetGheFindByID(idGe);
            Vee ve = new Vee();
            ve.IdRap = idRap;
            ve.IdTaiKhoan = user.Id;
            ve.Id_LichChieu = lichChieu.Id;
            ve.Soluong = soluong;
            ve.NgayDat = DateTime.Now;

            // Tính toán giá vé dựa trên loại ghế
            // ...
            decimal giaGhe = ghe.LoaiGhe.GiaGhe != null ? (decimal)ghe.LoaiGhe.GiaGhe : 0;
            ve.GiaVe = soluong * giaGhe;

            Vee saveVe = vedao.SaveVe(ve);
            ghe.Id_Ve = saveVe.Id;
            ghe.TringTrang = true;
            gheDao.UpdateGhe(ghe);
            ViewData["phimmodel"] = phims;
            ViewData["VeData"] = saveVe;
            ViewData["lichChieu"] = lichChieu;
            ViewData["Ghe"] = ghe;
            ViewData["RAP"] = rapphim;
            var url = Payment();
            return url;
        }


        public ActionResult Payment()
        {
            string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"];
            string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"];
            string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"];
            string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"];

            OrderInfo order = new OrderInfo();
            order.OrderId = DateTime.Now.Ticks;

            var ve = (Vee)ViewData["VeData"];
            var ghe = (Ghee)ViewData["Ghe"];

            // Tính toán giá vé dựa trên loại ghế
            decimal giaGhe = ghe.LoaiGhe.GiaGhe != null ? (decimal)ghe.LoaiGhe.GiaGhe : 0;

            order.Amount = (int)(ve.Soluong * giaGhe);

            order.Status = "0";
            order.CreatedDate = DateTime.Now;

            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());
            vnpay.AddRequestData("vnp_BankCode", "");
            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.OrderId);
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);

            ViewData["VeData"] = ve; // Add ve variable to ViewData for later access

            return Redirect(paymentUrl);
        }


        private string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public ActionResult PaymentConfirm(string vnp_Amount, string vnp_ResponseCode, string vnp_TxnRef, string vnp_TransactionNo, string vnp_OrderInfo, string vnp_SecureHash)
        {
            string hashSecret = ConfigurationManager.AppSettings["HashSecret"];
            string inputHashData = string.Format("vnp_Amount={0}&vnp_OrderInfo={1}&vnp_ResponseCode={2}&vnp_TxnRef={3}&vnp_TransactionNo={4}", vnp_Amount, vnp_OrderInfo, vnp_ResponseCode, vnp_TxnRef, vnp_TransactionNo);
            string secureHash = CalculateMD5Hash(inputHashData + hashSecret);

            if (secureHash.Equals(vnp_SecureHash, StringComparison.OrdinalIgnoreCase))
            {
                if (vnp_ResponseCode == "00")
                {
                    string successMessage = string.Format("Payment successful for order: {0}", vnp_OrderInfo);
                    return RedirectToAction("Success", new { message = successMessage });
                }
                else
                {
                    string errorMessage = string.Format("Payment error for order: {0}, Error code: {1}", vnp_OrderInfo, vnp_ResponseCode);
                    return RedirectToAction("Error", new { message = errorMessage });
                }
            }
            else
            {
                string errorMessage = string.Format("Payment hash verification failed for order: {0}", vnp_OrderInfo);
                return RedirectToAction("Error", new { message = errorMessage });
            }
        }

        public ActionResult Success()
        {
            return View();
        }
        public ActionResult History()
        {
            var tai = (RapChieuPhim.Models.TaiKhoann)Session["USERSESSIO"];

            // Ví dụ: Lấy danh sách vé của người dùng đó
            var ves = db.Ves.Include(v => v.LichChieu)
                    .Include(v => v.RapPhim)
                    .Include(v => v.TaiKhoan)
                    .Where(v => v.IdTaiKhoan == tai.Id)
                    .OrderByDescending(v => v.NgayDat) // Sắp xếp theo NgayDat từ gần đây nhất
                    .ToList();

            return View(ves);
        }
    }
}
