using _2C2P___Aznar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _2C2P___Aznar.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        RepositoryContext _context;

        public CustomerRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<Customer> Find(long key)
        {
        
            var customer= await _context.Customers.FirstOrDefaultAsync(c=>c.customerID==key);
            if (customer!=null)
            {
                customer.Transactions = getLastTransactionsForCustomer(key);
            }

            return customer;
                
        }
        
        public async Task<Customer> FindByEmail(string email)
        {
            
            var customer = await _context.Customers.Where(c => c.Email.Equals(email)).FirstOrDefaultAsync();
            if (customer != null)
            {
                customer.Transactions = getLastTransactionsForCustomer(customer.customerID);
            }
            return customer;


        }

        public List<Transaction> getLastTransactionsForCustomer(long key)
        {
            return _context.Transactions.Where(tx => tx.Customer.customerID ==key).OrderByDescending(or => or.Date).Take(5).ToList();
        }
    }
}
