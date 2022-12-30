using Breadr.Core.Domain;
using Breadr.Service.Statistic.Dtos;

namespace Breadr.Service.Statistic.Models
{
    public class StatisticsRequest : RequestBase
    {

    }
    public class StatisticsResponse : ResponseBase<StatisticsRequest>
    {
        public StatisticDto Statistics { get; set; }
    }
}
