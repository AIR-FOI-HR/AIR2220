using Breadr.Core.Domain;
using Breadr.Service.Gate.Models;
using Breadr.Service.Statistic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.Statistic.Models
{
    public class StatisticsOfGateRequest : RequestBase
    {
        public string GateId { get; set; }

    }
    public class StatisticsOfGateResponse : ResponseBase<StatisticsOfGateRequest>
    {
        public GateStatisticDto GateStatistic { get; set; }
    }
}
