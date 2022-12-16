using Breadr.Core.Domain;
using Service.Report.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Report.Models
{
    public class KeepAliveRequest : RequestBase
    {

    }
    public class KeepAliveResponse : ResponseBase<KeepAliveRequest>
    {
        public List<ReportDto> Status { get; set; }
    }
}
