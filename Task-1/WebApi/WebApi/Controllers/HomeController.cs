using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is a class which manages application
    /// </summary>
    [Route("api/users")]
    public class HomeController : Controller
    {
        private IUnitOfWork repository;    // Repository value.
        private ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor for HomeController.
        /// </summary>
        /// <param name="iunit">object of repository</param>
        public HomeController(IUnitOfWork _repository, ILogger<HomeController> logger)
        {
            repository = _repository;
            _logger = logger;
        }

        /// <summary>
        /// Getting the flist of users from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersList()
        {
            try
            {
                IEnumerable<User> users = await repository.Users.GetAllAsync();
                _logger.LogInformation("GetUsersList action.", users);
                return users;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    await repository.Users.Update(user);
                    _logger.LogInformation("UpdatingUser action!");
                    return Ok(user);
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
            return BadRequest(ModelState);
        }
    }
}