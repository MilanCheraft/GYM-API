using System.ComponentModel.DataAnnotations;

namespace Pri.PE_Milan_Cheraft.Api.Dtos.Workouts
{
    public class WorkoutUpdateRequestDto : WorkoutCreateRequestDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
    }
}
