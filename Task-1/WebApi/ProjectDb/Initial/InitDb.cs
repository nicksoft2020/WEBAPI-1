using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProjectDb.EF;
using Domain.Entities;

namespace ProjectDb.Initial
{
    public sealed class InitDb
    {
        public static void Initial(ApplicationContext db)
        {
            if (!db.Users.Any())
            {
                db.UsersInfo.AddRange(
                    new User
                    {
                        Name = "Kolia",
                        Active = true
                    },
                    new User
                    {
                        Name = "Vika",
                        Active = true
                    },
                    new User
                    {
                        Name = "Serhii",
                        Active = false
                    },
                    new User
                    {
                        Name = "Katia",
                        Active = false
                    },
                    new User
                    {
                        Name = "Nastya",
                        Active = false
                    },
                    new User
                    {
                        Name = "Olya",
                        Active = true
                    },
                    new User
                    {
                        Name = "Tanya",
                        Active = true
                    },
                    new User
                    {
                        Name = "Viktor",
                        Active = false
                    },
                    new User
                    {
                        Name = "Vlad",
                        Active = false
                    },
                    new User
                    {
                        Name = "Vlada",
                        Active = false
                    }
                    );
                db.SaveChanges();
            }
        }
    }
}