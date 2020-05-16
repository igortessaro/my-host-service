using my_host_service.application.Dtos;
using System.Collections.Generic;

namespace my_host_service.application.Services
{
    public interface ICustomerService
    {
        IReadOnlyCollection<CustomerDto> FindAllCustomers();

        CustomerDto FindByFirstName(string firstName);
    }
}
