using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{

    public class RegistrationModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerRepository>().To<CustomerRepository>();
        }
    }
}
