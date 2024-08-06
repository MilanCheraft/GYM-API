using System.ComponentModel.DataAnnotations;

namespace Pri.PE_Milan_Cheraft.Api.Dtos.Users
{
    public class UserLoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
