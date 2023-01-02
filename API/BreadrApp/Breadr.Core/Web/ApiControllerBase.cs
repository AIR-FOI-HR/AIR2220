using Breadr.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Core.Web
{
    public abstract class ApiControllerBase : ControllerBase
    {

        protected TRequest CreateServiceRequest<TRequest>() where TRequest : RequestBase, new()
        {
            return new TRequest
            {

            };
        }

        protected ObjectResult BadResponse<TRequest>(ResponseBase<TRequest> response, bool includeStatus=false) where TRequest : RequestBase, new()
        {
            switch(response.Statuses.FirstOrDefault()?.Code)
            {
                case "204":
                    return StatusCode(204, response.Message);
                case "401":
                    return StatusCode(401, response.Message);
                case "403":
                    return StatusCode(403, response.Message);
                case "404":
                    return StatusCode(404, response.Message);
                case "500":
                    return StatusCode(500, response.Message);
                default:
                    if(!includeStatus)
                    {
                        return BadRequest(response.Message);
                    }
                    return BadRequest(response.Statuses);
            }

        }
    }
}
