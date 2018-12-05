using Microsoft.EntityFrameworkCore;
using Reminder.Api.Models;
using Reminder.Api.Service;

namespace Reminder.Api.Data
{
    public class ReminderContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ReminderContext(DbContextOptions<ReminderContext> options) : base(options) { }

        public ReminderContext() { }
    }
}