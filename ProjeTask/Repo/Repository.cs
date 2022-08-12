using AutoMapper;
using ProjeTask.Data;
using ProjeTask.Dtos;
using ProjeTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjeTask.Repo
{
    public class Repository : IRepository
    {
        private IMapper _mapper;
        private DataContext _context;
        public Repository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add<T>(T entity) where T : class
        {
            
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<BankaHesapDto> GetBankaHesap()
        {
            var bankaList = _context.BankaHesaplari.ToList();

            var bankas = _mapper.Map<List<BankaHesapDto>>(bankaList);

            return bankas;
        }

        public List<Fiyat> GetFiyatAll()
        {
            var fiyat = _context.Fiyatlar.ToList();

            return fiyat;
        }

        public List<UserDto> GetUsers()
        {
            var userList = _context.Kullanicilar.ToList();

            var users = _mapper.Map<List<UserDto>>(userList);

            return users;

        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
