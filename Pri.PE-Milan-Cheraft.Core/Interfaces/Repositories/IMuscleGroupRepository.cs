using Pri.PE_Milan_Cheraft.Core.Entities;

namespace Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories
{
    public interface IMuscleGroupRepository : IBaseRepository<MuscleGroup>
    {
        public Task<IEnumerable<MuscleGroup>> GetMuscleGroupByNameAsync(string name);
    }
}
