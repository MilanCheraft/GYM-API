using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pri.PE.Milan_Cheraft.Infrastructure.Data;
using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories;

namespace Pri.PE.Milan_Cheraft.Infrastructure.Repositories
{
    public class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(ApplicationDbContext applicationDbContext, ILogger<IBaseRepository<Workout>> logger) : base(applicationDbContext, logger)
        {
        }

        public override IQueryable<Workout> GetAll()
        {
            return _table
                .Include(w => w.MuscleGroup)
                .Include(w => w.Exercises)
                .Include(w => w.User)
                .AsQueryable();
        }

        public override async Task<IEnumerable<Workout>> GetAllAsync()
        {
            return await _table
                .Include(w => w.MuscleGroup)
                .Include(w => w.Exercises)
                .Include(w => w.User)
                .ToListAsync();
        }

        public override async Task<Workout> GetByIdAsync(int id)
        {
            return await _table
                .Include(w => w.MuscleGroup)
                .Include(w => w.Exercises)
                .Include(w => w.User)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsByMuscleGroupIdAsync(int id)
        {
            return await _table
                .Include(w => w.MuscleGroup)
                .Include(w => w.Exercises)
                .Include(w => w.User)
                .Where(w => w.MuscleGroupId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsByNameAsync(string name)
        {
            return await _table
                .Include(w => w.MuscleGroup)
                .Include(w => w.Exercises)
                .Include(w => w.User)
                .Where(w => w.Name.ToUpper().Contains(name.ToUpper()))
                .ToListAsync();
        }
        public async Task<IEnumerable<Workout>> GetWorkoutByNameExactlyAsync(string name)
        {
            return await _table
                .Include(w => w.MuscleGroup)
                .Include(w => w.Exercises)
                .Include(w => w.User)
                .Where(w => w.Name.ToUpper().Equals(name.ToUpper()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(string id)
        {
            return await _table
                .Include(w => w.MuscleGroup)
                .Include(w => w.Exercises)
                .Include(w => w.User)
                .Where(w => w.UserId == id)
                .ToListAsync();
        }
    }
}
