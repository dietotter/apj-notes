using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Models
{
    public class ReminderView
    {
        public string Username { get; set; }
        public List<ReminderItem> ReminderList { get; set; }
        public SignUpForm SignUpFormViewModel { get; set; }
        public LoginForm LoginFormViewModel { get; set; }
    }
}
