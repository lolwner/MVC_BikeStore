using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Models.Store
{
    public class GoodViewModel
    {
        public int Good_ID { get; set; }
        public int Manufacturer_ID { get; set; }
        public int Type_ID { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public IEnumerable<Manufacturer> ManufacturerVM { get; set; }
        public IEnumerable<Type> TypeVM { get; set; }
    }
}