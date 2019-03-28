using Microsoft.AspNetCore.Mvc;
using System;
using Yokogawa.Libraries.Models;

namespace Yokogawa.Libraries.Web.Controllers.Interfaces
{
    public interface ICustomersController : IDisposable
    {
        IActionResult GetCustomers();
        IActionResult SearchCustomers(string customerName);
        IActionResult GetCustomer(int customerId);
        IActionResult SaveCustomer(Customer customer);
    }
}
