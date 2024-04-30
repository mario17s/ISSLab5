using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services;
using static CodeBuddies.Models.Validators.ValidationForNewSession;

namespace CodeBuddies.ViewModels
{
    internal class CreateNewSessionPopUpViewModel : ViewModelBase
    {
        private SessionService sessionService;
        public CreateNewSessionPopUpViewModel()
        {
            sessionService = new SessionService();
        }

        public void AddNewSession(string sessionName, string maxParticipants)
        {
            long sessionId =  sessionService.AddNewSession(sessionName, maxParticipants);
            GlobalEvents.RaiseBuddyAddedToSessionEvent(Constants.CLIENT_BUDDY_ID, sessionId);
        }
    }
}
