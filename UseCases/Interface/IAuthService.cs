using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Dtos;
using UseCases.Models;

namespace UseCases.Interface
{
    public interface IAuthService
    {
        Task<UserLoginDto> LoginVerify(string account, string passward);
        Task<int> CreateUser(CreateUserReq createUserReq);
        Task<List<UserDto>> GetList();
        /// <summary>
        /// 建立一個專屬DB 給租戶
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task CreateTenantDb(int userId);
    }
}
