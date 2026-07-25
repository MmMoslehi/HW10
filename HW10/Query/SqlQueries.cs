namespace HW10.Query;
public static class SqlQueries
{
    public static string Add { get; set; }
    public static string Select { get; set; }
    public static string SelectAll { get; set; }
    public static string SelectByPassUserName { get; set; }
    public static string Delete { get; set; }
    public static string ChangeStatus { get; set; }
    public static string UpdatePassword { get; set; }
    static SqlQueries()
    {
        Add = "INSERT INTO Users (UserName, Password, Status) VALUES (@UserName, @Password, @Status)";
        Select = "SELECT * FROM Users WHERE UserName = @UserName";
        SelectAll = "SELECT * FROM Users";
        SelectByPassUserName = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
        Delete = "DELETE FROM Users Where UserName = @UserName AND Password = @Password";
        ChangeStatus = "UPDATE Users SET Status = @Status WHERE UserName = @UserName";
        UpdatePassword = "UPDATE Users SET Password = @NewPassword WHERE UserName = @UserName AND Password = @OldPassword";
    }
}
