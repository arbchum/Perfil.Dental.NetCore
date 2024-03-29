﻿using Dapper;
using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.Netcore.Domain.Enums;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Infrastructure.ExecuteCommands;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Infrastructure.Repositories
{
    public class TratamientoRepository: ITratamientoRepository
    {
        private readonly string Procedure = "[USP_TRATAMIENTO]";
        private readonly IExecuters _executers;
        public TratamientoRepository(IExecuters executers)
        {
            _executers = executers;
        }

        public async Task<IEnumerable<Tratamiento>> GetSearchAsync()
        {
            var sql = $"{Procedure};{(int)TratamientoEnum.Search}";
            var result = await _executers.ExecuteCommand(
            async conn => await conn.QueryAsync<Tratamiento>(sql, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<bool> CreateOrUpdateAync(Tratamiento request)
        {
            var sql = $"{Procedure};{(int)TratamientoEnum.InsertOrUpdate}";
            var parameters = new DynamicParameters();
            parameters.Add("nIdTratamiento", request.nIdTratamiento, DbType.Int32, ParameterDirection.Input);
            parameters.Add("sNombre", request.sNombre, DbType.String, ParameterDirection.Input);
            parameters.Add("nPrecio", request.nPrecio, DbType.Decimal, ParameterDirection.Input);
            var result = await _executers.ExecuteCommand(
            async conn => await conn.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure));
            return result > 0;
        }
    }
}
