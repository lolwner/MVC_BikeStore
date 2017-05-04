using BikeEntities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDataAccess
{
    public interface IGoodRepository
    {
        IEnumerable<Good> GetGoodList();
        Good GetGood(int? id);
        IEnumerable<Manufacturer> GetManufacturersList();
        IEnumerable<BikeEntities.Type> GetTypesList();
        void CreateGood(Good item);
        void Update(Good item);
        void Delete(int id);
        void Save();
    }

    public interface IUserRepository
    {
        IdentityUser GetUser(int id);
        IEnumerable<IdentityUser> GetUserList();
    }

}
