using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Infrastructure.ExecuteCommands
{
    public interface IExecuters
    {
        Task<T> ExecuteCommand<T>(Func<SqlConnection, Task<T>> task);
        T ExecuteCommand<T>(Func<SqlConnection, T> task);
        Task<T> ExecuteMultipleCommand<T>(Func<SqlConnection, Task<T>> task);
        void CloseConnection();
    }
}
