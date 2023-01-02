using Breadr.Core.Domain;
using Service.Report.Dtos;

namespace Service.Report.Models
{
    public class GetReportsRequest: RequestBase
    {
        public int UserId { get; set; }
    }

    public class GetReportsResponse : ResponseBase<GetReportsRequest>
    {
        public List<ReportDto> Reports { get; set; }
    }
}
