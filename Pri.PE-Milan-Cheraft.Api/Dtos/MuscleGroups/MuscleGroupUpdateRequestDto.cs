using System.ComponentModel.DataAnnotations;

namespace Pri.PE_Milan_Cheraft.Api.Dtos.MuscleGroups
{
    public class MuscleGroupUpdateRequestDto : MuscleGroupCreateRequestDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
    }
}
