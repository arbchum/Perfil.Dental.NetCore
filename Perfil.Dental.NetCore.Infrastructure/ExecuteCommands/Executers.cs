using Perfil.Dental.NetCore.Infrastructure.ExecuteCommands;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Infrastructure.Infrastructure.ExecuteCommands
{
    public class Executers : IExecuters
    {
        private readonly string _connectionString;
        private SqlConnection conn;
        public Executers(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<T> ExecuteCommand<T>(Func<SqlConnection, Task<T>> task)
        {
            conn = CreateConnection();
            await conn.OpenAsync();
            var result = await task(conn);
            await conn.CloseAsync();
            return result;
        }

        public T ExecuteCommand<T>(Func<SqlConnection, T> task)
        {
            conn = CreateConnection();
            conn.Open();
            var result = task(conn);
            return result;
        }
        public async Task<T> ExecuteMultipleCommand<T>(Func<SqlConnection, Task<T>> task)
        {
            conn = CreateConnection();
            await conn.OpenAsync();
            var result = await task(conn);
            await conn.CloseAsync();
            return result;
        }
        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

    }
}