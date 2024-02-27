using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Service
{
    public class ClubService : IClubRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ClubService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Club club)
        {
            _dbContext.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _dbContext.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAllClubs()
        {
            return await _dbContext.Clubs.ToListAsync();
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _dbContext.Clubs.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Club> GetClubByIdAsyncNoTracking(int id)
        {
            return await _dbContext.Clubs.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Club> GetClubByIdAsync(int id)
        {
            return await _dbContext.Clubs.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }


        public bool Save()
        {
            int saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }


        public bool Update(Club club)
        {
            _dbContext.Update(club);
            return Save();
        }
    }
}
