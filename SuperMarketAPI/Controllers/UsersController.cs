using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMarketAPI.Domain.Services;
using SuperMarketAPI.Models;
using SuperMarketAPI.Resources.Response;
using SuperMarketAPI.Resources.Save;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperMarketAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IEnumerable<UserResource> Get()
        {
            var users = _userService.GetAll();
            var resources = _mapper.Map <IEnumerable<UserResource>>(users);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var currentUserId = int.Parse(User.Identity.Name);
            if(id != currentUserId && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }

            var result = await _userService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resource = _mapper.Map<UserResource>(result.User);

            return Ok(resource);

        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateResource resource)
        {
            var result = await _userService.Authenticate(resource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var response = _mapper.Map<UserResource>(result.User);

            return Ok(response);

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
