using NPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DeveloperMeetUpBookings.Queries.Helpers
{
    public class NpocoHelpers
    {
        public static IDatabase GetConnection()
        {
            IDatabase connection = new Database(@"Data Source=UKSOU-N-0049;Initial Catalog=DeveloperMeetUpBookings;Integrated Security=True;User ID=DeveloperMeetUpBookingsAdmin;Password=P@ssw0rd", DatabaseType.SqlServer2012, SqlClientFactory.Instance);

            return connection;
        }
    }
}