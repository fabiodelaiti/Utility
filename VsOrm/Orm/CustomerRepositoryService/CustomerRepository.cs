using CustomerService.Entities;
using CustomerService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    return session.CreateCriteria<Account>().List<Account>().Select(c=> new Customer { UserName = c.AccountId}).ToList();
                }
            }
        }
    }
}
