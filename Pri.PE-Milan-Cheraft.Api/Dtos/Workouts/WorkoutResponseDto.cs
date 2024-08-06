using Pri.PE_Milan_Cheraft.Api.Dtos.Exercises;
using Pri.PE_Milan_Cheraft.Api.Dtos.Users;

namespace Pri.PE_Milan_Cheraft.Api.Dtos.Workouts
{
    public class WorkoutResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public BaseUserDto User { get; set; }
        public IEnumerable<ExerciseResponseDto> Exercises { get; set; }
        public BaseDto MuscleGroup { get; set; }
    }
}