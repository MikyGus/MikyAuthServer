namespace MikyAuth.Library.Entities;

public class AuthServerOption
{
    public string DB_Adress { get; set; } = "127.0.0.1";
    public int DB_Port { get; set; } = 3036;
    public string DB_Database { get; set; } = "authServerDb";
    public string DB_User { get; set; } = "user";
    public string DB_Password { get; set; } = "password";

    public string ConnectionString =>
        $"Server={DB_Adress};Port={DB_Port};Database={DB_Database};Uid={DB_User};Pwd={DB_Password};";
}