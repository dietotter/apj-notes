using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Reminder.Api.Data;
using Reminder.Api.Dtos;

namespace Reminder.Api.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(UserDto dto)
        {
            this.UserName = dto.UserName;
            this.Password = dto.Password;
        }
    }
}