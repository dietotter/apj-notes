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
    public class ReminderService
    {
        public static Task<IActionResult> GetByUsername(string username)
        {
            return ApiService.Post("/login", new {username});
        }

        public static Task<IActionResult> Register(string username, string password, string name)
        {
            return ApiService.Post("/register", new {username,password, name});
        }
    }
}