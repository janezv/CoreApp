using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    // link: hostIP /api/users
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IDatingRepository _repo { get; }
        public UsersController(IDatingRepository repo)
        {
            _repo = repo;
        }

        // link: hostIP /api/Users   -- ker ni [Route]
        [HttpGet]
        public async Task<IActionResult> getUsers()
        {
            var users = await _repo.GetUsers();
            return Ok(users);
        }

        // link: hostIP /api/Users /2   -- ker ni [Route]
        [HttpGet("{id}")]
        public async Task<IActionResult> getUser(int id)
        {
            var user = await _repo.GetUser(id);
            return Ok(user);
        }


    }
}