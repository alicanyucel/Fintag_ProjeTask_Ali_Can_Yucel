using Microsoft.AspNetCore.Mvc;
using ProjeTask.Repo;

namespace ProjeTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankaHesapController : ControllerBase
    {
        private IRepository _apprepository;
        public BankaHesapController(IRepository repository)
        {
            _apprepository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var bankas = _apprepository.GetBankaHesap();

            return Ok(bankas);
        }
    }
}