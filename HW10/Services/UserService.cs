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
        using (SqlConnection db = new SqlConnection(ConnectionString.Connectionstring))
        {
            int im = db.Execute(SqlQueries.UpdatePassword, new { UserName = userName, OldPassword = oldPass, NewPassword = newPass });
            return im > 0
                ? new Result(true, "successful")
                : new Result(false);
        }
    }

    #endregion
}
