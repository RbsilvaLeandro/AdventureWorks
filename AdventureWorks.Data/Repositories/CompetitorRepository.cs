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
    public class CompetitorRepository : Context, IRepositoryCompetitors
    {
        public CompetitorRepository(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task<int> CreateAsync(Competitors entity)
        {
            try
            {
                var query = "INSERT INTO Competitors (Name, Gender, BodyTemperature, Weight, Height) VALUES (@Name, @Gender, @BodyTemperature, @Weight, @Height)";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Gender", entity.Gender, DbType.String);
                parameters.Add("Price", entity.Gender, DbType.String);
                parameters.Add("BodyTemperature", entity.BodyTemperature, DbType.Decimal);
                parameters.Add("Weight", entity.Weight, DbType.Decimal);
                parameters.Add("Height", entity.Height, DbType.Decimal);

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
                var query = "DELETE FROM Competitors WHERE Id = @Id";

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

        public async Task<IEnumerable<Competitors>> GetAllAsync()
        {
            try
            {
                var query =
                    @"SELECT c.Id, c.Name, c.Gender, c.BodyTemperature, c.Weight, c.Height,
                    (select count(id) from racehistory where CompetitorId = c.id) > 0 as IsRunner,
                    (select AVG(timespent)::numeric(10,2)  from racehistory where CompetitorId = c.id)  as AverageRace
                    FROM
                    Competitors c";


                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Competitors>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Competitors> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT Id, Name, Gender, BodyTemperature, Weight, Height FROM Competitors WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Competitors>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Competitors entity)
        {
            try
            {               
                var query = "UPDATE Competitors SET Name = @Name, Gender = @Gender, BodyTemperature = @BodyTemperature, Weight = @Weight, Height = @Height  WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Gender", entity.Gender, DbType.String);
                parameters.Add("BodyTemperature", entity.BodyTemperature, DbType.Decimal);
                parameters.Add("Weight", entity.Weight, DbType.Decimal);
                parameters.Add("Height", entity.Height, DbType.Decimal);
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
