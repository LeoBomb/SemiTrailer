using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ICryptService
    {
        bool ValidatePassword(string inputPassword, string hash);
        string HashNewPassword(string rawPassword);
    }
}
