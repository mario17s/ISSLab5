
namespace CodeBuddies.Models.Entities
{
    internal interface IMessage
    {
        string Content { get; set; }
        long MessageId { get; set; }
        long SenderId { get; set; }
        DateTime TimeStamp { get; set; }
    }
}