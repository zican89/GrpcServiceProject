using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcWebApp.Models
{
    public class UsageDataViewModel
    {
        public DateTime Time { get; set; }
        public float MeterUsage { get; set; }
    }
}
