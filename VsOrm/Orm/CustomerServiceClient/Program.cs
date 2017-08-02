using CustomerService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load("*.dll");
            var concrete = kernel.Get<ICustomerRepository>();
            var service = new CustomerService.Service(concrete);
            concrete.GetAllCustomers().ForEach(c=> Console.WriteLine(c.UserName));
            Console.ReadLine();
        }
    }


    class RegistrationModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerRepository>().To<CustomerRepository>();

        }
    }
}
