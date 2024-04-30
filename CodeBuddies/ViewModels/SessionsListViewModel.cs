using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace CodeBuddies.ViewModels
{
    internal class SessionsListViewModel : ViewModelBase
    {
        private ObservableCollection<ISession> sessions;
        private ISessionRepository sessionRepository;

        public RelayCommand<ISession> LeaveSessionCommand => new RelayCommand<ISession>(LeaveSession);
        public RelayCommand<ISession> JoinSessionCommand => new RelayCommand<ISession>(JoinSession);

        public ObservableCollection<ISession> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        }


        public SessionsListViewModel()
        {
            GlobalEvents.BuddyAddedToSession += HandleBuddyAddedToSession;
            sessionRepository = new SessionRepository();
            Sessions = new ObservableCollection<ISession>(sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID));

        }

        private string searchBySessionName;

        public string SearchBySessionName
        {
            get { return searchBySessionName; }
            set
            {
                searchBySessionName = value;
                FilterSessionsBySessionName();
                OnPropertyChanged();
            }
        }

        public void FilterSessionsBySessionName()
        {
            if (string.IsNullOrWhiteSpace(SearchBySessionName))
            {
                Sessions.Clear();
                Sessions = new ObservableCollection<ISession>(sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID));
            }
            else
            {
                ObservableCollection<ISession> filteredSessions = new ObservableCollection<ISession>();
                foreach (var session in sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID))
                {
                    if (session.Name.ToLower().Contains(SearchBySessionName.ToLower()))
                    {
                        filteredSessions.Add(session);
                    }
                }
                Sessions = filteredSessions;
            }
        }

        public void HandleBuddyAddedToSession(long buddyId, long sessionId)
        {
            Sessions = new ObservableCollection<ISession>(sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID));
        }
        public void LeaveSession(ISession session)
        {
            Console.WriteLine("hi");
        }

        public void JoinSession(ISession session)
        {
            Console.WriteLine("hi");
            SessionWindow sessionWindow = new SessionWindow();
            sessionWindow.ShowDialog();
        }
        public void filterSessionOnlyOwner(long buddyId)
        {
            Sessions = new ObservableCollection<ISession>(Sessions.Where(Session => Session.OwnerId == buddyId).ToList()); 
        }


        public ICommand SendInviteNotification => new RelayCommand<Buddy>(InviteBuddyToSession);

        private void InviteBuddyToSession(Buddy buddy)
        {


        }
    }
}
