// Controllers/UsersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonBlogApi.Models.UserProfiles;
using PersonBlogApi.Services.Interfaces;

namespace PersonBlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly ILogger<UsersController> _logger;

        public UserProfilesController(IUserProfileService userProfileService, ILogger<UsersController> logger)
        {
            _userProfileService = userProfileService;
            _logger = logger;
        }

        // sp_UserProfiles_Create
        // sp_UserProfiles_GetByUserId
        // sp_UserProfiles_Update
        // sp_UserProfiles_UpdateUserId



        [HttpPost("Create")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUserProfiles([FromBody] UserProfileCreate_Req request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newUserProfile = await _userProfileService.UserProfileCreate(request);
                return Ok(new { userProfileId = newUserProfile });
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }



        [HttpDelete("Delete")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUserProfiles(int userProfileId)
        {
            try
            {
                var success = await _userProfileService.UserProfileDelete(userProfileId);
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
        public async Task<IActionResult> GetUserProfilesById(int userId)
        {
            var userProfile = await _userProfileService.UserProfileGetByUserId(userId);
            if (userProfile == null)
            {
                return NotFound(new { message = $"User with userProfile not found." });
            }
            return Ok(userProfile);
        }

        [HttpPut("Update")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserProfile(UserProfileUpdate_Req req)
        {
            try
            {
                var success = await _userProfileService.UserProfileUpdate(req);
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

        [HttpPut("UpdateUserProfileByUserId")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserProfileByUserId(UserProfileUpdateUserId_Req req)
        {
            try
            {
                var success = await _userProfileService.UserProfileUpdateUserId(req);
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
        
    }
}