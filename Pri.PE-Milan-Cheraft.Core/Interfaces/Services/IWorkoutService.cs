using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Models.Results;
using Pri.PE_Milan_Cheraft.Core.Models.Workouts;

namespace Pri.PE_Milan_Cheraft.Core.Interfaces.Services
{
    public interface IWorkoutService
    {
        public Task<ResultModel<IEnumerable<Workout>>> GetAllAsync();
        public Task<ResultModel<Workout>> GetByIdAsync(int id);
        public Task<ResultModel<IEnumerable<Workout>>> GetWorkoutsByUserIdAsync(string userId);
        public Task<ResultModel<IEnumerable<Workout>>> GetWorkoutsByMuscleGroupIdAsync(int muscleGroupId);
        public Task<ResultModel<IEnumerable<Workout>>> GetWorkoutByNameAsync(string name);
        public Task<ResultModel<Workout>> CreateAsync(WorkoutCreateRequestModel workoutCreateRequestModel);
        public Task<ResultModel<Workout>> UpdateAsync(WorkoutUpdateRequestModel workoutUpdateRequestModel);
        public Task<ResultModel<Workout>> DeleteAsync(int id);
    }
}
