using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankersMVC2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BankersMVC2.Data
{
    //inheritate from base DbContext for EntityFrameCore package
    public class UserContext : IdentityDbContext
    {
        //constructor that allows options to be passed using base class
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {

        }
        //add datasets using models for crud use
        //Users changed to UserAccount to prevent confusion of IdentityDbContext built-in class
        public  DbSet<User> UserAccount{ get; set;}
        //public DbSet<Balance> Balances { get; set; }
        //  public DbSet<Transaction> Transactions { get; set; }
               
    }
}
