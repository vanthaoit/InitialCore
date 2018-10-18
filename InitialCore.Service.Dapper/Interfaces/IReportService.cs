using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InitialCore.Service.Dapper.ViewModels;

namespace InitialCore.Service.Dapper.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate);
    }
}
