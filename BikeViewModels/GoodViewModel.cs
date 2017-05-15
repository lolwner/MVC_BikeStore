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
        public string GoodId { get; set; }
        public string ManufacturerId { get; set; }
        public string TypeId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public IEnumerable<Manufacturer> ManufacturerVM { get; set; }
        public IEnumerable<BikeEntities.Type> TypeVM { get; set; }

    }
}
