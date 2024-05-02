namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface ISession
    {
        List<long> Buddies { get; set; }
        List<ICodeContribution> CodeContributions { get; set; }
        List<ICodeReviewSection> CodeReviewSections { get; set; }
        DateTime CreationDate { get; set; }
        IDrawingBoard DrawingBoard { get; set; }
        List<string> FilePaths { get; set; }
        long Id { get; set; }
        DateTime LastEditDate { get; set; }
        List<IMessage> Messages { get; set; }
        string Name { get; set; }
        long OwnerId { get; set; }
        ITextEditor TextEditor { get; set; }

        void AddBuddy(long buddyId);
        void AddCodeContribution(int buddyId, DateTime date, int contributionValue);
        void LeaveSession(long buddyId);
        void PostCodeReviewSection(ICodeReviewSection codeReviewSection);
        void PostCodeReviewSectionMessage(long codeReviewSectionId, IMessage message);
        void PostMessage(IMessage message);
        void RemoveBuddy(long buddyId);
        void UploadFile(string filePath);
    }
}