using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SouthWorks.Events.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var httpRequestTemplate = "/Events/GetEvents?iDisplayStart={0}&iDisplayLength={1}&sSearch={2}";

            Parallel.For(0, 500, j =>
            {
                for (int i = 0; i < 500; i++)
                {
                    System.Console.WriteLine(string.Format("Request: {0} -> Thread: {1}", i, j));

                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri("http://localhost:88");
                        var httpResponse = httpClient.GetAsync(
                            string.Format(httpRequestTemplate, i, i, Guid.NewGuid().ToString())
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
