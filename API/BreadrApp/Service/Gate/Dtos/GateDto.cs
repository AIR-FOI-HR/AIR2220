using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadr.Service.Gate.Dtos
{
    public class GateDto
    {
        public string GateId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public decimal Price { get; set; }
        public DateTime Keepalive { get; set; }
        public int Active { get; set; }
    }
}
