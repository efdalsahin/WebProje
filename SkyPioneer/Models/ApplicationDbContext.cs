using Microsoft.EntityFrameworkCore;

namespace SkyPioneer.Models
{
    public class ApplicationDbContext:DbContext
    {
        private const string ConnectionString = "" +
    "Server=EFDAL;" +
    "Database=SkyPioneer;" +
    "User Id=sa;Password=efdal1020;" +
    "TrustServerCertificate=True;";





       


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConnectionString);
        }

        public DbSet<HavaAlani> HavaAlanlari { get; set; }
        public DbSet<HavaYolu> HavaYollari { get; set; }
        public DbSet<Kullanici> Kullancilar { get; set; }
        public DbSet<Ucak> Ucaklar { get; set; }
        public DbSet<Ucus> Ucuslar { get; set; }
        public DbSet<Bilet> Biletler { get; set; }
    }
}
