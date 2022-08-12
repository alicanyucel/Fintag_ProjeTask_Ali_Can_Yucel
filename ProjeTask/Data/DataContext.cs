using Microsoft.EntityFrameworkCore;
using ProjeTask.Models;

namespace ProjeTask.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Kullanici> Kullanicilar { get; set; }//veri tabanına values adında tablo oluşturur
        public DbSet<BankaHesap> BankaHesaplari { get; set; }
        public DbSet<Fiyat> Fiyatlar { get; set; }
    }
}
