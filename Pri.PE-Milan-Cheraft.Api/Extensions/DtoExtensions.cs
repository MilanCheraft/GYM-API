using Pri.PE_Milan_Cheraft.Api.Dtos;
using Pri.PE_Milan_Cheraft.Api.Dtos.Exercises;
using Pri.PE_Milan_Cheraft.Api.Dtos.MuscleGroups;
using Pri.PE_Milan_Cheraft.Api.Dtos.Users;
using Pri.PE_Milan_Cheraft.Api.Dtos.Workouts;
using Pri.PE_Milan_Cheraft.Core.Entities;

namespace Pri.PE_Milan_Cheraft.Api.Extensions
{
    public static class DtoExtensions
    {
        public static MuscleGroupResponseDto MapToDto(this MuscleGroup muscleGroup)
        {
            return new MuscleGroupResponseDto
            {
                Id = muscleGroup.Id,
                Name = muscleGroup.Name
            };
        }
        public static MuscleGroupsResponseDto MapToDto(this IEnumerable<MuscleGroup> muscleGroups)
        {
            return new MuscleGroupsResponseDto
            {
                MuscleGroups = muscleGroups.Select(mg => new BaseDto
                {
                    Id = mg.Id,
                    Name = mg.Name,

                })
            };
        }
        public static ExercisesResponseDto MapToDto(this IEnumerable<Exercise> exercises)
        {
            return new ExercisesResponseDto
            {
                Exercises = exercises.Select(e => new ExerciseResponseDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    MuscleGroupId = e.MuscleGroupId,
                    Reps = e.Reps,
                    Sets = e.Sets,
                    Weight = e.Weight,
                })
            };
        }
        public static ExerciseResponseDto MapToDto(this Exercise exercise)
        {
            return new ExerciseResponseDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                MuscleGroupId = exercise.MuscleGroupId,
                Reps = exercise.Reps,
                Sets = exercise.Sets,
                Weight = exercise.Weight,
            };
        }
        public static WorkoutResponseDto MapToDto(this Workout workout)
        {
            return new WorkoutResponseDto
            {
                Id = workout.Id,
                Name = workout.Name,
                Description = workout.Description,
                Duration = workout.Duration,
                User = new BaseUserDto
                {
                    Id = workout.User.Id,
                    Name = workout.User.UserName
                },
                Exercises = workout.Exercises.Select(e => new ExerciseResponseDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    MuscleGroupId = e.MuscleGroupId,
                    Reps = e.Reps,
                    Sets = e.Sets,
                    Weight = e.Weight,
                }),
                MuscleGroup = new BaseDto
                {
                    Id = workout.MuscleGroup.Id,
                    Name = workout.MuscleGroup.Name
                }
            };
        }
        public static WorkoutsResponseDto MapToDto(this IEnumerable<Workout> workouts)
        {
            return new WorkoutsResponseDto
            {
                Workouts = workouts.Select(w => new WorkoutResponseDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    Duration = w.Duration,
                    User = new BaseUserDto
                    {
                        Id = w.User.Id,
                        Name = w.User.UserName
                    },
                    Exercises = w.Exercises.Select(e => new ExerciseResponseDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        MuscleGroupId = e.MuscleGroupId,
                        Reps = e.Reps,
                        Sets = e.Sets,
                        Weight = e.Weight,
                    }),
                    MuscleGroup = new BaseDto
                    {
                        Id = w.MuscleGroup.Id,
                        Name = w.MuscleGroup.Name
                    }
                })
            };
        }
        public static UserResponseDto MapToDto(this User user)
        {
            return new UserResponseDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Length = user.Length,
                Weight = user.Weight,
            };
        }
        public static UsersDto MapToDto(this IEnumerable<User> users)
        {
            return new UsersDto
            {
                Users = users.Select(u => new BaseUserDto
                {
                    Id = u.Id,
                    Name = u.UserName
                })
            };
        }
    }
}
