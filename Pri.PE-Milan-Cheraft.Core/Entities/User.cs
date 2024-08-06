using Microsoft.AspNetCore.Identity;

namespace Pri.PE_Milan_Cheraft.Core.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public ICollection<Workout> Workouts { get; set; }
    }
}
