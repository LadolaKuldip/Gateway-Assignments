using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpRecap.Assignment2
{
    public class Assignment_2
    {
        public static async Task Execute()
        {
            
            UrlDataFetch.TaskExecutionSync();
            await Task.Delay(2000);
            await UrlDataFetch.TaskExecutionAsync();
            await Task.Delay(2000);
            await UrlDataFetch.TaskExecutionParallel();

        }
    }
    public class UrlDataFetch
    {
        static HttpClient client = new HttpClient();

        static readonly IEnumerable<string> urlList = new string[]
        {
            "https://docs.microsoft.com",
            "https://docs.microsoft.com/aspnet/core",
            "https://docs.microsoft.com/azure",
            "https://docs.microsoft.com/azure/devops",
            "https://docs.microsoft.com/dotnet",            
            "https://docs.microsoft.com/dynamics365"
        };

        public static async Task TaskExecutionParallel ()
        {
            Console.WriteLine("==================== Task 3: Task Parallel Execution ====================");
            var stopwatch = Stopwatch.StartNew();

            IEnumerable<Task<int>> downloadTasksQuery = from url in urlList select ProcessUrlAsync(url);
            List<Task<int>> downloadTasks = downloadTasksQuery.ToList();

            var res = await Task.WhenAll(downloadTasks);
            int total = res.Sum();
            stopwatch.Stop();

            Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}\n");
        }

        public static async Task TaskExecutionAsync()
        {
            Console.WriteLine("==================== Task 2 : Async Execution (Async/Await) ====================");
            var stopwatch = Stopwatch.StartNew();

            int total = 0;
            foreach (var url in urlList)
            {
                total += await ProcessUrlAsync(url);
            }
                
           
            stopwatch.Stop();

            Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}\n");
        }

        public static void TaskExecutionSync()
        {
            Console.WriteLine("==================== Task 1 : Sync Execution ====================");
            var stopwatch = Stopwatch.StartNew();

            int total = 0;
            foreach (var url in urlList)
            {
                total += ProcessUrlSync(url);
            }
            stopwatch.Stop();

            Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}\n");
        }

        static async Task<int> ProcessUrlAsync(string url)
        {
            byte[] content = await client.GetByteArrayAsync(url);
            Console.WriteLine(url);

            return content.Length;
        }
        static int ProcessUrlSync(string url)
        {
            var response = client.GetAsync(url).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                var content = responseContent.ReadAsByteArrayAsync().Result;
                Console.WriteLine(url);

                return content.Length;
            }
            return 0;
        }

    }
}
