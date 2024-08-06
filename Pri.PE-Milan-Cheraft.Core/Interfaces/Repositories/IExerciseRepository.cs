using Pri.PE_Milan_Cheraft.Core.Entities;

namespace Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories
{
    public interface IExerciseRepository : IBaseRepository<Exercise>
    {
        Task<IEnumerable<Exercise>> GetExercisesByMuscleGroupIdAsync(int id);
        Task<IEnumerable<Exercise>> GetExercisesByMuscleGroupNameAsync(string name);
        Task<IEnumerable<Exercise>> GetExercisesByNameAsync(string name);
    }
}
