using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Dtos;
using UseCases.Models;

namespace UseCases.RepositoryInterface
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetUserList();
        Task<UserLoginDto> GetLoginUser(string account, string password);
        Task<int> CreateUser(CreateUserReq createUserReq);
        Task CreateTenantDb(string connectionString);
        Task<UserDto> GetUserById(int userId);
    }
}
