//using BikeEntities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.Entity;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;

//namespace BikeDataAccess
//{
//    public class GoodRepository : IGoodRepository
//    {
//        private ApplicationDbContext db;

//        public GoodRepository()
//        {
//            db = new ApplicationDbContext();
//        }

//        public IEnumerable<Good> GetGoodList()
//        {
//            return db.Goods.ToList();
//        }

//        public Good GetGood(int? id)
//        {
//            return db.Goods.Find(id);
//        }

//        public IEnumerable<Manufacturer> GetManufacturersList()
//        {
//            return db.Manufacturers.ToList();
//        }

//        public IEnumerable<BikeEntities.Type> GetTypesList()
//        {
//            return db.Types.ToList();
//        }

//        public void CreateGood(Good good)
//        {
//            db.Goods.Add(good);
//        }

//        public void Update(Good good)
//        {
//            db.Entry(good).State = EntityState.Modified;
//        }

//        public void Delete(int id)
//        {
//            Good good = db.Goods.Find(id);
//            db.Goods.Remove(good);
//        }

//        public void Save()
//        {
//            db.SaveChanges();
//        }
//    }
//}
