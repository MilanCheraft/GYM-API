using Microsoft.AspNetCore.Identity;
using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories;

namespace Pri.PE.Milan_Cheraft.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

    }
}
