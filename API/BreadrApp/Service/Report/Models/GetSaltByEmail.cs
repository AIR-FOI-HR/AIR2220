using Breadr.Core.Domain;
using Service.Report.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Report.Models
{
    public class GetSaltByEmailRequest : RequestBase
    {

    }
    public class GetSaltByEmailResponse : ResponseBase<GetSaltByEmailRequest>
    {
        public List<ReportDto> Salt { get; set; }
    }
}
