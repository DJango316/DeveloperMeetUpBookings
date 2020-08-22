using DbUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperMeetUpBookings.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault() ?? "Server=UKSOU-N-0049; Database=DeveloperMeetUpBookings; Trusted_connection=true; User ID=DeveloperMeetUpBookingsAdmin; Password=P@ssw0rd";
            EnsureDatabase.For.SqlDatabase(connectionString);
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                Console.ReadLine();
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
