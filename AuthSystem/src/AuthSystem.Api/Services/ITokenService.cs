using AuthSystem.Api.Dtos;

namespace AuthSystem.Api.Services;

public interface ITokenService
{
    public string GenerateToken(UserTokenDto tokenDto);
}
