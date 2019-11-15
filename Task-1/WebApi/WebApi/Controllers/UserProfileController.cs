using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        public UserProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetProfile")]
        //GET : /api/UserProfile
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