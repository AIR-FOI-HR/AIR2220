using Breadr.Core.Domain;
using Breadr.Service.Statistic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.Statistic.Models
{
    public class StatisticsByTimeRequest : RequestBase
    {
        public int Time { get; set; }

    }
    public class StatisticsByTimeResponse : ResponseBase<StatisticsByTimeRequest>
    {
        public List<StatisticDto> Statistics { get; set; }
    }
}
