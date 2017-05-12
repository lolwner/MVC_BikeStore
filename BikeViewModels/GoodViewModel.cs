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
        public string Good_ID { get; set; }
        public string Manufacturer_ID { get; set; }
        public string Type_ID { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public IEnumerable<Manufacturer> ManufacturerVM { get; set; }
        public IEnumerable<BikeEntities.Type> TypeVM { get; set; }

    }
}
