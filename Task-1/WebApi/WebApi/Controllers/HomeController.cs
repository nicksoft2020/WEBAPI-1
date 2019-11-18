using System;
using System.Collections.Generic;
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
    public class HomeController : Controller
    {
        private IUnitOfWork repository;    // Repository value.

        /// <summary>
        /// Constructor for HomeController.
        /// </summary>
        /// <param name="iunit">object of repository</param>
        public HomeController(IUnitOfWork _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Getting the flist of users from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersList()
        {
            IEnumerable<User> users = await repository.Users.GetAllAsync();
            return users;
        }

        /// <summary>
        /// Updating user in database.
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="user">user's value</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdatingUser([FromBody]User user)   
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