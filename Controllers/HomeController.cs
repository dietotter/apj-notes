using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reminder.Models;
using Reminder.Services;
using System.Threading.Tasks;

namespace Reminder.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
		public ActionResult Login()
		{
            return GetView();
        }

        [HttpPost]
		public async Task<IActionResult> Login(string username, string password)
		{
		    IActionResult response = await AuthenticationService.Login(username, password);
            
            return HandleReponse(response,username);
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            IActionResult response = await AuthenticationService.Register(username, password);
            
            return HandleReponse(response,username);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        private ActionResult LoggedIn()
        {
            return View("~/Views/Reminder.cshtml");
        }
        
        
        private ActionResult LoggedOut()
        {
            return View("~/Views/Login.cshtml");
        }

        private ActionResult GetView(){
            if(HttpContext.Session.GetString("userName") != null) {
                return LoggedOut();
            } else {
                return LoggedIn();
            }
        }

        private void SessionSave(string username){
            ViewBag.CurrentUserName = username;
            HttpContext.Session.SetString("userName", username);
        }

        private ActionResult HandleReponse(IActionResult response,string username)
        {
            if (response is OkResult){
                SessionSave(username);
            }
            return GetView();
        }
    }
}