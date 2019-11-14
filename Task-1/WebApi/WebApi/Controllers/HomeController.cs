using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is a class which manages application
    /// </summary>
    [Route("api/users")]
    //[System.Web.Http.Route("api/[controller]")]
    //[ApiController]
    public class HomeController : Controller
    {
        private IUnitOfWork repository;    // Repository value.

        /// <summary>
        /// Constructor for HomeController.
        /// </summary>
        /// <param name="iunit">object of repository</param>
        public HomeController(IUnitOfWork iunit)
        {
            if (iunit != null)
            {
                repository = iunit;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Adding new user to repository.
        /// </summary>
        /// <param name="user">ne user's object.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                await repository.Users.Create(user);
                return Ok(user);
            }
            return BadRequest(user);
        }

        /// <summary>
        /// Getting the flist of users from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersList()
        {
            List<User> users = (List<User>)await repository.Users.GetAllAsync();
            return users;
        }

        /// <summary>
        /// Updating user in database.
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="user">user's value</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatingUser(int id, [FromBody]User user)   //???FormBody
        {
            if (ModelState.IsValid)
            {
                await repository.Users.Update(user);
                return Ok(user);
            }
            return BadRequest(ModelState);
        }
    }
}