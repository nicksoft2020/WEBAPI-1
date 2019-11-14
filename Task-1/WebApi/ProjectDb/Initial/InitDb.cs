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
                        LastName = "Kravchenko",
                        Active = true
                    },
                    new User
                    {
                        Name = "Vika",
                        LastName = "Bovanenko",
                        Active = true
                    },
                    new User
                    {
                        Name = "Serhii",
                        LastName = "Belik",
                        Active = false
                    },
                    new User
                    {
                        Name = "Katia",
                        LastName = "Malovichko",
                        Active = false
                    },
                    new User
                    {
                        Name = "Nastya",
                        LastName = "Pilipenko",
                        Active = false
                    },
                    new User
                    {
                        Name = "Olya",
                        LastName = "Kramarenko",
                        Active = true
                    },
                    new User
                    {
                        Name = "Tanya",
                        LastName = "Kravchenko",
                        Active = true
                    },
                    new User
                    {
                        Name = "Viktor",
                        LastName = "Muhailenko",
                        Active = false
                    },
                    new User
                    {
                        Name = "Vlad",
                        LastName = "Chipizenko",
                        Active = false
                    },
                    new User
                    {
                        Name = "Vlada",
                        LastName = "Ovdienko",
                        Active = false
                    }
                    );
                db.SaveChanges();
            }
        }
    }
}