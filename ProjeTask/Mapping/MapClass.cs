using AutoMapper;
using ProjeTask.Dtos;
using ProjeTask.Models;

namespace ProjeTask.Mapping

{
    public class MapClass:Profile
    {
        public MapClass()
        {
            CreateMap<UserDto,Kullanici>().ReverseMap();
            CreateMap<BankaHesapDto,BankaHesap>().ReverseMap();

        }
    }
}
