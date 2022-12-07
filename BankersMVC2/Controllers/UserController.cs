using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankersMVC2.Models;


namespace BankersMVC2.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository repo;

        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }
        //
        public IActionResult Index()
        {
            var user = repo.GetAllUsers();
            return View(user);
        }
        
        public IActionResult ViewUser(int id)
        {
            var user = repo.GetUsers(id);

            return View(user);
        }

    }
}
