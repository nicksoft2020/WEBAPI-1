using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.JWT;

namespace WebApi.Controllers
{
    /// <summary>
    /// This class manages users
    /// </summary>
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private IUnitOfWork repository;
        private readonly ApplicationSettings options;

        public AccountController(IUnitOfWork _repository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IOptions<ApplicationSettings> appSettings)
        {
            repository = _repository;
            options = appSettings.Value;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        /// <summary>
        /// Registration of new user
        /// </summary>
        /// <param name="model">user data</param>
        /// <returns>Response object</returns>
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<object> RegisterUser([FromBody]RegisterModel model)
        {
            try
            {
                IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Email };
                User userData = new User { LastName = model.LastName, Email = model.Email, Name = model.Name, Active = false };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);   // adding new user to database
                if (result.Succeeded)
                {
                    await repository.Users.Create(userData);
                    return Ok("SuccessFully Saved.");
                }
            }
            catch (Exception)
            {
            }
            return BadRequest("Invalid Data.");
        }

        /// <summary>
        /// For user login. 
        /// </summary>
        /// <param name="model">user's data</param>
        /// <returns>the object of Responce class.</returns>
        [HttpPost]
        [Route("LoginUser")]
        public async Task<Object> Login([FromBody]LoginModel model)
        {

            var user = await userManager.FindByNameAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {

                string token = GenerateToken.CreateToken(options, user);
                return Ok(new { token });
            }
            return BadRequest(new { message = "There is not valid email of password!" });
        }

        /// <summary>
        /// Logoff user
        /// </summary>
        /// <returns>Responce object.</returns>
        [HttpGet]
        [Route("LogoutUser")]
        public async Task<Response> Logout()
        {
            await signInManager.SignOutAsync();
            return new Response { Status = "Success" };
        }

    }
}