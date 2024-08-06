using Microsoft.AspNetCore.Identity;
using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Services;
using Pri.PE_Milan_Cheraft.Core.Models.Results;
using Pri.PE_Milan_Cheraft.Core.Models.Users;
using System.Security.Claims;

namespace Pri.PE_Milan_Cheraft.Core.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<AuthenticateResultModel> LoginAsync(UserLoginRequestModel loginModel)
        {
            var login = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, true, false);
            if (login.Succeeded == false)
            {
                return new AuthenticateResultModel
                {
                    IsSuccess = false,
                    Messages = new List<string> { "Login failed!" }
                };
            }
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            var claims = (List<Claim>)await _userManager.GetClaimsAsync(user);
            var token = _jwtService.GenerateToken(claims);
            var serializedToken = _jwtService.SerializeToken(token);
            return new AuthenticateResultModel { IsSuccess = true, Token = serializedToken };
        }

        public async Task<AuthenticateResultModel> RegisterAsync(UserCreateRequestModel registerModel)
        {
            var applicationUser = new User
            {
                UserName = registerModel.Email,
                Email = registerModel.Email,
                BirthDate = registerModel.BirthDate,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Weight = registerModel.Weight,
                Length = registerModel.Length,
                DisplayName = registerModel.DisplayName,
                EmailConfirmed = true

            };
            var userByUsername = await _userManager.FindByNameAsync(applicationUser.UserName);
            if (userByUsername != null)
            {
                return new AuthenticateResultModel
                {
                    Messages = new List<string> { "Email is already taken" }
                };
            }

            var result = await _userManager.CreateAsync(applicationUser, registerModel.Password);
            if (result.Succeeded == false)
            {
                return new AuthenticateResultModel
                {
                    Messages = new List<string> { "Registration failed!" }
                };
            }
            applicationUser = await _userManager.FindByEmailAsync(registerModel.Email);
            //add claims
            await _userManager.AddClaimAsync(applicationUser, new Claim(ClaimTypes.DateOfBirth, applicationUser.BirthDate.ToString()));
            await _userManager.AddClaimAsync(applicationUser, new Claim(ClaimTypes.Role, "Client"));
            await _userManager.AddClaimAsync(applicationUser, new Claim(ClaimTypes.Name, applicationUser.UserName));
            await _userManager.AddClaimAsync(applicationUser, new Claim(ClaimTypes.NameIdentifier, applicationUser.Id));



            return new AuthenticateResultModel
            {
                IsSuccess = true,
                Messages = new List<string> { "User registered!" }
            };
        }
        public async Task<ResultModel<User>> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return new ResultModel<User>
                {
                    IsSuccess = true,
                    Value = user
                };
            }
            return new ResultModel<User>
            {
                IsSuccess = false,
                Errors = new List<string> { "No user found" }
            };
        }

        public async Task<ResultModel<User>> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                return new ResultModel<User>
                {
                    IsSuccess = true,
                    Value = user
                };
            }
            return new ResultModel<User>
            {
                IsSuccess = false,
                Errors = new List<string> { "User does not exist" }
            };
        }

        public async Task<ResultModel<User>> Update(UserUpdateRequestModel updateModel)
        {
            var user = await _userManager.FindByIdAsync(updateModel.Id);
            user.FirstName = updateModel.FirstName;
            user.LastName = updateModel.LastName;
            user.DisplayName = updateModel.DisplayName;
            user.Weight = updateModel.Weight;
            user.Length = updateModel.Length;
            user.BirthDate = updateModel.BirthDate;
            
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ResultModel<User>
                {
                    IsSuccess = true,
                };
            }
            return new ResultModel<User>
            {
                IsSuccess = false,
            };
        }

        public ResultModel<IEnumerable<User>> GetAll()
        {
            var users = _userManager.Users.ToList();
            var result = new ResultModel<IEnumerable<User>>
            {
                IsSuccess = true,
                Value = users.ToList(),
            };
            return result;
        }
    }
}
