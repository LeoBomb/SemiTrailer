using Core.Interface;
using Infrastructure.Data;
using Infrastructure.SemiTrailer;
using Infrastructure.SemiTrailer.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Dtos;
using UseCases.Models;
using UseCases.RepositoryInterface;

namespace Infrastructure.SemiTrailer.Queries
{
    public class UserRepository : IUserRepository
    {
        private readonly SemiTrailerDbContext _semiTrailerDbContext;
        private readonly TenantDbContext _tenantDbContext;

        public UserRepository(SemiTrailerDbContext semiTrailerDbContext, TenantDbContext tenantDbContext)
        {
            _semiTrailerDbContext = semiTrailerDbContext;
            _tenantDbContext = tenantDbContext;
        }
        public async Task<List<UserDto>> GetUserList()
        {
            var users = await _semiTrailerDbContext.User.ToListAsync();
            var userDtos = users.Select(x => new UserDto
            {
                //TODO Automapper
                Description = x.Description,
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return userDtos;
        }

        public async Task<UserLoginDto> GetLoginUser(string account, string password)
        {
            var user = await _semiTrailerDbContext.User.FirstOrDefaultAsync(x => x.Name == account || x.Email == account);
            if (user == null)
            {
                throw new Exception("user not exist");
            }
            return new UserLoginDto { Description = user.Description, Id = user.Id, Name = user.Name, Password = user.Password };
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            var user = _semiTrailerDbContext.User.FirstOrDefault(x => x.Id == userId);
            return new UserDto
            {
                Id = user.Id,
                Description = user.Description,
                Name = user.Name
            };
        }
        public async Task<int> CreateUser(CreateUserReq createUserReq)
        {
            var entity = new Data.Entity.User
            {
                Email = createUserReq.Email,
                Description = createUserReq.Descriotion,
                Name = createUserReq.Name,
                Password = createUserReq.Password
            };
            _semiTrailerDbContext.User.Add(entity);
            await _semiTrailerDbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task ResetPassword(int userId,string newPassword)
        {
            var user = await _semiTrailerDbContext.User.FirstOrDefaultAsync();
            if(user == null)
            {
                throw new Exception("User is not found");
            }
            user.Password = newPassword;
            await _semiTrailerDbContext.SaveChangesAsync();
        }

        public async Task CreateTenantDb(string connectionString)
        {
            await _tenantDbContext.CreateNewDb(connectionString);
            _tenantDbContext.Database.SetConnectionString(connectionString);
            var test = _tenantDbContext.Database.GetConnectionString();
            _tenantDbContext.Database.Migrate();
        }
    }
}
