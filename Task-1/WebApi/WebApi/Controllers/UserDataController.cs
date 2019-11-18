using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private IUnitOfWork repository;
        private UserManager<IdentityUser> _userManager;
        public UserDataController(UserManager<IdentityUser> userManager, IUnitOfWork _repository)
        {
            _userManager = userManager;
            repository = _repository;
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

            if (userId == null) return BadRequest("User not found");

            IdentityUser user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.Email
            };
        }

    }
}