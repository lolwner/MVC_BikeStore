using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDataAccess
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext db;

        public UserRepository()
        {
            db = new ApplicationDbContext();
        }

        public IdentityUser GetUser(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<IdentityUser> GetUserList()
        {
            return db.Users.ToList();
        }
    }
}
