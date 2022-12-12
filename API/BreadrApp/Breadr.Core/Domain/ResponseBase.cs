using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Core.Domain
{
    [Serializable]
    public abstract class ResponseBase<T> : IResponse where T : IRequest
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public List<ResponseStatus> Statuses { get; set; }
        public T Request { get; set; }

        public ResponseBase()
        {
            Statuses = new List<ResponseStatus>();
        }
    }
}
