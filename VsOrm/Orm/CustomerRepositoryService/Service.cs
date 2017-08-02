using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerService.Model;

namespace CustomerService
{
    public class Service
    {
        ICustomerRepository _repository;
        public Service(ICustomerRepository repository)
        {
            _repository = repository;
        }

       
        public List<Customer> GetAllCustomers()
        {
            return _repository.GetAllCustomers();
        }
    }
}
