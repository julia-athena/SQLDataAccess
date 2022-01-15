using System;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SQLDataAccess
{
    public class PostgreConnection
    {
        private static readonly string app = "Avito";

        public static IDbConnection Connection()
        {
            return new SqlConnection(new ConnectionStringForApp(app).Value());
        }
    }
}
