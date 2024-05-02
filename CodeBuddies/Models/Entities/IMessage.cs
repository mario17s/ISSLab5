namespace CodeBuddies.Models.Entities
{
    public interface IMessage
    {
        string Content { get; set; }
        long MessageId { get; set; }
        long SenderId { get; set; }
        DateTime TimeStamp { get; set; }
    }
}