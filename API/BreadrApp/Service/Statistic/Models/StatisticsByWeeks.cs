using Breadr.Core.Domain;
using Breadr.Service.Statistic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.Statistic.Models
{
    public class StatisticsByWeeksRequest : RequestBase
    {
        public int NumberOfWeeks { get; set; }

    }
    public class StatisticsByWeeksResponse : ResponseBase<StatisticsByWeeksRequest>
    {
        public List<StatisticDto> Statistics { get; set; }
    }
}
