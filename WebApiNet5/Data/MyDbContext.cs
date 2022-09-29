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
        #endregion
    }
}
