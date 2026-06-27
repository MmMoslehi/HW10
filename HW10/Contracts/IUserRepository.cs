using HW10.Entities;
using HW10.Enums;
using HW10.Services;

namespace HW10.Contracts;
public interface IUserRepository
{
    void Add(User user);
    User? GetByUserNameAndPassword(string userName, string Password);
    User? GetByUserName(string userName);
    List<User> GetAll();
    void Remove(string userName, string password);
    Result ChangeStatus(string userName, StatusEnum @enum);
    void Set(List<User> u);
}
