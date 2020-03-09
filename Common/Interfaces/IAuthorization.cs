using Common.DTO;
using Microsoft.Extensions.Configuration;

namespace Common.Interfaces
{
    public interface IAuthorization
    {
        LoginResponse Login(LoginRequest loginRequest);
    }
}
