namespace RapChieuPhim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BinhLuan",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IdPhim = c.Int(),
                    NoiDung = c.String(nullable: false),
                    NgayDang = c.DateTime(nullable: false, storeType: "date"),
                    TinhTrang = c.Boolean(nullable: false),
                    DanhGia = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Phim", t => t.IdPhim)
                .Index(t => t.IdPhim);

            CreateTable(
                "dbo.NoiDung",
                c => new
                {
                    id = c.Int(nullable: false),
                    Id_binhLuan = c.Int(),
                    Id_TaiKhoan = c.Int(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TaiKhoan", t => t.Id_TaiKhoan)
                .ForeignKey("dbo.BinhLuan", t => t.Id_binhLuan)
                .Index(t => t.Id_binhLuan)
                .Index(t => t.Id_TaiKhoan);

            CreateTable(
                "dbo.TaiKhoan",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenDangNhap = c.String(nullable: false),
                    MatKhau = c.String(nullable: false, maxLength: 60),
                    NgayDangKy = c.DateTime(nullable: false, storeType: "date"),
                    TinhTrang = c.Boolean(nullable: false),
                    PhanQuyen = c.String(nullable: false, maxLength: 50, unicode: false),
                    id_ThongTin = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ThongTin", t => t.id_ThongTin)
                .Index(t => t.id_ThongTin);

            CreateTable(
                "dbo.ThongTin",
                c => new
                {
                    ThongTin_id = c.Int(nullable: false),
                    TenNguoiDung = c.String(),
                    DiaChi = c.String(nullable: false, unicode: false),
                    GioiTinh = c.String(nullable: false),
                    NgaySinh = c.DateTime(nullable: false),
                    Email = c.String(maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => t.ThongTin_id);

            CreateTable(
                "dbo.Ve",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IdTaiKhoan = c.Int(),
                    IdRap = c.Int(),
                    NgayDat = c.DateTime(precision: 7, storeType: "datetime2"),
                    GiaVe = c.Decimal(precision: 18, scale: 2),
                    Id_LichChieu = c.Int(),
                    Soluong = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LichChieu", t => t.Id_LichChieu)
                .ForeignKey("dbo.RapPhim", t => t.IdRap)
                .ForeignKey("dbo.TaiKhoan", t => t.IdTaiKhoan)
                .Index(t => t.IdTaiKhoan)
                .Index(t => t.IdRap)
                .Index(t => t.Id_LichChieu);

            CreateTable(
                "dbo.Ghe",
                c => new
                {
                    ghe_id = c.Long(nullable: false),
                    Loai_id = c.Int(),
                    TringTrang = c.Boolean(nullable: false),
                    Id_phong = c.Int(),
                    Id_Ve = c.Int(),
                })
                .PrimaryKey(t => t.ghe_id)
                .ForeignKey("dbo.LoaiGhe", t => t.Loai_id)
                .ForeignKey("dbo.Phong", t => t.Id_phong)
                .ForeignKey("dbo.Ve", t => t.Id_Ve)
                .Index(t => t.Loai_id)
                .Index(t => t.Id_phong)
                .Index(t => t.Id_Ve);

            CreateTable(
                "dbo.LoaiGhe",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenLoaiGhe = c.String(nullable: false),
                    GiaGhe = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Phong",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IdRapChieu = c.Int(),
                    TenPhong = c.String(nullable: false),
                    SoLuong = c.Int(nullable: false),
                    TrinhTrang = c.Boolean(nullable: false),
                    MoTa = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RapPhim", t => t.IdRapChieu)
                .Index(t => t.IdRapChieu);

            CreateTable(
                "dbo.LichChieu",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IdPhong = c.Int(),
                    NgayChieu = c.DateTime(nullable: false),
                    GioBatDau = c.String(nullable: false, maxLength: 50, unicode: false),
                    GioKetThuc = c.String(nullable: false, maxLength: 50, unicode: false),
                    IdPhim = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Phim", t => t.IdPhim)
                .ForeignKey("dbo.Phong", t => t.IdPhong)
                .Index(t => t.IdPhong)
                .Index(t => t.IdPhim);

            CreateTable(
                "dbo.Phim",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenPhim = c.String(nullable: false),
                    AnhPhim = c.String(nullable: false),
                    ThoiLuong = c.Int(nullable: false),
                    MoTa = c.String(),
                    TinhTrang = c.Boolean(nullable: false),
                    IdLoaiPhim = c.Int(nullable: false),
                    DienVien = c.String(nullable: false),
                    DaoDien = c.String(nullable: false, unicode: false),
                    NgayCongChieu = c.DateTime(nullable: false),
                    NgayKetThuc = c.DateTime(nullable: false),
                    NamPhatHanh = c.String(maxLength: 50, unicode: false),
                    ChatLuong = c.String(maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoaiPhim", t => t.IdLoaiPhim)
                .Index(t => t.IdLoaiPhim);

            CreateTable(
                "dbo.DanhMuc",
                c => new
                {
                    id = c.Int(nullable: false),
                    TenDanhMuc = c.String(nullable: false, maxLength: 50, unicode: false),
                    id_Phim = c.Int(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Phim", t => t.id_Phim)
                .Index(t => t.id_Phim);

            CreateTable(
                "dbo.LoaiPhim",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenLoai = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.RapPhim",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenRapChieu = c.String(nullable: false, maxLength: 50),
                    TongSoPhong = c.Int(nullable: false),
                    ThanhPho = c.String(),
                    QuanHuyen = c.String(),
                    PhuongXa = c.String(),
                    KhungGio = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.NoiDung", "Id_binhLuan", "dbo.BinhLuan");
            DropForeignKey("dbo.Ve", "IdTaiKhoan", "dbo.TaiKhoan");
            DropForeignKey("dbo.Ghe", "Id_Ve", "dbo.Ve");
            DropForeignKey("dbo.Ve", "IdRap", "dbo.RapPhim");
            DropForeignKey("dbo.Phong", "IdRapChieu", "dbo.RapPhim");
            DropForeignKey("dbo.LichChieu", "IdPhong", "dbo.Phong");
            DropForeignKey("dbo.Ve", "Id_LichChieu", "dbo.LichChieu");
            DropForeignKey("dbo.Phim", "IdLoaiPhim", "dbo.LoaiPhim");
            DropForeignKey("dbo.LichChieu", "IdPhim", "dbo.Phim");
            DropForeignKey("dbo.DanhMuc", "id_Phim", "dbo.Phim");
            DropForeignKey("dbo.BinhLuan", "IdPhim", "dbo.Phim");
            DropForeignKey("dbo.Ghe", "Id_phong", "dbo.Phong");
            DropForeignKey("dbo.Ghe", "Loai_id", "dbo.LoaiGhe");
            DropForeignKey("dbo.TaiKhoan", "id_ThongTin", "dbo.ThongTin");
            DropForeignKey("dbo.NoiDung", "Id_TaiKhoan", "dbo.TaiKhoan");
            DropIndex("dbo.DanhMuc", new[] { "id_Phim" });
            DropIndex("dbo.Phim", new[] { "IdLoaiPhim" });
            DropIndex("dbo.LichChieu", new[] { "IdPhim" });
            DropIndex("dbo.LichChieu", new[] { "IdPhong" });
            DropIndex("dbo.Phong", new[] { "IdRapChieu" });
            DropIndex("dbo.Ghe", new[] { "Id_Ve" });
            DropIndex("dbo.Ghe", new[] { "Id_phong" });
            DropIndex("dbo.Ghe", new[] { "Loai_id" });
            DropIndex("dbo.Ve", new[] { "Id_LichChieu" });
            DropIndex("dbo.Ve", new[] { "IdRap" });
            DropIndex("dbo.Ve", new[] { "IdTaiKhoan" });
            DropIndex("dbo.TaiKhoan", new[] { "id_ThongTin" });
            DropIndex("dbo.NoiDung", new[] { "Id_TaiKhoan" });
            DropIndex("dbo.NoiDung", new[] { "Id_binhLuan" });
            DropIndex("dbo.BinhLuan", new[] { "IdPhim" });
            DropTable("dbo.RapPhim");
            DropTable("dbo.LoaiPhim");
            DropTable("dbo.DanhMuc");
            DropTable("dbo.Phim");
            DropTable("dbo.LichChieu");
            DropTable("dbo.Phong");
            DropTable("dbo.LoaiGhe");
            DropTable("dbo.Ghe");
            DropTable("dbo.Ve");
            DropTable("dbo.ThongTin");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.NoiDung");
            DropTable("dbo.BinhLuan");
        }
    }
}
