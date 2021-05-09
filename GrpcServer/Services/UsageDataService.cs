using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UsageDataService : UsageDataServices.UsageDataServicesBase
    {
        private readonly List<UsageData> _usageData = new List<UsageData>();

        private readonly ILogger<UsageDataService> _logger;
        public UsageDataService(ILogger<UsageDataService> logger)
        {
            _logger = logger;
            _usageData.AddRange(ProcessCSV());
        }

        public override Task<UsageDataList> GetAllUsageData(Empty empty, ServerCallContext context)
        {
            UsageDataList pl = new UsageDataList();
            pl.UsageDatas.AddRange(_usageData);

            return Task.FromResult(pl);
        }

        private static List<UsageData> ProcessCSV()
        {
            string[] asd = File.ReadAllLines(".\\Data\\meterusage.csv");
            return File.ReadAllLines(".\\Data\\meterusage.csv")
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(ProcessRow).ToList();
        }

        private static UsageData ProcessRow(string row)
        {
            var columns = row.Split(',');
            return new UsageData()
            {
                Time= columns[0],
                Meterusage = float.Parse(columns[1])
            };
        }
    }
}
