using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CustomerService.Model;
using CustomerService;

namespace CustomerServiceTest
{
    [TestClass]
    [DeploymentItem("Oracle.ManagedDataAccess.dll")]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAccounts()
        {
          
            var service = new CustomerService.Service(new CustomerRepository());
            List<Customer> customers = service.GetAllCustomers();
            Assert.IsNotNull(customers);

        }
    }



}
