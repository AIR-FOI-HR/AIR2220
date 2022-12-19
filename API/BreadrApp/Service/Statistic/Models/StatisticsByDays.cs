using Breadr.Core.Domain;
using Breadr.Service.Statistic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.Statistic.Models
{
    public class StatisticsByDaysRequest : RequestBase
    {
        public int NumberOfDays { get; set; }

    }
    public class StatisticsByDaysResponse : ResponseBase<StatisticsByDaysRequest>
    {
        public List<StatisticDto> Statistics { get; set; }
    }
}
