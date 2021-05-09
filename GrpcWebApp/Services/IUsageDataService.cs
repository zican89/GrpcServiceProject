using GrpcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcWebApp.Services
{
    public interface IUsageDataService
    {
        Task<List<UsageDataViewModel>> GetAllUsageData();
    }
}
