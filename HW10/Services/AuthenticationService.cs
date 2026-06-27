using HW10.Contracts;
using HW10.Entities;
using HW10.Repositories;
using Newtonsoft.Json;

namespace HW10.Services;
public class AuthenticationService : IAuthenticationSevice
{
    #region Fild
    private IUserRepository _repository;
    private string _currentUserFilePath;
    #endregion

    #region Constractors
    public AuthenticationService(IUserRepository repo)
    {
        _repository = repo;
        _currentUserFilePath = "Database/CurrentUser.json";
        if (!File.Exists(_currentUserFilePath))
            File.WriteAllText(_currentUserFilePath, "[]");
    }
    #endregion

    public Result Login(string userName, string password)
    {
        var entity = _repository.GetByUserNameAndPassword(userName, password);
        if (entity is null)
            return new Result(false, "your username of password is wrong, please try again.");
        SetCurrentUser(userName);
        return new Result(true, "successful");
    }

    public Result Register(User user)
    {
        var entity = _repository.GetByUserName(user.UserName);
        if (entity is not null)
            return new Result(false, "register failed! username already exists.");
        _repository.Add(user);
        return new Result(true, "successful");
    }

    public string? GetCurrentUser()
    {
        var data = File.ReadAllText(_currentUserFilePath);
        var entity = JsonConvert.DeserializeObject<string>(data);
        return entity;
    }

    public void SetCurrentUser(string userName)
    {
        var entity = userName;
        var data = JsonConvert.SerializeObject(entity);
        File.WriteAllText(_currentUserFilePath, data);
    }
}
