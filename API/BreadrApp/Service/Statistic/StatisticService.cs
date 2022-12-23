using Breadr.Service.Statistic.Models;
using Service.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.Statistic
{
    public class StatisticService : IStatisticService
    {
        public Task<StatisticsResponse> GetStatistics(StatisticsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<StatisticsByTimeResponse> GetStatisticsByTime(StatisticsByTimeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<StatisticsResponse> GetSuccessfulPaymentStatistics(StatisticsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<StatisticsResponse> GetUnsuccessfulPaymentStatistics(StatisticsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
