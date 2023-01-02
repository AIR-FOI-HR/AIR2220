using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public string Action { get; set; }
        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string? GateId { get; set; }
        public virtual Gate Gate { get; set; }
    }
}
