using System.ComponentModel.DataAnnotations;

namespace Pri.PE_Milan_Cheraft.Api.Dtos.Workouts
{
    public class WorkoutCreateRequestDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "ExerciseIds is required")]
        public IEnumerable<int> ExerciseIds { get; set; }
        [Required(ErrorMessage = "MuscleGroupIds is required")]
        public int MuscleGroupId { get; set; }
    }
}
