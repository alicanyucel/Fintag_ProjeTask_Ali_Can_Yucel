using System.ComponentModel.DataAnnotations;
using System;
namespace ProjeTask.Models
{
    public class Fiyat
    {
  
        public int Id { get; set; }
        
        public string KurTipi { get; set; }
        
        public decimal KurAlis{ get; set; }
        
        public decimal Kursatis { get; set; }
       
        public DateTime KurTarihi { get; set; }
    }
}
