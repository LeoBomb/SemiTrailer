using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ITenantService
    {
        Task<string> GetConnectionString(int userId, string serverName, int port);
    }
}
