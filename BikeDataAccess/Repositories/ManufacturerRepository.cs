using BikeDataAccess.Base;
using BikeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDataAccess.Repositories
{
    public class ManufacturerRepository : Base.BaseRepository<Manufacturer>
    {
        public ManufacturerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
