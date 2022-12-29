﻿using Breadr.Service.Statistic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Statistic
{
    public interface IStatisticService
    {
        Task<StatisticsResponse> GetStatistics(StatisticsRequest request);
        Task<StatisticsResponse> GetSuccessfulPaymentStatistics(StatisticsRequest request);
        Task<StatisticsResponse> GetUnsuccessfulPaymentStatistics(StatisticsRequest request);
        Task<StatisticsByTimeResponse> GetStatisticsByHour(StatisticsByTimeRequest request);
        Task<StatisticsByTimeResponse> GetStatisticsByDay(StatisticsByTimeRequest request);
        Task<StatisticsByTimeResponse> GetStatisticsByWeek(StatisticsByTimeRequest request); 
        Task<StatisticsOfGateResponse> GetStatisticsOfGate(StatisticsOfGateRequest request); 


    }
}
