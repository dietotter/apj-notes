using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Reminder.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Reminder.Services
{
    public class ApiService
    {
        private static HttpClient client = new HttpClient();
        private static string url = "http://localhost:58707/api";
        
        public static async Task<IActionResult> Post(string route, Object data)
        {
            string content = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url + route, stringContent);
            
            if (response.IsSuccessStatusCode)
            {
                return new OkResult();
            }
            
            return new NotFoundResult();
        }        
    }
}