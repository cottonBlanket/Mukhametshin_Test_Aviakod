namespace Mukhametshin_Test_Aviakod.Domain.Helpers;

public static class Db
{
    public const string CollationName = "ru-RU-x-icu";
    
    public static string ContainsPattern(string expression) => $"%{expression}%";
}