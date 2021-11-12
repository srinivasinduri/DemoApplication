using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DemoWeb.Utility
{
    public class Helper
    {
        public static void LoadConfiguration(IConfiguration configuration)
        {

            //Salt = Convert.FromBase64String(configuration["SecurityConfig:salt_hash"] ?? "");
            Salt= new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(Salt);
            }
        }
        #region SecurityConfig
        public static byte[] Salt { get; internal set; }
        #endregion
    }

    /// <summary>
    /// Encrypt the Password using Hash Algorithm 
    /// Using Cryptography.KeyDerivation.Pbkdf2 Algorithm
    /// </summary>
    public class PasswordHashSecurity
    {
        /// <summary>
        /// Encrypt the Password
        /// </summary>
        /// <param name="password">Password to encrypted</param>
        /// <returns>String</returns>
        public static string HashPassword(string password)
        {
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(GetPbkdf2(password));
            return hashed;
        }

        /// <summary>
        /// Encrypting the password using KeyDerivation
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <returns>Byte array</returns>
        static byte[] GetPbkdf2(string password)
        {

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
           return KeyDerivation.Pbkdf2(
                password: password,
                salt: Helper.Salt,//generated a 128-bit salt using a secure PRNG and saved in conifguration file
                prf: KeyDerivationPrf.HMACSHA1,//Specifies the key derivation algorithm
                iterationCount: 10000,//the number of iterations of the pseudo-random function to apply during key derivation process
                numBytesRequested: 256 / 8);//Desired length of the dervied key
        }
    }
}
