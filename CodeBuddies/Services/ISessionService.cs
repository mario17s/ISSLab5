using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;

namespace CodeBuddies.Services
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