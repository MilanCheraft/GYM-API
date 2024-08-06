using Pri.PE_Milan_Cheraft.Core.Entities;

namespace Pri.PE_Milan_Cheraft.Api.Dtos.Users
{
    public class UserResponseDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public IEnumerable<BaseDto> Workouts { get; set; }
    }
}
