using Microsoft.AspNetCore.Mvc;
using ProjeTask.Models;
using ProjeTask.Repo;

namespace ProjeTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IRepository _apprepository;
        public UserController(IRepository repository)
        {
            _apprepository = repository;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Kullanici user)
        {
            // 201 data eklendi http kodu 200 basarılı
            try
            {
                _apprepository.Add(user);

                return Ok(user);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet]
        public IActionResult Get()
        {
            var users = _apprepository.GetUsers();

            return Ok(users);
        }

    }
}
