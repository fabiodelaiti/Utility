using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Mapping;

namespace CustomerService.Entities.Map
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Table("ACCOUNT");
            Id(x => x.AccountId);
        }
}
}
