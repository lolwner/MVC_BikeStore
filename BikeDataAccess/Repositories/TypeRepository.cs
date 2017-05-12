using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDataAccess.Repositories
{
    public class TypeRepository : Base.BaseRepository<BikeEntities.Type>
    {
        public TypeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
