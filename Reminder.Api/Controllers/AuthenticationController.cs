using System;
using Microsoft.AspNetCore.Mvc;
using Reminder.Api.Data;
using Reminder.Api.Dtos;
using Reminder.Api.Models;
using Reminder.Api.Service;
using Reminder.Api.Utils;

namespace Reminder.Api
{
    [Route("api/auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private AuthService _authService;
        public LoginController(ReminderContext Context)
        {
            _authService = new AuthService(Context);
        }

        [Route("/login"), HttpPost]
        public ActionResult<string> Login([FromBody] UserDto dto)
        {
            return HandleResponse(_authService.Login(dto));
        }

        [Route("/register"), HttpPost]
        public ActionResult<string> Register([FromBody] UserDto dto)
        {
            return HandleResponse(_authService.Register(dto));
        }

        private ActionResult<string> HandleResponse(ValueTuple<User, Error> payload)
        {
            (User User, Error Error) = payload;

            if (Error != null)
            {
                return BadRequest(Error);
            }

            return Ok(User.ToDto());
        }
    }
}