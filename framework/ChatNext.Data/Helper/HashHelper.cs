using System.Security.Cryptography;
using System.Text;

namespace ChatNext.Data.Helper;

public static class HashHelper
{
    /// <summary>
    /// Hash password
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string HashPassword(string input, string salt)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input + salt));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
}