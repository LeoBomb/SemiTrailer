using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Dtos
{
    public class UserLoginDto : UserDto
    {
        public string Password { get; set; }
    }
}
