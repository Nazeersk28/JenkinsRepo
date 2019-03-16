using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Yokogawa.Libraries.Business.Interfaces;
using Yokogawa.Libraries.Models;
using Yokogawa.Libraries.Web.Controllers.Interfaces;

namespace Yokogawa.Libraries.Web.Controllers.Impl
{
    /// <summary>
    /// CRM System Service Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/customers")]
    // [Authorize]
    [EnableCors("_myAllowSpecificOrigins")]
    public class CustomersController : Controller, ICustomersController
    {
        private const string INVALID_CUSTOMERS_BUSINESS_SERVICE = @"Invalid Customers Business Service Specified!";
        private ICustomersBusinessService customersBusinessService = default(ICustomersBusinessService);
        /// <summary>
        /// Constructor that dependes on Customers Business Service
        /// </summary>
        /// <param name="customersBusinessService">Injected Customers Business Service Implementation</param>

        public CustomersController(ICustomersBusinessService customersBusinessService)
        {
            if (customersBusinessService == default(ICustomersBusinessService))
                throw new ArgumentException(INVALID_CUSTOMERS_BUSINESS_SERVICE);

            this.customersBusinessService = customersBusinessService;
        }

        /// <summary>
        /// Cleaning up of Resources used by this object.
        /// </summary>
        public void Dispose() => this.customersBusinessService?.Dispose();

        /// <summary>
        /// Gets Customer Details by Customer Id
        /// </summary>
        /// <param name="customerId">Specific Customer Id (Integer)</param>
        /// <returns>Returns complete customer object</returns>
        [HttpGet("details/{customerId}")]
        public IActionResult GetCustomer(int customerId)
        {
            var filteredCustomer = this.customersBusinessService.GetCustomer(customerId);

            if (filteredCustomer == default(Customer))
                return NotFound();

            return Ok(filteredCustomer);
        }

        /// <summary>
        /// Gets all Customer Records
        /// </summary>
        /// <returns>Array of Customer Records</returns>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customersList = this.customersBusinessService.GetCustomers();

            return Ok(customersList);
        }

        /// <summary>
        /// Saves Customer Records into the CRM System Database
        /// </summary>
        /// <param name="customer">Customer Record</param>
        /// <returns>Status of the Operation</returns>
        [HttpPost]
        public IActionResult SaveCustomer([FromBody] Customer customer)
        {
            var saveStatus = default(bool);
            var validation = customer != default(Customer) &&
                this.customersBusinessService != default(ICustomersBusinessService);

            if (!validation)
                return BadRequest();

            saveStatus = this.customersBusinessService.AddNewCustomer(customer);

            return Ok(customer);
        }

        /// <summary>
        /// Searches customer records by Customer Name
        /// </summary>
        /// <param name="customerName">Search String</param>
        /// <returns>Array of Matching Customer Records</returns>
        [HttpGet("search/{customerName}")]
        public IActionResult SearchCustomers(string customerName)
        {
            var filteredCustomers = default(IEnumerable<Customer>);
            var validation = !string.IsNullOrEmpty(customerName) &&
                this.customersBusinessService != default(ICustomersBusinessService);

            if (!validation)
                return BadRequest();

            filteredCustomers = this.customersBusinessService.GetCustomers(customerName);

            return Ok(filteredCustomers);
        }
    }
}
