using System.ComponentModel.DataAnnotations;

namespace Pri.PE_Milan_Cheraft.Api.Dtos.MuscleGroups
{
    public class MuscleGroupCreateRequestDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
