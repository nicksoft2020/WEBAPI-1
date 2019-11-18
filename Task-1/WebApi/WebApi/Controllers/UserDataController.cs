using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        public UserDataController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Getting data from database with helping JWT token.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProfile")]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.Email,
                user.UserName
            };
        }

    }
}