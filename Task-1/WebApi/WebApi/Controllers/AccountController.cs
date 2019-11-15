using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
//using System.Web.Http;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        public AccountController(IUnitOfWork unit, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            if(unit != null)
            {
                repository = unit;
            }
            else
            {
                throw new NullReferenceException();
            }
            
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
                if (ModelState.IsValid)
                {
                    IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Email };
                    User userData = new User { LastName = model.LastName, Email = model.Email, Name = model.Name, Active = false };
                    var result = await userManager.CreateAsync(user, model.Password);   // adding new user to database
                    if (result.Succeeded)
                    {
                        await repository.Users.Create(userData); 
                        //await signInManager.SignInAsync(user, false);
                        return new Response
                        { Status = "Success", Message = "SuccessFully Saved." };
                    }
                    
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
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    User user = repository.Users.Find(user => user.Email == model.Email).FirstOrDefault();
                    return new Response { Status = "Success", Message = model.Email, FullName = user.LastName + " " + user.Name };
                }
                else
                {
                    return new Response { Status = "Invalid", Message = "Invalid User." };
                }

            }
            return new Response { Status = "Invalid", Message = "Invalid email of password!" };
        }
    }
}