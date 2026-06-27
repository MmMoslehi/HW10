using HW10.Enums;

namespace HW10.Entities;
public class User
{
    #region Properties
    public string UserName { get; set; }
    public string Password { get; set; }
    public StatusEnum Status { get; set; }
    #endregion

    #region Constractors
    public User()
    {
        
    }
    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
        Status = StatusEnum.notAvaliable;
    }
    #endregion

}
