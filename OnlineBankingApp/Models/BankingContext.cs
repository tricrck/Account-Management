using Microsoft.EntityFrameworkCore;
using OnlineBankingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace OnlineBankingApp.Models
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountActivity> AccountActivities { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PaymentHistory>()
                .HasOne(p => p.Payee)
                .WithMany()
                .HasForeignKey(p => p.PayeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PaymentHistory>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.PaymentHistories)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Customer>()
                .Property(c => c.RoleId)
                .HasDefaultValue(2);

            modelBuilder.Entity<Roles>().HasData(
                    new Roles { RoleId = 1, RoleName = "Manager" },
                    new Roles { RoleId = 2, RoleName = "Customer" },
                    new Roles { RoleId = 3, RoleName = "Teller" }
                );
            modelBuilder.Entity<Customer>()
            .HasData(
                    new Customer { CustomerId = new Guid("7bbbdb09-9f22-4244-ab0b-1edf7918ec69"), CustomerName = "Manager Banks", Tfn= "123456789", Address= "Casa De Shenandoah", City= "Vegas", State ="nsw", PostCode ="1234", Phone = "123-123-1234", Password = "Admin", RoleId = 1, ConfirmPassword = "Admin" },
                    new Customer { CustomerId = new Guid("e7c2dd45-480c-4400-a065-5f828ba588f3"), CustomerName = "Teller Banks", Tfn= "123456789", Address = "Casa De Shenandoah", City= "Vegas", State= "nsw", PostCode="1234", Phone = "123-123-1234", Password = "Admin", RoleId = 3, ConfirmPassword = "Admin" }
                );




        }
    }
}
