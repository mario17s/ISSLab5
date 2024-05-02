using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Models.Validators;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services.Interfaces;
using static CodeBuddies.Models.Validators.ValidationForNewSession;

namespace CodeBuddies.Services
{
    public class SessionService : ISessionService
    {
        #region Fields
        private ISessionRepository sessionRepository;
        #endregion

        #region Properties
        public ISessionRepository SessionRepository
        {
            get { return sessionRepository; }
            set { sessionRepository = value; }
        }
        #endregion

        public SessionService(ISessionRepository repo)
        {
            sessionRepository = repo;
        }

        #region Adders
        public long AddNewSession(string sessionName, string maxParticipants)
        {
            IValidationForNewSession validator = new ValidationForNewSession();
            validator.ValidateSessionId(sessionRepository.GetFreeSessionId());
            validator.ValidateSessionName(sessionName);
            validator.ValidateMaxNumberOfBuddies(maxParticipants);
            validator.ValidateBuddyId(Constants.CLIENT_BUDDY_ID);

            long sessionId = sessionRepository.AddNewSession(sessionName, Constants.CLIENT_BUDDY_ID, int.Parse(maxParticipants));
            return sessionId;
        }

        public void AddBuddyMemberToSession(long receiverId, long sessionId)
        {
            sessionRepository.AddBuddyMemberToSession(receiverId, sessionId);
        }
        #endregion

        #region Getters
        public string GetSessionName(long sessionId)
        {
            return sessionRepository.GetSessionName(sessionId);
        }

        public List<ISession> FilterSessionsBySessionName(string sessionName)
        {
            List<ISession> filteredSessions = new List<ISession>();
            foreach (var session in sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID))
            {
                if (session.Name.ToLower().Contains(sessionName.ToLower()))
                {
                    filteredSessions.Add(session);
                }
            }
            return filteredSessions;
        }

        public List<ISession> GetAllSessionsForCurrentBuddy()
        {
            return sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID);
        }
        #endregion
    }
}