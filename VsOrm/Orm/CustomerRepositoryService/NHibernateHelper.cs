using CustomerService.Entities.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace CustomerService
{
    public class NHibernateHelper
    {
        //private static ISessionFactory _sessionFactory;

        public static object DatabaseHelper { get; private set; }

        private static ISessionFactory SessionFactory
        {
            get
            {
                var connString = System.Configuration.ConfigurationManager.ConnectionStrings["app"].ConnectionString;
                return Fluently
                .Configure()
                .Database(OracleClientConfiguration
                    .Oracle10
                    .ShowSql()
                    .Driver<NHibernate.Driver.OracleManagedDataClientDriver>()
                    .ConnectionString(c=>c.FromConnectionStringWithKey("app")))
                .Mappings(m => m.FluentMappings
                     .Add<AccountMap>()
                     )
                 .BuildSessionFactory();
                // var cfg = new NHibernate.Cfg.Configuration();
                // cfg.Configure(); // read config default style

                // return Fluently
                //.Configure(cfg)
                //.Database(OracleClientConfiguration
                //.Oracle10
                //.ShowSql()
                //.Driver<NHibernate.Driver.OracleManagedDataClientDriver>())
                //.Mappings(m => m.FluentMappings
                //    .Add<AccountMap>()
                //    )
                ////.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(updateExport, false))
                ////.ExposeConfiguration(x => { x.SetInterceptor(new SqlInterceptor()); })
                //.BuildSessionFactory();


            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
