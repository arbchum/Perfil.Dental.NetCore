using Dapper;
using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.Netcore.Domain.Enums;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Infrastructure.ExecuteCommands;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Infrastructure.Repositories
{
    public class OrtodonciaRepository : IOrtodonciaRepository
    {
        private readonly string Procedure = "[USP_ORTODONCIA]";
        private readonly IExecuters _executers;
        public OrtodonciaRepository(IExecuters executers)
        {
            _executers = executers;
        }
        public async Task<IEnumerable<OrtodonciaDto>> GetSearchAsync()
        {
            var sql = $"{Procedure};{(int)OrtodonciaEnum.Search}";
            var result = await _executers.ExecuteCommand(
            async conn => await conn.QueryAsync<OrtodonciaDto>(sql, commandType: CommandType.StoredProcedure));
            return result;
        }
        public async Task<bool> CreateAsync(Ortodoncia request)
        {
            int result = 0;
            //request.nCantidadSesiones = request.DetOrtodoncia.AsList().Count;
            await _executers.ExecuteCommand(async conn =>
            {
                using var transaction = conn.BeginTransaction();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("nIdPaciente", request.nIdPaciente, DbType.Int32, ParameterDirection.Input);
                parameters.Add("nEstado", request.nEstado, DbType.Int32, ParameterDirection.Input);
                parameters.Add("nCantidadSesiones", request.nCantidadSesiones, DbType.Int32, ParameterDirection.Input);
                parameters.Add("dFechaInstalacion", request.dFechaInstalacion, DbType.Date, ParameterDirection.Input);
                parameters.Add("sComentario", request.sComentario, DbType.String, ParameterDirection.Input);
                parameters.Add("dFechaTermino", request.dFechaTermino, DbType.Date, ParameterDirection.Input);
                parameters.Add("nIdOrtodoncia", request.nIdOrtodoncia, DbType.Int32, ParameterDirection.Output);
                var sql1 = $"{Procedure};{(int)OrtodonciaEnum.Create}";
                result = await conn.ExecuteAsync(sql1, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

                if (!request.nIdOrtodoncia.HasValue)
                {
                    request.DetOrtodoncia.AsList().ForEach(item => item.nIdOrtodoncia = parameters.Get<int>("nIdOrtodoncia"));
                }

                if (request.DetOrtodoncia != null)
                {
                    foreach (var item in request.DetOrtodoncia)
                    {
                        DynamicParameters parameterTratamiento = new DynamicParameters();
                        parameterTratamiento.Add("nIdOrtodoncia", item.nIdOrtodoncia, DbType.Int32, ParameterDirection.Input);
                        parameterTratamiento.Add("sDescripcion", item.sDescripcion, DbType.String, ParameterDirection.Input);
                        parameterTratamiento.Add("dFechaControl", item.dFechaControl, DbType.Date, ParameterDirection.Input);
                        parameterTratamiento.Add("nIdDetOrtodoncia", item.nIdDetOrtodoncia, DbType.Int32, ParameterDirection.Input);
                        var sql2 = $"{Procedure};{(int)OrtodonciaEnum.CreateDetail}";
                        await conn.ExecuteAsync(sql2, parameterTratamiento, commandType: CommandType.StoredProcedure, transaction: transaction);
                    }
                }
                transaction.Commit();
            });
            _executers.CloseConnection();
            return result > 0;
        }

        public async Task<bool> CreateOrUpdateDetOrtodonciaAsync(DetOrtodoncia request)
        {
            var sql = $"{Procedure};{(int)OrtodonciaEnum.CreateDetail}";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("nIdDetOrtodoncia", request.nIdDetOrtodoncia, DbType.Int32, ParameterDirection.Input);
            parameters.Add("nIdOrtodoncia", request.nIdOrtodoncia, DbType.Int32, ParameterDirection.Input);
            parameters.Add("dFechaControl", request.dFechaControl, DbType.Date, ParameterDirection.Input);
            parameters.Add("sDescripcion", request.sDescripcion, DbType.String, ParameterDirection.Input);
            var result = await _executers.ExecuteCommand(
            async conn => await conn.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure));
            return result > 0;
        }

        public async Task<IEnumerable<DetOrtodonciaDto>> GetDetailAsync(int nIdOrtodoncia)
        {
            var sql = $"{Procedure};{(int)OrtodonciaEnum.GetDetail}";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("nIdOrtodoncia", nIdOrtodoncia, DbType.Int32, ParameterDirection.Input);
            var result = await _executers.ExecuteCommand(
            async conn => await conn.QueryAsync<DetOrtodonciaDto>(sql, parameters, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
