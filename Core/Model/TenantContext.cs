using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class TenantContext
    {
        public TenantEntity Tenant { get; set; }
        public TenantEntity CreateDb { get; set; }
    }
}
