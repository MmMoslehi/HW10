using HW10.Entities;
using HW10.Services;

namespace HW10.Contracts;
public interface IAuthenticationSevice
{
    Result Register(User user);
    Result Login(string userName, string password);
    string? GetCurrentUser();
}
