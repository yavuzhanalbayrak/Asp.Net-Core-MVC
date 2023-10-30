namespace Lezita2.Entities
{
    public class UserActivityLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ActivityType { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
