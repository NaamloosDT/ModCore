using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Database
{
    public class DatabaseConnectionProvider
    {
        private string connectionString;
        private DatabaseProvider provider;

        public DatabaseConnectionProvider(string connectionString, DatabaseProvider provider)
        {
            this.connectionString = connectionString;
            this.provider = provider;
        }

        public DatabaseConnection GetConnection()
        {
            try
            {
                var connection = new DatabaseConnection(connectionString, provider);
                connection.Database.EnsureCreated();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("db did an oopsie!");
                throw;
            }
        }
    }

    public enum DatabaseProvider
    {
        Postgres,
        SQLite
    }
}
