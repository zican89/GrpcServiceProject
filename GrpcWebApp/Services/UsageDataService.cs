using Data;
using Grpc.Net.Client;
using GrpcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcWebApp.Services
{
    public class UsageDataService: IUsageDataService
    {
        private readonly GrpcChannel channel; 
        public UsageDataService()
        {
            channel = GrpcChannel.ForAddress("https://localhost:5001");
        }

        public async Task<List<UsageDataViewModel>> GetAllUsageData()
        {
            List<UsageDataViewModel> result = new List<UsageDataViewModel>();
            var client = new UsageDataServices.UsageDataServicesClient(channel);
            var reply = await client.GetAllUsageDataAsync(new Empty());

            result = reply.UsageDatas.Select(x => new UsageDataViewModel() {MeterUsage=x.Meterusage,Time=Convert.ToDateTime(x.Time) }).ToList();

            return result;
        }
    }
}
