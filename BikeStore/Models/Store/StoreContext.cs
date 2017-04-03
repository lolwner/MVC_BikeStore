using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BikeStore.Models.Store
{
    public class StoreContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ListOfGoods> ListsOfGoods { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}