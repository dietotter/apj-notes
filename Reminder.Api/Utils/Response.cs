using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reminder.Api.Data;
using Reminder.Api.Dtos;
using Reminder.Api.Models;

namespace Reminder.Api.Utils
{
    public class Error
    {
        private string _message;

        public Error(string message)
        {
            this._message = message;
        }
    }
}