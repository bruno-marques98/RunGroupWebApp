using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Service
{
    public class RaceService : IRaceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RaceService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Race race)
        {
            _dbContext.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _dbContext.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAllRaces()
        {
            return await _dbContext.Races.ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetRacesByCity(string city)
        {
            return await _dbContext.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }
        public async Task<Race> GetRaceByIdAsyncNoTracking(int id)
        {
            return await _dbContext.Races.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Race> GetRacesByIdAsync(int id)
        {
            return await _dbContext.Races.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            int saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race race)
        {
            _dbContext.Update(race);
            return Save();
        }
    }
}
