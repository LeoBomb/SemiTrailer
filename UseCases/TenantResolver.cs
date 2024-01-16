using Core.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SemiTrailer;
using Core.Model;
using UseCases;
using UseCases.RepositoryInterface;
namespace Infrastructure.Tenant
{
    public class TenantResolver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<int, TenantEntity> _TenantDictionary = new Dictionary<int, TenantEntity>();
        private readonly AppsettingOptions _appsettingOptions;
        private readonly ITenantService _tenantService;
        public TenantResolver(IServiceProvider serviceProvider, IOptions<AppsettingOptions> options, ITenantService tenantService)
        {
            _serviceProvider = serviceProvider;
            _appsettingOptions = options.Value;
            _tenantService = tenantService;
        }
        public async Task<TenantEntity> ResolveByLogin(int userId)
        {
            if (_TenantDictionary.TryGetValue(userId, out var tenant))
            {
                return tenant;
            }
            var userRepository = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IUserRepository>();
            var user = userRepository.GetUserById(userId);
            var newTenant = new TenantEntity
            {
                UserId = user.Id,
                ConnectionString = await _tenantService.GetConnectionString(user.Id, _appsettingOptions.ConnectionStrings.TenantPostgreSQL_Server, _appsettingOptions.ConnectionStrings.TenantPostgreSQL_Port)
            };
            _TenantDictionary.Add(user.Id, newTenant);
            return newTenant;
        }
    }
}
