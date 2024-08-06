using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Models.Results;
using Pri.PE_Milan_Cheraft.Core.Models.Users;

namespace Pri.PE_Milan_Cheraft.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticateResultModel> RegisterAsync(UserCreateRequestModel registerModel);
        Task<AuthenticateResultModel> LoginAsync(UserLoginRequestModel loginModel);
        Task<ResultModel<User>> GetByIdAsync(string id);
        Task<ResultModel<User>> GetByEmailAsync(string email);
        Task<ResultModel<User>> Update(UserUpdateRequestModel updateModel);
        ResultModel<IEnumerable<User>> GetAll();
    }
}
