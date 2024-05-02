using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Repositories.Interfaces;

namespace CodeBuddies.Services.Interfaces
{
    public interface ISessionService
    {
        ISessionRepository SessionRepository { get; set; }
        void AddBuddyMemberToSession(long receiverId, long sessionId);
        long AddNewSession(string sessionName, string maxParticipants);
        List<ISession> FilterSessionsBySessionName(string sessionName);
        List<ISession> GetAllSessionsForCurrentBuddy();
        string GetSessionName(long sessionId);
    }
}