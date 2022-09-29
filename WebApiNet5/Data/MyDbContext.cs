using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;

namespace WebApiNet5.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        #region
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiet { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.ToTable("DonHang");
                entity.HasKey(dh => dh.MaDh);
                entity.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("DonHangChiTiet");
                entity.HasKey(e => new { e.MaDh, e.MaHh});

                entity.HasOne(e => e.DonHang)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaDh)
                .HasConstraintName("FK_DonHangCT_DonHang");

                 entity.HasOne(e => e.HangHoa)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaHh)
                .HasConstraintName("FK_DonHangCT_HangHoa");
            });


        }
    }
}
