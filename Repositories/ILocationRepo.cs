using Pubinno.Models;

namespace Pubinno.Repositories
{
    public interface ILocationRepo
    {
        Task<bool> NewLocation(Location location);
        Task<bool> EditLocation(Location location);
        Task<bool> DeleteLocation(int id);
        Task<Location> GetLocation(int id);
        Task<List<Location>> GetAllLocation();
    }
}