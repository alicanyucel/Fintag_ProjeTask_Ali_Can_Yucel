using ProjeTask.Models;
using System;

namespace ProjeTask.Dtos
{
    public class UserDto
    {
       public string Name { get; set; }
        public DateTime DTarih { get; set; }
        public int Id { get; set; }
        public Decimal Balance { get; set; }
       
    }
}
