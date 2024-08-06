using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pri.PE.Milan_Cheraft.Infrastructure.Data;
using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories;

namespace Pri.PE.Milan_Cheraft.Infrastructure.Repositories
{
    public class MuscleGroupRepository : BaseRepository<MuscleGroup>, IMuscleGroupRepository
    {
        public MuscleGroupRepository(ApplicationDbContext applicationDbContext, ILogger<IBaseRepository<MuscleGroup>> logger) : base(applicationDbContext, logger)
        {
        }

        public override IQueryable<MuscleGroup> GetAll()
        {
            return _table
                .Include(e => e.Exercises)
                .Include(e => e.Workouts)
                .AsQueryable();
        }

        public override async Task<IEnumerable<MuscleGroup>> GetAllAsync()
        {
            return await _table
                .Include(e => e.Exercises)
                .Include(e => e.Workouts)
                .ToListAsync();
        }

        public override async Task<MuscleGroup> GetByIdAsync(int id)
        {
            return await _table
                .Include(e => e.Exercises)
                .Include(e => e.Workouts)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<MuscleGroup>> GetMuscleGroupByNameAsync(string name)
        {
            return await _table
                .Include(e => e.Exercises)
                .Include(e => e.Workouts)
                .Where(e => e.Name.ToUpper().Contains(name.ToUpper()))
                .ToListAsync();
        }
    }
}
