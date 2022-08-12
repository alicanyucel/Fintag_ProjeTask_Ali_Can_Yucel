using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjeTask.Models
{
    public class Kullanici
    {
     
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Balance { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DTarih { get; set; }
        [Required]
        public List<BankaHesap> BankaHesap { get; set; }

    }
}
