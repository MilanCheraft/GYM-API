using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Models.MuscleGroups;
using Pri.PE_Milan_Cheraft.Core.Models.Results;

namespace Pri.PE_Milan_Cheraft.Core.Interfaces.Services
{
    public interface IMuscleGroupService
    {
        public Task<ResultModel<IEnumerable<MuscleGroup>>> GetAllAsync();
        public Task<ResultModel<IEnumerable<MuscleGroup>>> GetMuscleGroupByNameAsync(string name);
        public Task<ResultModel<MuscleGroup>> GetByIdAsync(int id);
        public Task<ResultModel<MuscleGroup>> CreateAsync(MuscleGroupCreateRequestModel muscleGroupCreateRequestModel);
        public Task<ResultModel<MuscleGroup>> UpdateAsync(MuscleGroupUpdateRequestModel muscleGroupUpdateRequestModel);
        public Task<ResultModel<MuscleGroup>> DeleteAsync(int id);

    }
}
