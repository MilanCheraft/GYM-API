using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pri.PE_Milan_Cheraft.Core.Interfaces.Services
{
    public interface IJwtService
    {
        JwtSecurityToken GenerateToken(List<Claim> userClaims);
        string SerializeToken(JwtSecurityToken token);
    }
}
