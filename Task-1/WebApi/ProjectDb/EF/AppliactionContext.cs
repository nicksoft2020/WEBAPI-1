using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDb.EF
{
    /// <summary>
    /// This is a database context.
    /// With helping of this class we can 
    /// work with data in database
    /// </summary>
    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<User> UsersInfo { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
