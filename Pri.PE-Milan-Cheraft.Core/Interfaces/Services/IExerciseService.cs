using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Models.Exercises;
using Pri.PE_Milan_Cheraft.Core.Models.Results;

namespace Pri.PE_Milan_Cheraft.Core.Interfaces.Services
{
    public interface IExerciseService
    {
        public Task<ResultModel<IEnumerable<Exercise>>> GetAllAsync();
        public Task<ResultModel<Exercise>> GetByIdAsync(int id);
        public Task<ResultModel<IEnumerable<Exercise>>> GetExercisesByMuscleGroupIdAsync(int genreId);
        public Task<ResultModel<Exercise>> CreateAsync(ExerciseCreateRequestModel exerciseCreateRequestModel);
        public Task<ResultModel<Exercise>> UpdateAsync(ExerciseUpdateRequestModel exerciseUpdateRequestModel);
        public Task<ResultModel<Exercise>> DeleteAsync(int id);
        public Task<ResultModel<IEnumerable<Exercise>>> GetExercisesByMuscleGroupNameAsync(string name);
        public Task<ResultModel<IEnumerable<Exercise>>> GetExercisesByNameAsync(string name);

    }
}
