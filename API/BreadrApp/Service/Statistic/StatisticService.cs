using Breadr.Service.Statistic.Dtos;
using Breadr.Service.Statistic.Models;
using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using Service.Report.Models;
using Service.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Statistic
{
    public class StatisticService : IStatisticService
    {
        private readonly BreadrDbContext _context;

        public StatisticService(BreadrDbContext context)
        {
            _context = context;

        }

        public async Task<StatisticsResponse> GetStatistics(StatisticsRequest request)
        {
            StatisticsResponse response = new StatisticsResponse()
            {
                Request = request
            };

            StatisticDto statisticDto = new StatisticDto();
            statisticDto.SelledProductsStatistics = await _context.Logs.Where
                (x => x.Action.Equals("purchase made") && x.Action.Equals("purchase declined")).CountAsync();

            response.Statistics = statisticDto;
            response.Success = true;

            return response;


        }

        public async Task<StatisticsByTimeResponse> GetStatisticsByDay(StatisticsByTimeRequest request)
        {
            StatisticsByTimeResponse response = new StatisticsByTimeResponse()
            {
                Request = request
            };

            StatisticDto statisticDto = new StatisticDto();
            statisticDto.SelledProductsStatistics = await _context.Logs.Where(x => x.Action.Equals("purchase made")
            && x.DateTime == DateTime.Now.AddDays(-request.Time)).CountAsync();

            response.SelledProductsStatistics = statisticDto;
            response.Success = true;

            return response;

        }

        public async Task<StatisticsByTimeResponse> GetStatisticsByHour(StatisticsByTimeRequest request)
        {
            StatisticsByTimeResponse response = new StatisticsByTimeResponse()
            {
                Request = request
            };

            StatisticDto statisticDto = new StatisticDto();
            statisticDto.SelledProductsStatistics = await _context.Logs.Where(x => x.Action.Equals("purchase made")
            && x.DateTime == DateTime.Now.AddHours(-request.Time)).CountAsync();

            response.SelledProductsStatistics = statisticDto;
            response.Success = true;

            return response;
        }

        public async Task<StatisticsByTimeResponse> GetStatisticsByWeek(StatisticsByTimeRequest request)
        {
            StatisticsByTimeResponse response = new StatisticsByTimeResponse()
            {
                Request = request
            };

            StatisticDto statisticDto = new StatisticDto();
            statisticDto.SelledProductsStatistics = await _context.Logs.Where(x => x.Action.Equals("purchase made")
            && x.DateTime == DateTime.Now.AddHours(-request.Time*168)).CountAsync();

            response.SelledProductsStatistics = statisticDto;
            response.Success = true;

            return response;
        }

        public async Task<StatisticsOfGateResponse> GetStatisticsOfGate(StatisticsOfGateRequest request)
        {
            StatisticsOfGateResponse response = new StatisticsOfGateResponse()
            {
                Request = request
            };

            GateStatisticDto gateStatistic = new();
            gateStatistic.TodaysStats = await _context.Logs.Where(x => x.GateId.Equals(request.GateId)
            && x.DateTime == DateTime.Today && x.Action.Equals("purchase made")).CountAsync();

            gateStatistic.YesterdaysStats = await _context.Logs.Where(x => x.GateId.Equals(request.GateId)
            && x.DateTime == DateTime.Today.AddDays(-1) && x.Action.Equals("purchase made")).CountAsync();

            response.GateStatistic = gateStatistic;
            response.Success = true;

            return response;
        }

        public async Task<StatisticsResponse> GetSuccessfulPaymentStatistics(StatisticsRequest request)
        {
            StatisticsResponse response = new StatisticsResponse()
            {
                Request = request
            };

            StatisticDto statisticDto = new StatisticDto();
            statisticDto.SelledProductsStatistics = await _context.Logs.Where
                (x => x.Action.Equals("purchase made")).CountAsync();

            response.Statistics = statisticDto;
            response.Success = true;

            return response;
        }

        public async Task<StatisticsResponse> GetUnsuccessfulPaymentStatistics(StatisticsRequest request)
        {
            StatisticsResponse response = new StatisticsResponse()
            {
                Request = request
            };

            StatisticDto statisticDto = new StatisticDto();
            statisticDto.SelledProductsStatistics = await _context.Logs.Where
                (x => x.Action.Equals("purchase declined")).CountAsync();

            response.Statistics = statisticDto;
            response.Success = true;

            return response;
        }
    }
}
