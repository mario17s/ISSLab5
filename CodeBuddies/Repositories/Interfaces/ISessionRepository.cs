using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        void AddBuddyMemberToSession(long buddyId, long sessionId);
        long AddNewSession(string sessionName, long ownerId, int maxParticipants);
        List<ISession> GetAllSessionsOfABuddy(long buddyId);
        List<long> GetBuddiesForSpecificSession(long sessionId);
        List<ICodeContribution> GetCodeContributionsForSpecificSession(long sessionId);
        List<ICodeReviewSection> GetCodeReviewSectionsForSpecificSession(long sessionId);
        long GetFreeSessionId();
        List<IMessage> GetMessagesForSpecificCodeReview(long codeReviewId);
        List<IMessage> GetMessagesForSpecificSession(long sessionId);
        string GetSessionName(long sessionId);
    }
}