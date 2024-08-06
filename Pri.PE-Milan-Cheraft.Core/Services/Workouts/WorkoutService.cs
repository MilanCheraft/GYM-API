using Microsoft.EntityFrameworkCore;
using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Services;
using Pri.PE_Milan_Cheraft.Core.Models.Results;
using Pri.PE_Milan_Cheraft.Core.Models.Workouts;
using System.Net.WebSockets;

namespace Pri.PE_Milan_Cheraft.Core.Services.Workouts
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMuscleGroupRepository _muscleGroupRepository;
        private readonly IUserService _userService;

        public WorkoutService(IWorkoutRepository workoutRepository, IExerciseRepository exerciseRepository, IUserRepository userRepository, IMuscleGroupRepository muscleGroupRepository, IUserService userService)
        {
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _muscleGroupRepository = muscleGroupRepository;
            _userService = userService;
        }

        public async Task<ResultModel<Workout>> CreateAsync(WorkoutCreateRequestModel workoutCreateRequestModel)
        {
            if (await _muscleGroupRepository.GetByIdAsync(workoutCreateRequestModel.MuscleGroupsId) == null)
            {
                return new ResultModel<Workout>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Muscle group does not exist" }
                };
            }

            var doesUserExist = await _userService.GetByIdAsync(workoutCreateRequestModel.UserId);
            if (!doesUserExist.IsSuccess)
            {
                return new ResultModel<Workout>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "User does not exist" }
                };
            }
            var workoutCheckForNameAndUser = await _workoutRepository.GetWorkoutByNameExactlyAsync(workoutCreateRequestModel.Name);
            if (workoutCheckForNameAndUser.Count() > 0)
            {
                if (workoutCheckForNameAndUser.Any(w => w.UserId == workoutCreateRequestModel.UserId))
                {
                    return new ResultModel<Workout>
                    {
                        IsSuccess = false,
                        Errors = new List<string> { "You can not add a workout with the same name" }
                    };
                }
            }

            var exercises = new List<Exercise>();
            foreach (var exerciseId in workoutCreateRequestModel.ExerciseIds)
            {
                var exercise = await _exerciseRepository.GetByIdAsync(exerciseId);
                if (exercise != null)
                {
                    exercises.Add(exercise);
                }
                else
                {
                    return new ResultModel<Workout>
                    {
                        IsSuccess = false,
                        Errors = new List<string> { "Exercise does not exist" }
                    };
                }
            }
            var workout = new Workout
            {
                Name = workoutCreateRequestModel.Name,
                Description = workoutCreateRequestModel.Description,
                MuscleGroupId = workoutCreateRequestModel.MuscleGroupsId,
                User = _userService.GetByIdAsync(workoutCreateRequestModel.UserId).Result.Value,
                Duration = workoutCreateRequestModel.Duration,
                Exercises = exercises,
            };
            if (await _workoutRepository.AddAsync(workout))
            {
                return new ResultModel<Workout>
                {
                    IsSuccess = true,
                    Value = workout
                };
            }
            return new ResultModel<Workout>
            {
                IsSuccess = false,
                Errors = new List<string> { "Workout not created" }
            };
        }

        public async Task<ResultModel<Workout>> DeleteAsync(int id)
        {
            var workout = await _workoutRepository.GetByIdAsync(id);
            if (workout == null)
            {
                return new ResultModel<Workout>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Workout does not exist" }
                };
            }
            if (await _workoutRepository.DeleteAsync(workout))
            {
                return new ResultModel<Workout>
                {
                    IsSuccess = true,
                };
            }
            return new ResultModel<Workout>
            {
                IsSuccess = false,
                Errors = new List<string> { "Workout not deleted" }
            };
        }

        public async Task<ResultModel<IEnumerable<Workout>>> GetAllAsync()
        {
            var workouts = await _workoutRepository.GetAllAsync();
            if (workouts.Count() > 0)
            {
                return new ResultModel<IEnumerable<Workout>>
                {
                    IsSuccess = true,
                    Value = workouts
                };
            }
            return new ResultModel<IEnumerable<Workout>>
            {
                IsSuccess = false,
                Errors = new List<string> { "No workouts found" }
            };
        }

        public async Task<ResultModel<Workout>> GetByIdAsync(int id)
        {
            var workout = await _workoutRepository.GetByIdAsync(id);
            if (workout == null)
            {
                return new ResultModel<Workout>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Workout not found" }
                };
            }
            return new ResultModel<Workout>
            {
                IsSuccess = true,
                Value = workout
            };
        }

        public async Task<ResultModel<IEnumerable<Workout>>> GetWorkoutByNameAsync(string name)
        {
            var workouts = await _workoutRepository.GetWorkoutsByNameAsync(name);
            if (workouts.Count() == 0)
            {
                return new ResultModel<IEnumerable<Workout>>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Workout not found" }
                };
            }
            return new ResultModel<IEnumerable<Workout>>
            {
                IsSuccess = true,
                Value = workouts
            };
        }

        public async Task<ResultModel<IEnumerable<Workout>>> GetWorkoutsByMuscleGroupIdAsync(int muscleGroupId)
        {
            var workouts = await _workoutRepository.GetWorkoutsByMuscleGroupIdAsync(muscleGroupId);
            if (workouts.Count() > 0)
            {
                return new ResultModel<IEnumerable<Workout>>
                {
                    IsSuccess = true,
                    Value = workouts
                };
            }
            return new ResultModel<IEnumerable<Workout>>
            {
                IsSuccess = false,
                Errors = new List<string> { "No workouts found" }
            };
        }

        public async Task<ResultModel<IEnumerable<Workout>>> GetWorkoutsByUserIdAsync(string userId)
        {
            var workouts = await _workoutRepository.GetWorkoutsByUserIdAsync(userId);
            return new ResultModel<IEnumerable<Workout>>
            {
                IsSuccess = true,
                Value = workouts
            };

        }

        public async Task<ResultModel<Workout>> UpdateAsync(WorkoutUpdateRequestModel workoutUpdateRequestModel)
        {

            if (await _muscleGroupRepository.GetByIdAsync(workoutUpdateRequestModel.MuscleGroupsId) == null)
            {
                return new ResultModel<Workout>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Muscle group does not exist" }
                };
            }
            var muscleGroup = await _muscleGroupRepository.GetByIdAsync(workoutUpdateRequestModel.MuscleGroupsId);
            var doesUserExist = await _userService.GetByIdAsync(workoutUpdateRequestModel.UserId);
            if (!doesUserExist.IsSuccess)
            {
                return new ResultModel<Workout>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "User does not exist" }
                };
            }


            var exercisesId = new List<Exercise>();
            foreach (var exerciseId in workoutUpdateRequestModel.ExerciseIds)
            {
                var exercise = await _exerciseRepository.GetByIdAsync(exerciseId);
                exercisesId.Add(exercise);
            }
            var workout = await _workoutRepository.GetByIdAsync(workoutUpdateRequestModel.Id);
            if (workout == null)
            {
                return new ResultModel<Workout>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Workout does not exist" }
                };
            }
            workout.Name = workoutUpdateRequestModel.Name;
            workout.Description = workoutUpdateRequestModel.Description;
            workout.MuscleGroupId = muscleGroup.Id;
            workout.UserId = workoutUpdateRequestModel.UserId;
            workout.Duration = workoutUpdateRequestModel.Duration;
            workout.Exercises = exercisesId;
            if (await _workoutRepository.UpdateAsync(workout))
            {
                return new ResultModel<Workout>
                {
                    IsSuccess = true,
                    Value = workout
                };
            }
            return new ResultModel<Workout>
            {
                IsSuccess = false,
                Errors = new List<string> { "Workout not updated" }
            };
        }

    }
}
