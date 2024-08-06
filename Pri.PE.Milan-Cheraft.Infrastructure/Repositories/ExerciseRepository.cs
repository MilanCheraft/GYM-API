using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pri.PE.Milan_Cheraft.Infrastructure.Data;
using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories;

namespace Pri.PE.Milan_Cheraft.Infrastructure.Repositories
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ApplicationDbContext applicationDbContext, ILogger<IBaseRepository<Exercise>> logger) : base(applicationDbContext, logger)
        {
        }

        public override IQueryable<Exercise> GetAll()
        {
            return _table
                .Include(e => e.MuscleGroup)
                .AsQueryable();
        }

        public override async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            return await _table
                .Include(e => e.MuscleGroup)
                .ToListAsync();
        }

        public override async Task<Exercise> GetByIdAsync(int id)
        {
            return await _table
                .Include(e => e.MuscleGroup)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Exercise>> GetExercisesByMuscleGroupIdAsync(int id)
        {
            return await _table
                .Include(e => e.MuscleGroup)
                .Where(e => e.MuscleGroupId == id)
                .ToListAsync();
        }


        public async Task<IEnumerable<Exercise>> GetExercisesByMuscleGroupNameAsync(string name)
        {
            return await _table
               .Include(e => e.MuscleGroup)
               .Where(e => e.MuscleGroup.Name.ToUpper() == name.ToUpper())
               .ToListAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name)
        {
            return await _table
                .Include(e => e.MuscleGroup)
                .Where(e => e.Name.ToUpper().Contains(name))
                .ToListAsync();
        }
    }
}
