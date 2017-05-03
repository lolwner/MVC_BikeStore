using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeEntities;

namespace BikeViewModels
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
        public IEnumerable<BikeEntities.Type> TypeVM { get; set; }

    }
}
