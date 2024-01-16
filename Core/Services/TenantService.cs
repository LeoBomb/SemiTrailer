using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class TenantService : ITenantService
    {
        public async Task<string> GetConnectionString(int userId, string serverName, int port)
        {
            var connectionString = $"Server={serverName};Port={port};Database=Tenant_{userId};User Id=postgres;Password=postgresqlPass;Minimum Pool Size=5;Maximum Pool Size=50";
            return connectionString;
        }
    }
}
