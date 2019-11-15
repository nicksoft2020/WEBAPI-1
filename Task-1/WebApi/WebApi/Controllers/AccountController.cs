using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
//using System.Web.Http;
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
        private readonly AuthOntions options;

        public AccountController(IUnitOfWork unit, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IOptions<AuthOntions> appSettings)
        {
            if(unit != null)
            {
                repository = unit;
            }
            else
            {
                throw new NullReferenceException();
            }
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
                var result = await userManager.CreateAsync(user, model.Password);   // adding new user to database
                if (result.Succeeded)
                {
                    await repository.Users.Create(userData); 
                    return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new Response
            { 
                Status = "Error", 
                Message = "Invalid Data." 
            };
        }

        /// <summary>
        /// For user login. 
        /// </summary>
        /// <param name="model">user's data</param>
        /// <returns>the object of Responce class.</returns>
        [HttpPost]
        [Route("LoginUser")]
        public async Task<Response> Login([System.Web.Http.FromBody]LoginModel model)
        {
            //var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            //if (result.Succeeded)
            var user = await userManager.FindByNameAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                    //var user = await userManager.FindByNameAsync(model.Email);
                    ///
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("UserID",user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    string token = tokenHandler.WriteToken(securityToken);
                    ///
                    User user1 = repository.Users.Find(user => user.Email == model.Email).FirstOrDefault();
                    return new Response { Status = "Success", Message = token };
                }
                return new Response { Status = "Invalid", Message = "Invalid User." };
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