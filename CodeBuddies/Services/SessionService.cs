using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodeBuddies.Models.Validators.ValidationForNewSession;

namespace CodeBuddies.Services
{
    internal class SessionService
    {
        private ISessionRepository sessionRepository;

        public ISessionRepository SessionRepository
        {
            get { return sessionRepository; }
            set { sessionRepository = value; }
        }

        public SessionService()
        {
            sessionRepository = new SessionRepository();
        }

        public List<ISession> getAllSessionsForCurrentBuddy()
        {
            return sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID);
        }

        public long AddNewSession(string sessionName, string maxParticipants)
        {
            ValidateSessionId(sessionRepository.GetFreeSessionId());
            ValidateSessionName(sessionName);
            ValidateMaxNoOfBuddies(maxParticipants);
            ValidateBuddyId(Constants.CLIENT_BUDDY_ID);

            long sessionId = sessionRepository.AddNewSession(sessionName, Constants.CLIENT_BUDDY_ID, Int32.Parse(maxParticipants));
            return sessionId;
        }

        public void AddBuddyMemberToSession(long receiverId, long sessionId)
        {
            sessionRepository.AddBuddyMemberToSession(receiverId, sessionId);
        }

        public string getSessionName(long sessionId)
        {
            return sessionRepository.GetSessionName(sessionId);
        }

        public List<ISession> FilterSessionsBySessionName(string sessionName)
        {
            List<ISession> filteredSessions = new List<ISession> ();
            foreach (var session in sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID))
            {
                if (session.Name.ToLower().Contains(sessionName.ToLower()))
                {
                    filteredSessions.Add(session);
                }
            }
            return filteredSessions;
        }
    }
}
