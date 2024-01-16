using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Core.Services
{
    public class CryptService : ICryptService
    {
        /// <summary>
        /// 驗證密碼
        /// </summary>
        /// <param name="inputPassword"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool ValidatePassword(string inputPassword, string hash)
        {
            return BC.EnhancedVerify(inputPassword, hash);
        }

        /// <summary>
        /// Hash 密碼
        /// </summary>
        /// <param name="rawPassword"></param>
        /// <returns></returns>
        public string HashNewPassword(string rawPassword)
        {
            string hash = BC.EnhancedHashPassword(rawPassword, 12);
            return hash;
        }
    }
}
