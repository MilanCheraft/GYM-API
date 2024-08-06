using Microsoft.EntityFrameworkCore;
using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Services;
using Pri.PE_Milan_Cheraft.Core.Models.Exercises;
using Pri.PE_Milan_Cheraft.Core.Models.Results;

namespace Pri.PE_Milan_Cheraft.Core.Services.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<ResultModel<Exercise>> CreateAsync(ExerciseCreateRequestModel exerciseCreateRequestModel)
        {
            if (await _exerciseRepository.GetAll().AnyAsync(e => e.Name.ToUpper() == exerciseCreateRequestModel.Name.ToUpper()))
            {
                return new ResultModel<Exercise>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Exercise already exists" }
                };
            }
            if (await _exerciseRepository.GetAll().AnyAsync(g => g.Id == exerciseCreateRequestModel.MuscleGroupId) == false)
            {
                return new ResultModel<Exercise>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Muscle group does not exist" }
                };
            }
            var exercise = new Exercise
            {
                Name = exerciseCreateRequestModel.Name,
                Description = exerciseCreateRequestModel.Description,
                MuscleGroupId = exerciseCreateRequestModel.MuscleGroupId,
                Reps = exerciseCreateRequestModel.Reps,
                Sets = exerciseCreateRequestModel.Sets,
                Weight = exerciseCreateRequestModel.Weight,
            };
            if (await _exerciseRepository.AddAsync(exercise))
            {
                return new ResultModel<Exercise>
                {
                    IsSuccess = true,
                    Value = exercise
                };
            }
            return new ResultModel<Exercise>
            {
                IsSuccess = false,
                Errors = new List<string> { "Exercise not created" }
            };
        }

        public async Task<ResultModel<Exercise>> DeleteAsync(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);
            if (exercise == null)
            {
                return new ResultModel<Exercise>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Exercise does not exist" }
                };
            }
            if (await _exerciseRepository.DeleteAsync(exercise))
            {
                return new ResultModel<Exercise>
                {
                    IsSuccess = true,
                };
            }
            return new ResultModel<Exercise>
            {
                IsSuccess = false,
                Errors = new List<string> { "Exercise not deleted" }
            };
        }

        public async Task<ResultModel<IEnumerable<Exercise>>> GetAllAsync()
        {
            var exercises = await _exerciseRepository.GetAllAsync();
            if (exercises.Count() > 0)
            {
                return new ResultModel<IEnumerable<Exercise>>
                {
                    IsSuccess = true,
                    Value = exercises
                };
            }
            return new ResultModel<IEnumerable<Exercise>>
            {
                IsSuccess = false,
                Errors = new List<string> { "No exercises found" }
            };
        }

        public async Task<ResultModel<Exercise>> GetByIdAsync(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);
            if (exercise == null)
            {
                return new ResultModel<Exercise>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Exercise does not exist" }
                };
            }
            return new ResultModel<Exercise>
            {
                IsSuccess = true,
                Value = exercise
            };
        }

        public async Task<ResultModel<IEnumerable<Exercise>>> GetExercisesByMuscleGroupIdAsync(int genreId)
        {
            var exercises = await _exerciseRepository.GetExercisesByMuscleGroupIdAsync(genreId);
            if (exercises.Count() > 0)
            {
                return new ResultModel<IEnumerable<Exercise>>
                {
                    IsSuccess = true,
                    Value = exercises
                };
            }
            return new ResultModel<IEnumerable<Exercise>>
            {
                IsSuccess = false,
                Errors = new List<string> { "No exercises found" }
            };
        }

        public async Task<ResultModel<IEnumerable<Exercise>>> GetExercisesByMuscleGroupNameAsync(string name)
        {
            var exercise = await _exerciseRepository.GetExercisesByMuscleGroupNameAsync(name);
            if (exercise.Count() > 0)
            {
                return new ResultModel<IEnumerable<Exercise>>
                {
                    IsSuccess = true,
                    Value = exercise
                };
            }
            return new ResultModel<IEnumerable<Exercise>>
            {
                IsSuccess = false,
                Errors = new List<string> { "No exercises found" }
            };
        }

        public async Task<ResultModel<IEnumerable<Exercise>>> GetExercisesByNameAsync(string name)
        {
            var exercise = await _exerciseRepository.GetExercisesByNameAsync(name);
            if (exercise.Count() > 0)
            {
                return new ResultModel<IEnumerable<Exercise>>
                {
                    IsSuccess = true,
                    Value = exercise
                };
            }
            return new ResultModel<IEnumerable<Exercise>>
            {
                IsSuccess = false,
                Errors = new List<string> { "No exercises found" }
            };
        }

        public async Task<ResultModel<Exercise>> UpdateAsync(ExerciseUpdateRequestModel exerciseUpdateRequestModel)
        {

            if (await _exerciseRepository.GetAll().AnyAsync(g => g.Id == exerciseUpdateRequestModel.MuscleGroupId) == false)
            {
                return new ResultModel<Exercise>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Muscle group does not exist" }
                };
            }
            if (await _exerciseRepository.GetAll().AnyAsync(e => e.Name.ToUpper() == exerciseUpdateRequestModel.Name.ToUpper() && e.Id != exerciseUpdateRequestModel.Id))
            {
                return new ResultModel<Exercise>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Exercise already exists" }
                };
            }
            var exercise = await _exerciseRepository.GetByIdAsync(exerciseUpdateRequestModel.Id);
            if (exercise == null)
            {
                return new ResultModel<Exercise>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Exercise does not exist" }
                };
            }

            exercise.Name = exerciseUpdateRequestModel.Name;
            exercise.Description = exerciseUpdateRequestModel.Description;
            exercise.MuscleGroupId = exerciseUpdateRequestModel.MuscleGroupId;
            exercise.Reps = exerciseUpdateRequestModel.Reps;
            exercise.Sets = exerciseUpdateRequestModel.Sets;
            exercise.Weight = exerciseUpdateRequestModel.Weight;
            if (await _exerciseRepository.UpdateAsync(exercise))
            {
                return new ResultModel<Exercise>
                {
                    IsSuccess = true,
                    Value = exercise
                };
            }
            return new ResultModel<Exercise>
            {
                IsSuccess = false,
                Errors = new List<string> { "Exercise not updated" }
            };
        }
    }
}
