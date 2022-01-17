using System;
using System.Data;
using Npgsql;


namespace SQLDataAccess
{
    public class PostgreConnection
    {
        private static readonly string app = "Avito";

        public static IDbConnection Connection()
        {
            var connectionStr = new ConnectionStringForApp(app).Value();
            return new NpgsqlConnection(connectionStr);
        }
    }
}
