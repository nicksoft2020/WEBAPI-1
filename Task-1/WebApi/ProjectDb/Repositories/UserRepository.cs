using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectDb.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDb.Repositories
{
    /// <summary>
    /// This repository works with users in database
    /// </summary>
    public sealed class UserRepository : IRepository<User>
    {
        private ApplicationContext db;  // Database context.

        public UserRepository(ApplicationContext context)
        {
            if (context != null)
            {
                db = context;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Creating data.
        /// </summary>
        /// <param name="item">new item</param>
        /// <returns>true if item was createdd aele returns false</returns>
        public async Task<bool> Create(User item)
        {
            if(item != null)
            {
                await db.UsersInfo.AddAsync(item);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Finding the list of items with predicate.
        /// </summary>
        /// <param name="predicate">boolean condition.</param>
        /// <returns>the list of items with predicate.</returns>
        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.UsersInfo.Where(predicate).ToList();
        }

        /// <summary>
        /// Getting users
        /// </summary>
        /// <returns>Users</returns>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await db.UsersInfo.ToListAsync();
        }

        /// <summary>
        /// Updating data
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> Update(User item)
        {
            if (item != null)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
