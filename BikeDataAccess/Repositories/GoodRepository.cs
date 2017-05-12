using BikeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDataAccess.Repositories
{
    public class GoodRepository : Base.BaseRepository<Good> 
    {
        public GoodRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
