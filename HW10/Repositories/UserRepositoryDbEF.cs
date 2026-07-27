using HW10.Contracts;
using HW10.Entities;
using HW10.Enums;
using HW10.Services;

namespace HW10.Repositories;
public class UserRepositoryDbEF : IUserRepository
{
    #region Properties
    WebDbContext _webDbContext;
    #endregion
    #region Constractor
    public UserRepositoryDbEF(WebDbContext webDbContext)
    {
        _webDbContext = webDbContext;
    }
    #endregion
    public void Add(User user)
    {
        _webDbContext.Users.Add(user);
        _webDbContext.SaveChanges();
    }

    public Result ChangeStatus(string userName, StatusEnum @enum)
    {
        var st = _webDbContext.Users.FirstOrDefault(x => x.UserName == userName);
        if (st is null)
            return new Result(false);
        st.Status = @enum;
        _webDbContext.SaveChanges();
        return new Result(true, "successful");
    }

    public List<User> GetAll()
    {
        return _webDbContext.Users.ToList();
    }

    public User? GetByUserName(string userName)
    {
        return _webDbContext.Users.FirstOrDefault(x => x.UserName == userName);
    }

    public User? GetByUserNameAndPassword(string userName, string Password)
    {
        return _webDbContext.Users.FirstOrDefault(x => x.UserName == userName && x.Password == Password);
    }

    public void Remove(string userName, string password)
    {
        var entity = _webDbContext.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        if (entity is not null)
        {
            _webDbContext.Users.Remove(entity!);
            _webDbContext.SaveChanges();
        }
    }

    public void Set(List<User> u)
    {
        throw new NotImplementedException();
    }

    public Result UpdatePassword(string userName, string oldPass, string newPass)
    {
        var entity = _webDbContext.Users.FirstOrDefault(x => x.UserName == userName && x.Password == oldPass);
        if (entity is null)
        {
            return new Result(false, "user is not found.");
        }
        entity.Password = newPass;
        _webDbContext.SaveChanges();
        return new Result(true, "update pass is successful.");
    }
}
