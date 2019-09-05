using _2C2P___Aznar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2C2P___Aznar.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> Find(long key);

        Task<Customer> FindByEmail(string email);
    }
}
