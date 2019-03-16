using System;
using System.Collections.Generic;
using System.Text;
using Yokogawa.Libraries.Models;

namespace Yokogawa.Libraries.Repositories.Interfaces
{
    public interface ICustomersRepository : IRepository<Customer, int>
    {
        IEnumerable<Customer> GetCustomersByName(string customerName);
    }
}
