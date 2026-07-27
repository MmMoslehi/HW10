using Dapper;
using HW10.Connercton;
using HW10.Contracts;
using HW10.Entities;
using HW10.Enums;
using HW10.Query;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace HW10.Services;
public class UserService : IUserService
{
    private IUserRepository _userReop { get; set; }
    public UserService(IUserRepository userRepo)
    {
        _userReop = userRepo;
    }
    #region Methods
    public List<(string userName, StatusEnum status)>? Search(string s)
    {
        return _userReop.GetAll()
            .Select(x => (x.UserName, x.Status))
            .Where(x => x.UserName.StartsWith(s))
            .ToList();
    }

    public Result ChangePassword(string userName, string oldPass, string newPass)
    {
        return _userReop.UpdatePassword(userName, oldPass, newPass);
    }

    #endregion
}
