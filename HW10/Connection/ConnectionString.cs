namespace HW10.Connercton;
public static class ConnectionString
{
    public static string Connectionstring { get; set; }
    static ConnectionString()
    {
        Connectionstring = "Server=localhost\\SQLEXPRESS;Database=HW10Db;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
    }
}
