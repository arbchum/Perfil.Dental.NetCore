using Dapper;
using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.Netcore.Domain.Enums;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Infrastructure.ExecuteCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string Procedure = "[USP_CLIENTE]";
        private readonly IExecuters _executers;
        public ClienteRepository(IExecuters executers)
        {
            _executers = executers;
        }

        public async Task<IEnumerable<ClienteDto>> GetSearchAsync()
        {
            var sql = $"{Procedure};{(int)ClienteEnum.Search}";
            var result = await _executers.ExecuteCommand(
            async conn => await conn.QueryAsync<ClienteDto>(sql, commandType: CommandType.StoredProcedure));
            return result;
        }
        public async Task<bool> CreateOrUpdateAync(Cliente request)
        {
            var sql = $"{Procedure};{(int)ClienteEnum.InsertOrUpdate}";
            var parameters = new DynamicParameters();
            parameters.Add("nIdCliente", request.nIdCliente, DbType.Int32, ParameterDirection.Input);
            parameters.Add("sApePaterno", request.sApePaterno, DbType.String, ParameterDirection.Input);
            parameters.Add("sApeMaterno", request.sApeMaterno, DbType.String, ParameterDirection.Input);
            parameters.Add("sNombres", request.sNombres, DbType.String, ParameterDirection.Input);
            parameters.Add("sNroDocumento", request.sNroDocumento, DbType.String, ParameterDirection.Input);
            parameters.Add("sSexo", request.sSexo, DbType.String, ParameterDirection.Input);
            parameters.Add("dFechaNac", request.dFechaNac, DbType.Date, ParameterDirection.Input);
            parameters.Add("sCelular", request.sCelular, DbType.String, ParameterDirection.Input);
            parameters.Add("sTelefono", request.sTelefono, DbType.String, ParameterDirection.Input);
            parameters.Add("sCorreo", request.sCorreo, DbType.String, ParameterDirection.Input);
            parameters.Add("nIdDistrito", request.nIdDistrito, DbType.Int32, ParameterDirection.Input);
            parameters.Add("sDireccion", request.sDireccion, DbType.String, ParameterDirection.Input);
            parameters.Add("bMayor", Convert.ToBoolean(request.bMayor), DbType.Boolean, ParameterDirection.Input);
            var result = await _executers.ExecuteCommand(
            async conn => await conn.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure));
            return result > 0;
        }
        public async Task<Cliente> GetOneAsync(int nIdCliente)
        {
            var sql = $"{Procedure};{(int)ClienteEnum.GetOne}";
            var parameters = new DynamicParameters();
            parameters.Add("nIdCliente", nIdCliente, DbType.Int32, ParameterDirection.Input);
            var result = await _executers.ExecuteCommand(
            async conn => await conn.QuerySingleAsync<Cliente>(sql, parameters, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<IEnumerable<UbigeoDto>> GetUbigeoAll()
        {
            var sql = $"{Procedure};{(int)ClienteEnum.GetUbigeoAll}";
            var parameters = new DynamicParameters();
            var result = await _executers.ExecuteCommand(
            async conn => await conn.QueryAsync<UbigeoDto>(sql, parameters, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
