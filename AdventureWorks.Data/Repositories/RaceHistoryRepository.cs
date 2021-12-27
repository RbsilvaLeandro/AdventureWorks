using AdventureWorks.Domain.Core.Interfaces;
using AdventureWorks.Domain.DTO;
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
    public class RaceHistoryRepository : Context, IRepositoryRaceHistory
    {
        public RaceHistoryRepository(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task<int> CreateAsync(RaceHistory entity)
        {
            try
            {
                var query = "INSERT INTO RaceHistory (CompetitorId, RaceTrackId, DateTrack, TimeSpent) VALUES (@CompetitorId, @RaceTrackId, @DateTrack, @TimeSpent)";

                var parameters = new DynamicParameters();
                parameters.Add("CompetitorId", entity.CompetitorId, DbType.Int64);
                parameters.Add("RaceTrackId", entity.RaceTrackId, DbType.Int64);
                parameters.Add("DateTrack", new DateTime(entity.DateTrack.Year, entity.DateTrack.Month, entity.DateTrack.Day, 0, 0, 0, 0, DateTimeKind.Utc), DbType.DateTime);
                parameters.Add("TimeSpent", entity.TimeSpent, DbType.Decimal);

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
                var query = "DELETE FROM RaceHistory WHERE Id = @Id";

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

        public async Task<IEnumerable<RaceHistory>> GetAllAsync()
        {
            try
            {
                var query =
                    @"SELECT r.Id, r.CompetitorId, c.Name, r.RaceTrackId, rt.Description, r.DateTrack, r.TimeSpent 
                      FROM RaceHistory r
                      INNER JOIN Competitors c ON c.Id = r.CompetitorId
                      INNER JOIN RaceTrack rt ON rt.Id = r.RaceTrackId";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<RaceHistory>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<RaceHistory> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT Id, CompetitorId, RaceTrackId, DateTrack, TimeSpent FROM RaceHistory WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<RaceHistory>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<RaceHistoryDTO>> ListDetailsHistory()
        {
            try
            {
                var query =
                    @"SELECT r.Id, r.CompetitorId, c.Name AS CompetitorName, r.RaceTrackId, rt.Description AS TrackDescription, r.DateTrack, r.TimeSpent 
                      FROM RaceHistory r
                      INNER JOIN Competitors c ON c.Id = r.CompetitorId
                      INNER JOIN RaceTrack rt ON rt.Id = r.RaceTrackId";

                using (var connection = CreateConnection())
                {
                    var data = (await connection.QueryAsync<Domain.DTO.RaceHistoryDTO>(query)).ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<RaceHistoryDTO> ListDetailsHistoryById(int id)
        {
            try
            {
                var query =
                   @"SELECT r.Id, r.CompetitorId, c.Name AS CompetitorName, r.RaceTrackId, rt.Description AS TrackDescription, r.DateTrack, r.TimeSpent 
                      FROM RaceHistory r
                      INNER JOIN Competitors c ON c.Id = r.CompetitorId
                      INNER JOIN RaceTrack rt ON rt.Id = r.RaceTrackId
                      WHERE r.Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    var data = (await connection.QueryFirstAsync<RaceHistoryDTO>(query, parameters));
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(RaceHistory entity)
        {
            try
            {
                var query = "UPDATE RaceHistory SET DateTrack = @DateTrack, TimeSpent = @TimeSpent WHERE Id = @Id";
                
                var parameters = new DynamicParameters();
                parameters.Add("DateTrack", new DateTime(entity.DateTrack.Year, entity.DateTrack.Month, entity.DateTrack.Day, 0, 0, 0, 0, DateTimeKind.Utc), DbType.DateTime);
                parameters.Add("TimeSpent", entity.TimeSpent, DbType.Decimal);
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
