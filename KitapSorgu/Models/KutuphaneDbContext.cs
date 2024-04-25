using Microsoft.EntityFrameworkCore;
namespace KitapSorgu.Models
{
   public class KutuphaneDbContext : DbContext
    {
        string baglanti = "Server=(localdb)\\mssqllocaldb;Database=KutuphaneDb;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(baglanti);
        }
        public DbSet<Kitap> Kitaplar { get; set; }
    }
}
