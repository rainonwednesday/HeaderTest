using Microsoft.AspNetCore.Mvc.Testing;

namespace App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new WebApplicationFactory<Api.Program>();
            var client1 = factory.CreateClient();
            var x = await Fetch(client1);
            Console.WriteLine($"Using WebApplicationFactory: {x}");


            var client2 = new HttpClient() { BaseAddress = new Uri("https://localhost:7143") };
            var y = await Fetch(client2);
            Console.WriteLine($"Using HttpClient: {y}");
            Console.ReadLine();
        }

        static async Task<int> Fetch(HttpClient client)
        {
            var msg = new HttpRequestMessage(HttpMethod.Get, "headers");
            msg.Headers.Add("custom-header", new string[] { "value1", "value2" });
            var response = await client.SendAsync(msg);
            var content = await response.Content.ReadAsStringAsync();
            return int.Parse(content);
        }
    }
}