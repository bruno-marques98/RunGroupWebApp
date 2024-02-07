using RunGroupWebApp.Models;

namespace RunGroupWebApp.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAllClubs();
        Task<Club> GetClubByIdAsync(int id);
        Task<IEnumerable<Club>> GetClubByCity(string city);
        bool Add(Club club);
        bool Delete(Club club);
        bool Update(Club club);
        bool Save();
    }
}
