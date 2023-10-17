using Cryptography.Contracts;
using Cryptography.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Cryptography.Cryptors
{
    public class Sha256Algorithm : ICryptorAlgorithm
    {
        public ValidationModel Crypt(string word)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            var hash = KeyDerivation.Pbkdf2(
                password: word,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8);

            return new KeyPairModel()
            {
                Key = Convert.ToBase64String(hash),
                Value = Convert.ToBase64String(salt)
            };
        }

        public bool Validate(string word, ValidationModel model)
        {
            var hash = KeyDerivation.Pbkdf2(
                password: word,
                salt: Convert.FromBase64String(((KeyPairModel)model).Value!),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8);

            return string.Equals(Convert.ToBase64String(hash),
                ((KeyPairModel)model).Key,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
