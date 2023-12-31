using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RapChieuPhim.Models
{
    public partial class DBcontext : DbContext
    {
        public DBcontext()
            : base("name=DBcontext")
        {
        }

        public virtual DbSet<BinhLuann> BinhLuans { get; set; }
        public virtual DbSet<DanhMucc> DanhMucs { get; set; }
        public virtual DbSet<Ghee> Ghes { get; set; }
        public virtual DbSet<LichChieuu> LichChieux { get; set; }
        public virtual DbSet<LoaiGhee> LoaiGhes { get; set; }
        public virtual DbSet<LoaiPhimm> LoaiPhims { get; set; }
        public virtual DbSet<NoiDungg> NoiDungs { get; set; }
        public virtual DbSet<Phimm> Phims { get; set; }
        public virtual DbSet<Phongg> Phongs { get; set; }
        public virtual DbSet<RapPhimm> RapPhims { get; set; }
        public virtual DbSet<TaiKhoann> TaiKhoans { get; set; }
        public virtual DbSet<ThongTinn> ThongTins { get; set; }
        public virtual DbSet<Vee> Ves { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuann>()
                .HasMany(e => e.NoiDungs)
                .WithOptional(e => e.BinhLuan)
                .HasForeignKey(e => e.Id_binhLuan);

            modelBuilder.Entity<DanhMucc>()
                .Property(e => e.TenDanhMuc)
                .IsUnicode(false);

            modelBuilder.Entity<LichChieuu>()
                .Property(e => e.GioBatDau)
                .IsUnicode(false);

            modelBuilder.Entity<LichChieuu>()
                .Property(e => e.GioKetThuc)
                .IsUnicode(false);

            modelBuilder.Entity<LichChieuu>()
                .HasMany(e => e.Ves)
                .WithOptional(e => e.LichChieu)
                .HasForeignKey(e => e.Id_LichChieu);

            modelBuilder.Entity<LoaiGhee>()
                .HasMany(e => e.Ghes)
                .WithOptional(e => e.LoaiGhe)
                .HasForeignKey(e => e.Loai_id);

            modelBuilder.Entity<LoaiPhimm>()
                .HasMany(e => e.Phims)
                .WithRequired(e => e.LoaiPhim)
                .HasForeignKey(e => e.IdLoaiPhim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phimm>()
                .Property(e => e.DaoDien)
                .IsUnicode(false);

            modelBuilder.Entity<Phimm>()
                .Property(e => e.NamPhatHanh)
                .IsUnicode(false);

            modelBuilder.Entity<Phimm>()
                .Property(e => e.ChatLuong)
                .IsUnicode(false);

            modelBuilder.Entity<Phimm>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.Phim)
                .HasForeignKey(e => e.IdPhim);

            modelBuilder.Entity<Phimm>()
                .HasMany(e => e.DanhMucs)
                .WithOptional(e => e.Phim)
                .HasForeignKey(e => e.id_Phim);

            modelBuilder.Entity<Phimm>()
                .HasMany(e => e.LichChieux)
                .WithOptional(e => e.Phim)
                .HasForeignKey(e => e.IdPhim);

            modelBuilder.Entity<Phongg>()
                .HasMany(e => e.Ghes)
                .WithOptional(e => e.Phong)
                .HasForeignKey(e => e.Id_phong);

            modelBuilder.Entity<Phongg>()
                .HasMany(e => e.LichChieux)
                .WithOptional(e => e.Phong)
                .HasForeignKey(e => e.IdPhong);

            modelBuilder.Entity<RapPhimm>()
                .HasMany(e => e.Phongs)
                .WithOptional(e => e.RapPhim)
                .HasForeignKey(e => e.IdRapChieu);

            modelBuilder.Entity<RapPhimm>()
                .HasMany(e => e.Ves)
                .WithOptional(e => e.RapPhim)
                .HasForeignKey(e => e.IdRap);

            modelBuilder.Entity<TaiKhoann>()
                .Property(e => e.PhanQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoann>()
                .HasMany(e => e.NoiDungs)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.Id_TaiKhoan);

            modelBuilder.Entity<TaiKhoann>()
                .HasMany(e => e.Ves)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoan);

            modelBuilder.Entity<ThongTinn>()
                .Property(e => e.DiaChi)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinn>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinn>()
                .HasMany(e => e.TaiKhoans)
                .WithOptional(e => e.ThongTin)
                .HasForeignKey(e => e.id_ThongTin);

            modelBuilder.Entity<Vee>()
                .HasMany(e => e.Ghes)
                .WithOptional(e => e.Ve)
                .HasForeignKey(e => e.Id_Ve);

        }

        public System.Data.Entity.DbSet<RapChieuPhim.ViewModel.VeViewModel> VeViewModels { get; set; }
    }
}
