using WebApi.Controllers.Request;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using WebApi.Models;

namespace WebApi.Services;

public static class UserService
{
    public static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        Console.WriteLine($"Hashed: {hashed}");

        return hashed;
    }

    public static User UserInstance(RegisterRequest userRequest)
    {
        var user = new User();

        if (userRequest.Password != null)
        {
            user.Email = userRequest.Email;
            user.Name = userRequest.Name;
            user.Password = HashPassword(userRequest.Password);
        };

        return user;
    }
}
