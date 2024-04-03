using Dapper;
using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.Netcore.Domain.Enums;
using Perfil.Dental.NetCore.Application.Contracts.Queries;
using Perfil.Dental.NetCore.Application.Contracts.Responses;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Infrastructure.ExecuteCommands;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        public async Task<IEnumerable<OrtodonciaDataResponse>> GetSearchAsync()
        {
            var sql = $"{Procedure};{(int)OrtodonciaEnum.Search}";
            var result = await _executers.ExecuteCommand(
            async conn => await conn.QueryAsync<OrtodonciaDataResponse>(sql, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<OrtodonciaGetResponse> GetOneAsync(int nIdPaciente)
        {
            var sql = $"{Procedure};{(int)OrtodonciaEnum.GetOne}";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("nIdPaciente", nIdPaciente, DbType.Int32, ParameterDirection.Input);
            return await _executers.ExecuteCommand(
                async conn =>
                {
                    using var query = await conn.QueryMultipleAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                    var result = query.Read<OrtodonciaGetResponse>().SingleOrDefault();
                    result.Sesiones = query.Read<DetOrtodonciaGetResponse>().ToList();
                    return result;
                }
            );
        }
        public async Task<bool> CreateAsync(Ortodoncia request)
        {
            int result = 0;

            await _executers.ExecuteCommand(async conn =>
            {
                using var transaction = conn.BeginTransaction();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("nIdPaciente", request.nIdPaciente, DbType.Int32, ParameterDirection.Input);
                parameters.Add("nIdEstado", request.nIdEstado, DbType.Int16, ParameterDirection.Input);
                parameters.Add("nIdUsuario", request.nIdUsuario, DbType.Int16, ParameterDirection.Input);
                var sql1 = $"{Procedure};{(int)OrtodonciaEnum.Create}";
                result = await conn.ExecuteAsync(sql1, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

                if (request.DetOrtodoncia != null)
                {
                    foreach (var item in request.DetOrtodoncia)
                    {
                        DynamicParameters parameterDetail = new DynamicParameters();
                        parameterDetail.Add("nIdPaciente", request.nIdPaciente, DbType.Int32, ParameterDirection.Input);
                        parameterDetail.Add("nNroSesion", item.nNroSesion, DbType.Int16, ParameterDirection.Input);
                        parameterDetail.Add("sComentario", item.sComentario, DbType.String, ParameterDirection.Input);
                        parameterDetail.Add("dFechaControl", item.dFechaControl, DbType.Date, ParameterDirection.Input);
                        parameterDetail.Add("nIdUsuario", request.nIdUsuario, DbType.Int16, ParameterDirection.Input);
                        var sql2 = $"{Procedure};{(int)OrtodonciaEnum.CreateDetail}";
                        await conn.ExecuteAsync(sql2, parameterDetail, commandType: CommandType.StoredProcedure, transaction: transaction);
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
            parameters.Add("nIdPaciente", request.nIdPaciente, DbType.Int32, ParameterDirection.Input);
            parameters.Add("nNroSesion", request.nNroSesion, DbType.Int16, ParameterDirection.Input);
            parameters.Add("sComentario", request.sComentario, DbType.String, ParameterDirection.Input);
            parameters.Add("dFechaControl", request.dFechaControl, DbType.Date, ParameterDirection.Input);
            parameters.Add("nIdUsuario", request.nIdUsuario, DbType.Int16, ParameterDirection.Input);
            var result = await _executers.ExecuteCommand(
            async conn => await conn.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure));
            return result > 0;
        }

        public async Task<IEnumerable<DetOrtodonciaDataResponse>> GetDetailAsync(DetOrtodonciaQuery filter)
        {
            var sql = $"{Procedure};{(int)OrtodonciaEnum.GetDetail}";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("nIdPaciente", filter.nIdPaciente, DbType.Int32, ParameterDirection.Input);
            parameters.Add("nNumTop", filter.nNumTop, DbType.Int16, ParameterDirection.Input);
            var result = await _executers.ExecuteCommand(
            async conn => await conn.QueryAsync<DetOrtodonciaDataResponse>(sql, parameters, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
