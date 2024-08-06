using Pri.PE_Milan_Cheraft.Core.Entities;

namespace Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories
{
    public interface IWorkoutRepository : IBaseRepository<Workout>
    {
        Task<IEnumerable<Workout>> GetWorkoutsByMuscleGroupIdAsync(int id);
        Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(string id);
        Task<IEnumerable<Workout>> GetWorkoutsByNameAsync(string name);
        Task<IEnumerable<Workout>> GetWorkoutByNameExactlyAsync(string name);
    }
}
