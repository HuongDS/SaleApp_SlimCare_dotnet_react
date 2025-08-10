using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Others;
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
        public async Task<IActionResult> LoginAsync(UserLoginDTO data)
        {
            try
            {
                var res = await _userService.LoginAsync(data);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpPost("/Logout")]
        [AllowAnonymous]
        public async Task LogoutAsync([FromBody] RefreshTokenDto data)
        {
            Console.WriteLine("before logout");
            await _userService.Logout(data);
            Console.WriteLine("after logout");
        }
        [HttpPost("/LoginGoogle")]
        public async Task<ActionResult<ResponseDto>> LoginGoogleAsync([FromBody] GoogleLoginDto data)
        {
            try
            {
                var user = await _userService.LoginByGoogle(data);
                Console.WriteLine("Login Google success!");
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login Google fail!");
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
        [HttpPost("/RotateRefreshToken")]
        public async Task<ActionResult<ResponseDto>> RotateRefreshToken([FromBody] RefreshTokenDto refreshToken)
        {
            try
            {
                var res = await _userService.RotateRefreshToken(refreshToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
