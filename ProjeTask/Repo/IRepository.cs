using ProjeTask.Dtos;
using ProjeTask.Models;
using System.Collections.Generic;

namespace ProjeTask.Repo
{
    public interface IRepository
    {

        List<Fiyat> GetFiyatAll();
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();
        List<BankaHesapDto> GetBankaHesap();
        List<UserDto> GetUsers();
        void Update<T>(T entity) where T : class;
    }
}
