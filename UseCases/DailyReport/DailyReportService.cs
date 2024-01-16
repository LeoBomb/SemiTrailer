using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Models;
using UseCases.RepositoryInterface;

namespace UseCases.DailyReport
{
    public class DailyReportService : IDailyReportService
    {
        private readonly IDailyReportRepository _dailyReportRepository;
        public DailyReportService(IDailyReportRepository dailyReportRepository)
        {
            _dailyReportRepository = dailyReportRepository;
        }
        public async Task Create(CreateDailyReportReq createDailyReportReq)
        {
            await _dailyReportRepository.Create(createDailyReportReq);
        }
    }
}
