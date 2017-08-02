using System.Collections.Generic;
using CustomerService.Model;

namespace CustomerService
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}