using AdventureWorks.Domain.Core.Interfaces;
using AdventureWorks.Domain.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repositories
{
    public class RaceTrackRepository : Context, IRepositoryRaceTrack
    {
        public RaceTrackRepository(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task<int> CreateAsync(RaceTrack entity)
        {
            try
            {
                var query = "INSERT INTO RaceTrack (Description) VALUES (@Description)";

                var parameters = new DynamicParameters();
                parameters.Add("Description", entity.Description, DbType.String);               

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var query = "DELETE FROM RaceTrack WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<RaceTrack>> GetAllAsync()
        {
            try
            {
                var query = "SELECT Id, Description, (SELECT COUNT(id) FROM racehistory WHERE racetrackid = racetrack.id) > 0 as IsUsed FROM RaceTrack";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<RaceTrack>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        
        public async Task<RaceTrack> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT Id, Description FROM RaceTrack WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<RaceTrack>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<IEnumerable<object>> ListDetailsHistory()
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(RaceTrack entity)
        {
            try
            {
                var query = "UPDATE RaceTrack SET Description = @Description WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Description", entity.Description, DbType.String);               
                parameters.Add("Id", entity.Id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
