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
    public class AuthenticationService
    {
        public static Task<IActionResult> Login(string username, string password)
        {
            return ApiService.Post("/login", new {username,password});
        }

        public static Task<IActionResult> Register(string username, string password)
        {
            return ApiService.Post("/register", new {username,password});
        }
    }
}