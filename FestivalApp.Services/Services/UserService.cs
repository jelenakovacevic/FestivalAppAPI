using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FestivalApp.Services
{
    public class UserService
    {
        public IEnumerable<User> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Users.ToList();
            }
        }

        public User Get(int id)
        {
            using (var db = new DataContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Create(User user)
        {
            using (var db = new DataContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using (var db = new DataContext())
            {
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}