using System.ComponentModel.DataAnnotations;

namespace ProjeTask.Models
{
    public class BankaHesap
    {
       
        
        public int BankaHesapId { get; set; }
        
        public long EuroHesap { get; set; }
       
        public long DolarHesap { get; set; }
        
        public long SterlinHesap { get; set; }
      
        public  int  KullaniciId { get; set; }
    }
}
