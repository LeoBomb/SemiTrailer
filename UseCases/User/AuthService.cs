using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Net.Http;
using UseCases.Interface;
using UseCases.Models;
using UseCases.Dtos;
using UseCases.RepositoryInterface;
using SemiTrailer;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.Extensions.Options;
using Core.Services;
using Core.Model;

namespace UseCases.User
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptService _cryptService;
        private readonly AppsettingOptions _appsettingOptions;
        private readonly ITenantService _tenantService;
        private readonly TenantContext _tenantContext;


        public AuthService(IUserRepository userRepository, ICryptService cryptService, IOptions<AppsettingOptions> appsettingOptions, ITenantService tenantService, TenantContext tenantContext)
        {
            _userRepository = userRepository;
            _cryptService = cryptService;
            _appsettingOptions = appsettingOptions.Value;
            _tenantService = tenantService;
            _tenantContext = tenantContext;
        }
        public async Task<UserLoginDto> LoginVerify(string account, string passward)
        {
            var user = await _userRepository.GetLoginUser(account, passward);
            if (user == null)
            {
                throw new Exception("User is not exist");
            }
            if (!_cryptService.ValidatePassword(passward, user.Password))
            {
                throw new Exception("The account or password is incorrect");
            }
            return user;
        }

        public async Task<int> CreateUser(CreateUserReq createUserReq)
        {
            var hash = _cryptService.HashNewPassword(createUserReq.Password);
            createUserReq.Password = hash;
            return await _userRepository.CreateUser(createUserReq);
        }
        public async Task CreateTenantDb(int userId)
        {
            var connectionString = await _tenantService.GetConnectionString(userId, _appsettingOptions.ConnectionStrings.TenantPostgreSQL_Server, _appsettingOptions.ConnectionStrings.TenantPostgreSQL_Port);
            _tenantContext.CreateDb = new TenantEntity
            {
                ConnectionString = connectionString,
                UserId = userId
            };
            await _userRepository.CreateTenantDb(connectionString);
        }
        public async Task<List<UserDto>> GetList()
        {
            var userDtos = await _userRepository.GetUserList();
            return userDtos;
        }
    }
}
