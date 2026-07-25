using Dapper;
using HW10.Contracts;
using HW10.Entities;
using HW10.Enums;
using HW10.Query;
using HW10.Services;
using System.Data.SqlClient;

namespace HW10.Repositories;
public class UserRepositoryDb : IUserRepository
{
    public void Add(User user)
    {
        using (SqlConnection db = new SqlConnection(Connercton.ConnectionString.Connectionstring))
        {
            db.Execute(SqlQueries.Add, user);
        }
    }

    public Result ChangeStatus(string userName, StatusEnum @enum)
    {
        using (SqlConnection db = new SqlConnection(Connercton.ConnectionString.Connectionstring))
        {
            int rows = db.Execute(SqlQueries.ChangeStatus, new { UserName = userName, Status = @enum });
            return rows > 0
            ? new Result(true, "successful")
            : new Result(false);
        }
    }

    public List<User> GetAll()
    {
        using (SqlConnection db = new SqlConnection(Connercton.ConnectionString.Connectionstring))
        {
            return db.Query<User>(SqlQueries.SelectAll).ToList();
        }
    }

    public User? GetByUserName(string userName)
    {
        using (SqlConnection db = new SqlConnection(Connercton.ConnectionString.Connectionstring))
        {
            return db.QueryFirstOrDefault<User>(SqlQueries.Select, new { UserName = userName });
        }
    }

    public User? GetByUserNameAndPassword(string userName, string password)
    {
        using (SqlConnection db = new SqlConnection(Connercton.ConnectionString.Connectionstring))
        {
            return db.QueryFirstOrDefault<User>(SqlQueries.SelectByPassUserName, new { UserName = userName, Password = password });
        }
    }

    public void Remove(string userName, string password)
    {
        using (SqlConnection db = new SqlConnection(Connercton.ConnectionString.Connectionstring))
        {
            db.Execute(SqlQueries.Delete, new { UserName = userName, Password = password });
        }
    }

    public void Set(List<User> u)
    {
        throw new NotImplementedException();
    }
}
