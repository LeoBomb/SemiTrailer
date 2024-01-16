using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.RepositoryInterface
{
    public interface IDailyReportRepository
    {
        Task Create(CreateDailyReportReq createDailyReportReq);
    }
}
