using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FestivalApp.Services
{
    public class FestivalService
    {
        public IEnumerable<Festival> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Festivals.Include("Users").ToList();
            }
        }

        public Festival Get(int id)
        {
            using (var db = new DataContext())
            {
                return db.Festivals.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Create(Festival festival)
        {
            using (var db = new DataContext())
            {
                db.Festivals.Add(festival);
                db.SaveChanges();
            }
        }

        public void Update(Festival festival)
        {
            using (var db = new DataContext())
            {
                db.Festivals.AddOrUpdate(festival);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new DataContext())
            {
                var festival = db.Festivals.FirstOrDefault(x => x.Id == id);
                db.Festivals.Remove(festival);
                db.SaveChanges();
            }
        }
    }
}