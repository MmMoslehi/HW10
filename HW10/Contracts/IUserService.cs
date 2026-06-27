using HW10.Enums;
using HW10.Services;

namespace HW10.Contracts;
public interface IUserService
{
    List<(string userName, StatusEnum status)> Search(string s);
    Result ChangePassword(string userName, string olgPass, string newPass);
}
