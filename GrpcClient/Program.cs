using Data;
using Grpc.Net.Client;
using System;
using System.Linq;

namespace GrpcClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new UsageDataServices.UsageDataServicesClient(channel);
            var reply = await client.GetAllUsageDataAsync(new Empty());

            int count = 0;

            foreach (var item in reply.UsageDatas)
            {
                Console.WriteLine(count +" = "+ item.Meterusage+" - "+item.Time);
                count++;
            }


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
