using System.Data;
using Microsoft.AspNetCore.Mvc;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.User;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpGet("/GetUser")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
        {
            return Ok(await _userService.GetAllAsync());
        }
        [HttpGet("/GetUser/{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("/AddUser")]
        public async Task<ActionResult<User>> AddAsync(CreateUserDto data)
        {
            try
            {
                var user = await _userService.AddAsync(data);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("/Login")]
        public async Task<ActionResult<User>> LoginAsync(UserLoginDTO data)
        {
            try
            {
                var user = await _userService.LoginAsync(data);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpPut("/UpdateUser")]
        public async Task<ActionResult<User>> UpdateAsync(UpdateUserDto data)
        {
            try
            {
                var user = await _userService.UpdateAsync(data);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("/DeleteUser")]
        public async Task<ActionResult<User>> SoftDeleteAsync(int id)
        {
            try
            {
                var user = await _userService.SoftDeleteAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
