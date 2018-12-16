using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reminder.Models;

namespace Reminder.Services
{
    public class ApiService
    {
        private static HttpClient _client = new HttpClient();
        private static string _url = "http://localhost:5000/api";

        public static async Task<IActionResult> Post(string route, Object data)
        {
            string content = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(_url + route, stringContent);

            if (response.IsSuccessStatusCode)
            {
                return new OkResult();
            }

            return new NotFoundResult();
        }
    }
}