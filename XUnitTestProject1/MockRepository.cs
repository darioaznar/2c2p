using _2C2P___Aznar.Models;
using _2C2P___Aznar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MockRepository : ICustomerRepository
{
    List<Customer> customers;

    public bool FailGet { get; set; }

    public MockRepository()
    {
        customers = new List<Customer>() {
            new Customer(){customerID=1, Name="Customer1", Mobile="1992637281", Email="user@domain.com", Transactions=
            new List<Transaction>(){ new Transaction() { Amount=125.25M, Currency=Transaction.TransactionCurrency.SGD, Date=DateTime.Now, Status=Transaction.TransactionStatus.Canceled, TransactionID=1} 
            ,new Transaction() { Amount=225.25M, Currency=Transaction.TransactionCurrency.USD, Date=DateTime.Now, Status=Transaction.TransactionStatus.Success, TransactionID=2} }

            
            },
            new Customer(){customerID=2, Name="Customer2", Mobile="9172735171", Email="user2@domain.com"},
            new Customer(){customerID=3, Name="Customer3", Mobile="8361910353",Email="user3@domain.com" },
            new Customer(){customerID=4, Name="Customer4", Mobile="7801274518", Email="user4@domain.com"}
        };
    }


    public async Task<Customer> Find(long key)
    {
        if (FailGet)
        {
            throw new InvalidOperationException();
        }
        await Task.Delay(1000);
        return   customers.Where(x=>x.customerID==key).FirstOrDefault();

    }

    public async Task<Customer> FindByEmail(string email)
    {
        if (FailGet)
        {
            throw new InvalidOperationException();
        }
        await Task.Delay(1000);

        var customer = customers.Where(x => x.Email == email).FirstOrDefault();

        return customer;

    }
}