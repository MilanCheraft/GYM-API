using System.ComponentModel.DataAnnotations;

namespace Pri.PE_Milan_Cheraft.Api.Dtos.Exercises
{
    public class ExerciseCreateRequestDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "MuscleGroupId is required")]
        public int MuscleGroupId { get; set; }
        [Required(ErrorMessage = "Reps is required")]
        public int Reps { get; set; }
        [Required(ErrorMessage = "Sets is required")]
        public int Sets { get; set; }
        [Required(ErrorMessage = "Weight is required")]
        public double Weight { get; set; }
    }
}
