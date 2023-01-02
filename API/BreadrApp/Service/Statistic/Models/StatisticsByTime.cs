using Breadr.Core.Domain;
using Breadr.Service.Statistic.Dtos;

namespace Breadr.Service.Statistic.Models
{
    public class StatisticsByTimeRequest : RequestBase
    {
        public int Time { get; set; }

    }
    public class StatisticsByTimeResponse : ResponseBase<StatisticsByTimeRequest>
    {
        public StatisticDto SelledProductsStatistics { get; set; }
    }
}
