using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    //[Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
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
        //[Route("api/account/RegisterUser")]
        public async Task<object> RegisterUser([FromBody]RegisterModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Email };
                    var result = await userManager.CreateAsync(user, model.Password);   // adding new user to database
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
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
            { Status = "Error", Message = "Invalid Data." };
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
                    return new Response { Status = "Success", Message = model.Email };
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