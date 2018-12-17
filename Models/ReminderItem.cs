namespace Reminder.Models
{
    public class ReminderItem
    {
        public string Id { get; private set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
    }
}