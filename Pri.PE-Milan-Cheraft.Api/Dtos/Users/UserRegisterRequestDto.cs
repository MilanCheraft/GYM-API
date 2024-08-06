using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Pri.PE_Milan_Cheraft.Api.Dtos.Users
{
    public class UserRegisterRequestDto : UserLoginRequestDto
    {
        [HiddenInput]
        [Required]
        public bool IsTrainer { get; set; }
        [Required(ErrorMessage = "Please enter a first name")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your repeat password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string RepeatPassword { get; set; }
        [Required(ErrorMessage ="Please enter your date of birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage ="Please enter a weight")]
        [Range(0, int.MaxValue, ErrorMessage ="Weight can not be less than 0")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Please enter a length")]
        [Range(0,300, ErrorMessage ="Length can not be less than 0")]
        public double Length { get; set; }
        [Required(ErrorMessage ="Please enter your username")]
        [MaxLength(50)]
        public string DisplayName { get; set; }
    }
}
