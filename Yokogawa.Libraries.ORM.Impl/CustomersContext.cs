using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Yokogawa.Libraries.Models;
using Yokogawa.Libraries.ORM.Interfaces;

namespace Yokogawa.Libraries.ORM.Impl
{
    public class CustomersContext : BaseSystemContext, ICustomersContext
    {
        public CustomersContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Customer>(new CustomerEntityTypeConfiguration());
        }
    }
}
