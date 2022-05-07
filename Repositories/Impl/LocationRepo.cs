using Conn;
using Dapper;
using System.Data;
using Pubinno.Models;

namespace Pubinno.Repositories.Impl
{
    public class LocationRepo : ILocationRepo
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;
        private readonly ILogger<LocationRepo> _logger;

        public LocationRepo(IDatabaseConnectionFactory connectionFactory, ILogger<LocationRepo> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public async Task<bool> NewLocation(Location location)
        {
            try
            {
                using (var conn = await _connectionFactory.CreateConnectionAsync())
                {
                    await conn.QueryAsync<bool>("LocationSPinsert",
                                   new
                                   {
                                       name = location.name,
                                       address = location.address,
                                       openingTime = location.openingTime,
                                       closingTime = location.closingTime
                                   }, null, null, CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> EditLocation(Location location)
        {
            try
            {
                using (var conn = await _connectionFactory.CreateConnectionAsync())
                {
                    var result = await conn.QueryAsync<bool>("LocationSPupdate", new
                    {
                        Id = location.id,
                        name = location.name,
                        address = location.address,
                        openingTime = location.openingTime,
                        closingTime = location.closingTime
                    }, null, null, CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteLocation(int id)
        {
            try
            {
                using (var conn = await _connectionFactory.CreateConnectionAsync())
                {
                    await conn.ExecuteAsync("DELETE LocationTB WHERE Id = @Id", new { Id = id });
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Location> GetLocation(int id)
        {
            try
            {
                using (var conn = await _connectionFactory.CreateConnectionAsync())
                {
                    var res = await conn.QueryFirstAsync<Location>("SELECT * FROM LocationTB WHERE Id = @Id", new { Id = id }, null, null, CommandType.Text);
                    return res;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Location>> GetAllLocation()
        {
            try
            {
                using (var conn = await _connectionFactory.CreateConnectionAsync())
                {
                    var res = await conn.QueryAsync<Location>("SELECT * FROM LocationTB", new { }, null, null, CommandType.Text);
                    return (List<Location>)res;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
