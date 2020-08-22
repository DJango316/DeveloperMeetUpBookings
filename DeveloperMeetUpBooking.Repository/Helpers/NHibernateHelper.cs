using DeveloperMeetUpBookings.Repository.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DeveloperMeetUpBookings.Repository.Helpers
{
    public class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _sessionFactory;
        static NHibernateHelper()
        {
            _sessionFactory = FluentConfigure();
        }
        public static ISession GetCurrentSession()
        {
            return _sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            _sessionFactory.Close();
        }
        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }

        public static ISessionFactory FluentConfigure()
        {
            return Fluently.Configure()
                //which database
                .Database(
                    MsSqlConfiguration.MsSql2012
                        .ConnectionString(
                            cs => cs.FromConnectionStringWithKey
                                  ("DBConnection")) //connection string from app.config
                                                    //.ShowSql()
                        )
                //2nd level cache
                .Cache(
                    c => c.UseQueryCache()
                        .UseSecondLevelCache())
                       //find/set the mappings
                       //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMapping>())
                //.Mappings(m => m.FluentMappings.Add<SeatMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BookingMap>())
                .BuildSessionFactory();
        }
    }
}