using Dapper; // added to use sql quary statments
using System;
using System.Collections.Generic;
using System.Data; // added to us IDbConnection
using System.Linq;
using System.Threading.Tasks;
using BankersMVC2.Models; //ref models folders

namespace BankersMVC2
{
    public class UserRepository: IUserRepository
    {
        private readonly IDbConnection _conn;

        //constructor
        public UserRepository(IDbConnection conn)
        {
            //connector
            _conn = conn;
        }

        //method to get all users from database
        public IEnumerable<User> GetAllUsers()

        {//do query on data model
            return _conn.Query<User>("Select * FROM USER");
        }

        //method to get users based of id
        public User GetUsers(int id)
        {
            return _conn.QuerySingle<User>("SELECT * FROM USER WHERE IDUSER = @id",
               new { id = id });
        }

        /*//method to get balances for users
        public IEnumerable<Balance> GetAllBalances()
        {
            return _conn.Query<Balance>("SELECT * FROM BALANCE");
        }

       /* public Balance GetBalance (int id)
        {
            return _conn.QuerySingle<Balance>("SELECT * FROM BALANCE WHERE IDBALANCE = @id",
               new { id = id });
        }
        //assign values from balance class to user class
        public User AssignBalance()
        {
            var balanceInfo = GetAllBalances();
            var user = new  User();
            user.Balances = balanceInfo;

            return user;
        }*/


    }
   }

