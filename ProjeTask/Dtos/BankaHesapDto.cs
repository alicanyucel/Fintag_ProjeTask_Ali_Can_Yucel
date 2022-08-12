using ProjeTask.Models;

namespace ProjeTask.Dtos
{
    public class BankaHesapDto
    {
        public int BankaHesapId { get; set; }
        public long EuroHesap { get; set; }
        public long SterlinHesap { get; set; }
        public long DolarHesap { get; set; }
        public int KullaniciId { get; set; }


    }
}
