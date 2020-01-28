using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
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
        private readonly IMapper _mapper;
        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // link: hostIP /api/Users   -- ker ni [Route]
        [HttpGet]
        public async Task<IActionResult> getUsers()
        {
            var users = await _repo.GetUsers();
            //da mapira pravilno smo naredili datoteko Helpers/AutoMapperProfile.cs
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users); // _mapper.Map<Source>(destination)
            return Ok(usersToReturn);
        }

        // link: hostIP /api/Users /2   -- ker ni [Route]
        [HttpGet("{id}")]
        public async Task<IActionResult> getUser(int id)
        {
            var user = await _repo.GetUser(id);
            //da mapira pravilno smo naredili datoteko Helpers/AutoMapperProfile.cs
            var userToReturn = _mapper.Map<UserForDetailedDto>(user); // _mapper.Map<Source>(destination) v je enako znakih je source v oklepajih destination
            return Ok(userToReturn);
        }


    }
}