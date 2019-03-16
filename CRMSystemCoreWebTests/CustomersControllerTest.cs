using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yokogawa.Libraries.Business.Interfaces;
using Yokogawa.Libraries.Models;
using Yokogawa.Libraries.Web.Controllers.Impl;

namespace CRMSystemCoreWebTests
{
    public class CustomersControllerTest
    {
        [Fact]
        public void ShouldGetCustomersReturnCustomerRecords()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);
            var customersBusinessServiceMockObject = mockRepository.Create<ICustomersBusinessService>();
            var mockCustomers = new List<Customer>
            {
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Northwind",
                    Address = "Bangalore",
                    Credit = 23000,
                    Status = true,
                    Email = "info@email.com",
                    Phone = "080-3498349834",
                    Remarks = "Simple Customer Record"
                }
            };

            customersBusinessServiceMockObject
                .Setup(service => service.GetCustomers(default(string)))
                .Returns(mockCustomers);

            var customersController = new CustomersController(customersBusinessServiceMockObject.Object);
            var actionResult = customersController.GetCustomers() as OkObjectResult;
            var data = actionResult.Value as IEnumerable<Customer>;
            var expectedNoOfCustomers = 1;
            var actualNoOfCustomers = data.Count();

            Assert.NotNull(actionResult);
            Assert.NotNull(data);
            Assert.Equal<int>(expectedNoOfCustomers, actualNoOfCustomers);
        }
    }
}
