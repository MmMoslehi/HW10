using HW10.Contracts;
using HW10.Entities;
using HW10.Enums;
using HW10.Services;
using Newtonsoft.Json;

namespace HW10.Repositories;
public class UserRepository : IUserRepository
{
    #region Filds
    private string _path;
    #endregion

    #region Properties
    #endregion

    #region Constractors
    public UserRepository()
    {
        if (!Directory.Exists("Database"))
            Directory.CreateDirectory("Database");
        _path = "Database/User.json";
        if (!File.Exists(_path))
            File.WriteAllText(_path, "[]");
    }
    #endregion

    #region Methods

    public void Add(User user)
    {
        var data = File.ReadAllText(_path);
        var entities = JsonConvert.DeserializeObject<List<User>>(data);
        entities!.Add(user);
        data = JsonConvert.SerializeObject(entities);
        File.WriteAllText(_path, data);
    }

    public Result ChangeStatus(string userName, StatusEnum @enum)
    {
        var data = File.ReadAllText(_path);
        var entities = JsonConvert.DeserializeObject<List<User>>(data);
        var entity = entities!.FirstOrDefault(x => x.UserName == userName);
        entity!.Status = @enum;
        data = JsonConvert.SerializeObject(entities);
        File.WriteAllText(_path, data);
        return new Result(true, "change successful");
    }

    public List<User> GetAll()
    {
        var data = File.ReadAllText(_path);
        return JsonConvert.DeserializeObject<List<User>>(data)!;
    }

    public User? GetByUserName(string userName)
    {
        var data = File.ReadAllText(_path);
        var entities = JsonConvert.DeserializeObject<List<User>>(data);
        return entities!.FirstOrDefault(x => x.UserName == userName);
    }

    public User? GetByUserNameAndPassword(string userName, string password)
    {
        var data = File.ReadAllText(_path);
        var entities = JsonConvert.DeserializeObject<List<User>>(data);
        return entities!.FirstOrDefault(x => x.UserName == userName && x.Password == password);
    }

    public void Remove(string userName, string password)
    {
        var data = File.ReadAllText(_path);
        var entities = JsonConvert.DeserializeObject<List<User>>(data);
        entities.Remove(entities!.FirstOrDefault(x => x.UserName == userName && x.Password == password)!);
        data = JsonConvert.SerializeObject(entities);
        File.WriteAllText(_path, data);
    }

    public void Set(List<User> u)
    {
        var data = JsonConvert.SerializeObject(u);
        File.WriteAllText(_path, data);
    }

    public void Update(string userName, User newUser)
    {
        var data = File.ReadAllText(_path);
        var entities = JsonConvert.DeserializeObject<List<User>>(data);
        var entity = entities!.FirstOrDefault(x => x.UserName == userName);
        entity.UserName = newUser.UserName;
        entity.Password = newUser.Password;
        entity.Status = newUser.Status;
        data = JsonConvert.SerializeObject(entities);
        File.WriteAllText(_path, data);
    }

    #endregion
}
