using System;
using System.Collections.Generic;
using Yokogawa.Libraries.Business.Interfaces;
using Yokogawa.Libraries.Models;
using Yokogawa.Libraries.Repositories.Interfaces;

namespace Yokogawa.Libraries.Business.Impl
{
    public class CustomersBusinessService : ICustomersBusinessService
    {
        private const string INVALID_CUSTOMERS_REPOSITORY = @"Invalid Customers Repository Specified!";
        private ICustomersRepository customersRepository = default(ICustomersRepository);
        private ICustomerValidator<string> customerValidator = default(ICustomerValidator<string>);

        public CustomersBusinessService(ICustomersRepository customersRepository,
            ICustomerValidator<string> customerValidator)
        {
            if (customersRepository == default(ICustomersRepository))
                throw new ArgumentException(INVALID_CUSTOMERS_REPOSITORY);

            this.customersRepository = customersRepository;
            this.customerValidator = customerValidator;
        }

        public bool AddNewCustomer(Customer newCustomer)
        {
            var saveStatus = default(bool);

            var validation = newCustomer != default(Customer) &&
                this.customersRepository != default(ICustomersRepository);

            if (validation)
                saveStatus = this.customersRepository.AddEntity(newCustomer);

            return saveStatus;
        }

        public void Dispose() => this.customersRepository?.Dispose();

        public Customer GetCustomer(int customerId)
        {
            var filteredCustomer = default(Customer);
            var validation = customerId != default(int) &&
                this.customersRepository != default(ICustomersRepository);

            if (validation)
                filteredCustomer = this.customersRepository.GetEntityByKey(customerId);

            return filteredCustomer;
        }

        public IEnumerable<Customer> GetCustomers(string customerName = null)
        {
            var customersList = default(IEnumerable<Customer>);

            if (string.IsNullOrEmpty(customerName))
                customersList = this.customersRepository.GetEntities();
            else
            {
                var validation = !string.IsNullOrEmpty(customerName) &&
                    !this.customerValidator.Validate(customerName);

                if (validation)
                    customersList = this.customersRepository.GetCustomersByName(customerName);
            }

            return customersList;
        }
    }
}
