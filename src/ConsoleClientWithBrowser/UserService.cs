using ConsoleClientWithBrowser.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientWithBrowser
{
    public class UserService
    {
        public async void CreateUser(User user)
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            var scimConfig = new ScimConfig();
            configuration.Bind("scim", scimConfig);

            using var apiClient = new HttpClient();

            apiClient.BaseAddress = new Uri($"{scimConfig.BaseUrl.Trim('/')}/tokens/{scimConfig.Token}/");
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            string url = apiClient.BaseAddress.ToString();
            string posturl = url + "Users";
            var response = await apiClient.PostAsync(posturl, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Post request was successful!");
            }
            else
            {
                Console.WriteLine($"Post request failed with status code {response.StatusCode}");
            }

        }
    }
}
