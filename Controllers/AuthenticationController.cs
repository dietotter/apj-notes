using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reminder.Models;
using Reminder.Services;

namespace Reminder.Controllers
{
    public class AuthenticationController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            IActionResult response = await AuthenticationService.Login(username, password);

            return HandleReponse(response, username);
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, string name)
        {
            IActionResult response = await AuthenticationService.Register(username, password, name);

            return HandleReponse(response, username);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void SessionSave(string username)
        {
            ViewBag.CurrentUserName = username;
            HttpContext.Session.SetString("Username", username);
        }

        private ActionResult HandleReponse(IActionResult response, string username)
        {
            Console.WriteLine("LOLOL");
            Console.WriteLine(response);
            if (response is OkResult)
            {
                SessionSave(username);
            }
            ReminderView rmv = new ReminderView() {Username = HttpContext.Session.GetString("Username"), SignUpFormViewModel = new SignUpForm(), LoginFormViewModel = new LoginForm()};
            return View("~/Views/Home/Index.cshtml", rmv);
        }
    }
}