using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FestivalApp.Services
{
    public class FestivalService
    {
        public IEnumerable<Festival> GetAll()
        {
            using (var db = new FestivalAppDB())
            {
                return db.Festivals.ToList();
            }
        }

        public Festival Get(int id)
        {
            using (var db = new FestivalAppDB())
            {
                return db.Festivals.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Create(Festival festival)
        {
            using (var db = new FestivalAppDB())
            {
                db.Festivals.Add(festival);
                db.SaveChanges();
            }
        }

        public void Update(Festival festival)
        {
            using (var db = new FestivalAppDB())
            {
                db.Festivals.AddOrUpdate(festival);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new FestivalAppDB())
            {
                var festival = db.Festivals.FirstOrDefault(x => x.Id == id);
                db.Festivals.Remove(festival);
                db.SaveChanges();               
            }
        }
    }
}
