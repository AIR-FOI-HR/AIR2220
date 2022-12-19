using Breadr.Core.Domain;
using Breadr.Service.Statistic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.Statistic.Models
{
    
        public class StatisticsByHoursRequest : RequestBase
        {
            public int NumberOfHours { get; set; }

        }
        public class StatisticsByHoursResponse : ResponseBase<StatisticsByHoursRequest>
        {
            public List<StatisticDto> Statistics { get; set; }
        }
    
}
