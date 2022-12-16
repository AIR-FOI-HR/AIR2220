using Breadr.Core.Domain;
using Service.Report.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Report.Models
{
    public class LoginUserRequest : RequestBase
    {

    }
    public class LoginUserResponse : ResponseBase<LoginUserRequest>
    {
        public List<ReportDto> User { get; set; }
    }
}
