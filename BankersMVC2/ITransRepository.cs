using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankersMVC2.Models;

namespace BankersMVC2
{
    public interface ITransRepository
    {
        public void InsertTransaction(Transaction transaction);
    }
}
