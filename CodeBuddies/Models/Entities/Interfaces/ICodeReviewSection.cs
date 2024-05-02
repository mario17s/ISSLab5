namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface ICodeReviewSection
    {
        string CodeSection { get; set; }
        long Id { get; set; }
        bool IsClosed { get; set; }
        List<IMessage> Messages { get; set; }
        long OwnerId { get; set; }
    }
}