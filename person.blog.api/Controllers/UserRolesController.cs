// Controllers/UsersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonBlogApi.Models.Users;
using PersonBlogApi.Services.Interfaces;

namespace PersonBlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        private readonly ILogger<UserRolesController> _logger; // Để logging

    public  UserRolesController(IUserRoleService userRoleService, ILogger<UserRolesController> logger)
        {
            _userRoleService = userRoleService;
            _logger = logger;
        }

        // sp_UserRoles_Add
        // sp_UserRoles_GetByUserId
        // sp_UserRoles_GetPermissionsByUserId
        // sp_UserRoles_Remove

        [HttpPost("Add")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUserRole([FromBody] int userId, int roleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newUserRole = await _userRoleService.UserRoleAdd(userId, roleId);
                return Ok(newUserRole);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

    }
}