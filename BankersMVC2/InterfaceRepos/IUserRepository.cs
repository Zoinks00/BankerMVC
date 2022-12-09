using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankersMVC2.Models;

namespace BankersMVC2
{
   public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();

        //method to get Users id
        public User GetUsers(int id);

   }
}
