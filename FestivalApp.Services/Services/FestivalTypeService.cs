using System;
using System.Collections.Generic;
using System.Linq;

namespace FestivalApp.Services
{
    public class FestivalTypeService
    {
        public IEnumerable<FestivalType> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.FestivalTypes.ToList();
            }
        }

        public FestivalType Get(int id)
        {
            using (var db = new DataContext())
            {
                return db.FestivalTypes.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Create(FestivalType festivalType)
        {
            using (var db = new DataContext())
            {
                db.FestivalTypes.Add(festivalType);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new DataContext())
            {
                var festivalType = db.FestivalTypes.FirstOrDefault(x => x.Id == id);
                db.FestivalTypes.Remove(festivalType);
                db.SaveChanges();
            }
        }

        public void AddToFavorites(int userId, int festivalTypeId)
        {
            using (var db = new DataContext())
            {
                var festivalType = db.FestivalTypes.FirstOrDefault(x => x.Id == festivalTypeId);
                var user = db.Users.FirstOrDefault(x => x.Id == userId);
                festivalType.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void RemoveFromFavorites(int userId, int festivalTypeId)
        {
            using (var db = new DataContext())
            {
                var festivalType = db.FestivalTypes.Include("Users").FirstOrDefault(x => x.Id == festivalTypeId);
                var user = db.Users.FirstOrDefault(x => x.Id == userId);
                festivalType.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public IEnumerable<FestivalType> GetFavorites(string username)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.Include("FestivalTypes").FirstOrDefault(x => x.Username == username);
                return user.FestivalTypes;
            }
        }
    }
}