namespace Pri.PE_Milan_Cheraft.Core.Models.Users
{
    public class UserCreateRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public string DisplayName { get; set; }

    }
}
