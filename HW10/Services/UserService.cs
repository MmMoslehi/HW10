using HW10.Contracts;
using HW10.Entities;
using HW10.Enums;
using Newtonsoft.Json;

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
            .Where(x => x.UserName.StartsWith(s))
            .Select(x => (x.UserName, x.Status))
            .ToList();
    }

    public Result ChangePassword(string userName, string oldPass, string newPass)
    {
        var entities = _userReop.GetAll();
        var entity = entities.FirstOrDefault(x => x.UserName == userName && x.Password == oldPass);
        entity.Password = newPass;
        _userReop.Set(entities);
        return new Result(true, "changePass successful");
        
    }

    #endregion
}
