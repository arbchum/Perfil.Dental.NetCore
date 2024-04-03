using Dapper;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Infrastructure.ExecuteCommands;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Infrastructure.Repositories
{
    public class UtileriaRepository : IUtileriaRepository
    {
        private readonly string Procedure = "[USP_UTILERIA]";
        private readonly IExecuters _executers;
        public UtileriaRepository(IExecuters executers)
        {
            _executers = executers;
        }
        public async Task<bool> ExcepcionesSistema(Exception info, string metodo)
        {
            var sql = $"{Procedure}";
            var parameters = new DynamicParameters();
            parameters.Add("Metodo", metodo, DbType.String, ParameterDirection.Input);
            parameters.Add("Mensaje", info.Message, DbType.String, ParameterDirection.Input);
            parameters.Add("StackTrace", info.StackTrace, DbType.String, ParameterDirection.Input);
            parameters.Add("dFechaReg", DateTime.Now, DbType.String, ParameterDirection.Input);
            var result = await _executers.ExecuteCommand(async conn => await conn.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure));
            return result > 0;
        }
    }
}
