using System.ComponentModel.DataAnnotations;

namespace Pri.PE_Milan_Cheraft.Api.Dtos.Exercises
{
    public class ExerciseUpdateRequestDto : ExerciseCreateRequestDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
    }
}
