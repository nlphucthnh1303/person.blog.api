// Controllers/UsersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonBlogApi.Models.Users;
using PersonBlogApi.Repositories.Interfaces;

namespace PersonBlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger; // Để logging

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // sp_Users_Create
        // sp_Users_Delete
        // sp_Users_GetByEmail
        // sp_Users_GetById
        // sp_Users_GetByUsername
        // sp_Users_SetEmailConfirmed
        // sp_Users_UpdatePassword


        [HttpPost("Create")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreate_Req request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newUser = await _userService.UserCreate_Req(request);
                return Ok(new { userId = newUser });
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }


        /// <summary>
        /// </summary>
        [HttpDelete("Delete")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var success = await _userService.UserDelete_Req(userId);
                if (success)
                {
                    return Ok(success);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to delete user." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = ex.Message });
            }

        }

        [HttpGet("GetUserById/{userId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound(new { message = $"User with ID {userId} not found." });
            }
            return Ok(user);
        }

        [HttpGet("GetUserByEmail/{email}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound(new { message = $"User with email {email} not found." });
            }
            return Ok(user);
        }

        [HttpGet("GetUserByUsername/{userName}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _userService.GetUserByUsername(userName);
            if (user == null)
            {
                return NotFound(new { message = $"User with username {userName} not found." });
            }
            return Ok(user);
        }


        /// <summary>
        /// Đổi mật khẩu người dùng (chỉ chính user đó).
        /// </summary>
        [HttpPut("UpdateUserPassword")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UserUpdatePassword_Req request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var success = await _userService.UpdateUserPassword(request.userId, request.newPasswordHash);
                if (success)
                {
                    return Ok(new { message = "Password updated successfully." });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to update password." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

        }

    
        [HttpPut("UpdateEmailConfirmed")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateEmailConfirmed([FromBody] UserUpdateEmailConfirm_Req request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var success = await _userService.SetEmailConfirmed(request.userId, request.IsEmailConfirmed);
                if (success)
                {
                    return Ok(new { message = "Password updated successfully." });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to update password." });
            }
            catch (Exception ex)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
            
        }
       
        
    }
}