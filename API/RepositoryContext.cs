using _2C2P___Aznar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace _2C2P___Aznar
{
    public class RepositoryContext : DbContext
    {
        private readonly IConfiguration _config;
        public RepositoryContext(IConfiguration config, DbContextOptions<RepositoryContext> options)
          : base(options)
        {
            _config = config;
        }
        public RepositoryContext(IConfiguration config) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           

            optionsBuilder.UseSqlServer(_config["ConnectionString:2C2P"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");


            #region seeding
            //seeding for database creation
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    customerID = 1,
                    Name = "Firstname Lastname",
                    Email = "user@domain.com",
                    Mobile = "0123456789"
                },
                new Customer()
                {
                    customerID = 2,
                    Name = "Firstname2 Lastname2",
                    Email = "user2@domain.com",
                    Mobile = "111111111"
                },
                new Customer()
                {
                    customerID = 3,
                    Name = "Firstname3 Lastname3",
                    Email = "user3@domain.com",
                    Mobile = "222222222",

                }
                );

            modelBuilder.Entity<Transaction>().HasData(
                new
                {
                    TransactionID = (long)1,
                    Amount = 1234.56M,
                    Currency = Transaction.TransactionCurrency.USD,
                    Status = Transaction.TransactionStatus.Success,
                    Date = new DateTime(2018, 02, 28, 21, 34, 0),
                    customerID = (long)1


                },
                        new
                        {
                            TransactionID = (long)2,
                            Amount = 2234.56M,
                            Currency = Transaction.TransactionCurrency.THB,
                            Status = Transaction.TransactionStatus.Failed,
                            Date = new DateTime(2018, 03, 28, 21, 34, 0),
                            customerID = (long)1


                        },
                        new
                        {
                            TransactionID = (long)3,
                            Amount = 12234.56M,
                            Currency = Transaction.TransactionCurrency.SGD,
                            Status = Transaction.TransactionStatus.Success,
                            Date = new DateTime(2018, 04, 28, 21, 34, 0),
                            customerID = (long)1


                        }
                ); ;
            #endregion
        }
    }
}
