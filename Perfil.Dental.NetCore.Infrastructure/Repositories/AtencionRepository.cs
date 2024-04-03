using Dapper;
using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.Netcore.Domain.Enums;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Infrastructure.ExecuteCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Infrastructure.Repositories
{
    public class AtencionRepository : IAtencionRepository
    {
        private readonly string Procedure = "[USP_ATENCION]";
        private readonly IExecuters _executers;
        public AtencionRepository(IExecuters executers)
        {
            _executers = executers;
        }

        public async Task<IEnumerable<AtencionDto>> GetSearchAsync()
        {
            var sql = $"{Procedure};{(int)EAtencion.Search}";
            var result = await _executers.ExecuteCommand(
            async conn => await conn.QueryAsync<AtencionDto>(sql, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<bool> CreateAync(Atencion request)
        {
            int result = 0;
            request.nMonto = request.DetAtencion.Select(item => item.nCantidad * item.nPrecio).Sum();
            await _executers.ExecuteCommand(async conn =>
            {
                using var transaction = conn.BeginTransaction();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("nIdCliente", request.nIdCliente, DbType.Int32, ParameterDirection.Input);
                parameters.Add("sNota", request.sNota, DbType.String, ParameterDirection.Input);
                parameters.Add("nMonto", request.nMonto, DbType.Double, ParameterDirection.Input);
                parameters.Add("nIdAtencion", request.nIdAtencion, DbType.Int32, ParameterDirection.Output);
                var sql1 = $"{Procedure};{(int)EAtencion.Create}";
                result = await conn.ExecuteAsync(sql1, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

                if (request.nIdAtencion == 0)
                {
                    request.nIdAtencion = parameters.Get<int>("nIdAtencion");
                }

                if (request.DetAtencion != null)
                {
                    foreach (var item in request.DetAtencion)
                    {
                        DynamicParameters parameterTratamiento = new DynamicParameters();
                        parameterTratamiento.Add("nIdAtencion", request.nIdAtencion, DbType.Int32, ParameterDirection.Input);
                        parameterTratamiento.Add("nIdTratamiento", item.nIdTratamiento, DbType.Int32, ParameterDirection.Input);
                        parameterTratamiento.Add("nCantidad", item.nCantidad, DbType.Int32, ParameterDirection.Input);
                        parameterTratamiento.Add("nPrecio", item.nPrecio, DbType.Double, ParameterDirection.Input);
                        var sql2 = $"{Procedure};{(int)EAtencion.CreateDetail}";
                        await conn.ExecuteAsync(sql2, parameterTratamiento, commandType: CommandType.StoredProcedure, transaction: transaction);
                    }
                }
                transaction.Commit();
            });
            _executers.CloseConnection();
            return result > 0;
        }

        public async Task<IEnumerable<AtencionHistorico>> GetHistoricalAsync(int nIdCliente)
        {
            var sql = $"{Procedure};{(int)EAtencion.GetHistorical}";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("nIdCliente", nIdCliente, DbType.Int32, ParameterDirection.Input);
            var result = await _executers.ExecuteCommand(
            async conn => await conn.QueryAsync<AtencionHistorico>(sql, parameters, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
