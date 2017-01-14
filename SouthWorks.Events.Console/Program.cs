using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SouthWorks.Events.Console
{
    public class Program
    {
        private const string BASE_URL = "http://localhost:85";
        private const string RESOURCE_TEMPLATE = "/Events/GetEvents?iDisplayStart={0}&iDisplayLength={1}&sSearch={2}&sEcho={3}";

        public static void Main(string[] args)
        {
            Parallel.For(0, 500, j =>
            {
                for (int i = 0; i < 500; i++)
                {
                    System.Console.WriteLine(string.Format("Request: {0} -> Thread: {1}", i, i));

                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri(BASE_URL);
                        var httpResponse = httpClient.GetAsync(
                                string.Format(RESOURCE_TEMPLATE, i, i, Guid.NewGuid().ToString(), 1)
                            ).Result;

                        httpResponse.EnsureSuccessStatusCode();
                    }
                }
            });

            System.Console.WriteLine("Finished!");
            System.Console.ReadKey();
        }
    }
}
