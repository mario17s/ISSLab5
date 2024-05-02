namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface INotification
    {
        string Description { get; set; }
        long NotificationId { get; set; }
        long ReceiverId { get; set; }
        long SenderId { get; set; }
        long SessionId { get; set; }
        string Status { get; set; }
        DateTime TimeStamp { get; set; }
        string Type { get; set; }
    }
}