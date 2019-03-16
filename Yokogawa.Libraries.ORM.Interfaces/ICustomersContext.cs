using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Yokogawa.Libraries.Models;

namespace Yokogawa.Libraries.ORM.Interfaces
{
    public interface ICustomersContext : ISystemContext
    {
        DbSet<Customer> Customers { get; set; }
    }
}
