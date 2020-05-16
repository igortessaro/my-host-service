using my_host_service.application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_host_service.application.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly IReadOnlyCollection<CustomerDto> customers;

        public CustomerService()
        {
            this.customers = this.CreateCustomers();
        }

        public IReadOnlyCollection<CustomerDto> FindAllCustomers()
        {
            return this.customers;
        }

        public CustomerDto FindByFirstName(string firstName)
        {
            return this.customers.FirstOrDefault(x => x.FirstName.Equals(firstName));
        }

        private IReadOnlyCollection<CustomerDto> CreateCustomers()
        {
            var customers = new List<CustomerDto>();

            customers.Add(new CustomerDto { FirstName = "Fulano", LastName = "Silva" });
            customers.Add(new CustomerDto { FirstName = "Beltrano", LastName = "Santos" });
            customers.Add(new CustomerDto { FirstName = "Ciclano", LastName = "Silveira" });

            return customers;
        }
    }
}
