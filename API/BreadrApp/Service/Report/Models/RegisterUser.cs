using Breadr.Core.Domain;
using Service.Report.Dtos;

namespace Service.Report.Models
{
    public class RegisterUserRequest : RequestBase
    {

    }
    public class RegisterUserResponse : ResponseBase<RegisterUserRequest>
    {
        public List<ReportDto> Status { get; set; }
    }
}
