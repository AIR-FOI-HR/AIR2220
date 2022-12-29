using Breadr.Core.Domain;
using Breadr.Service.Statistic.Dtos;
using Service.Report.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
