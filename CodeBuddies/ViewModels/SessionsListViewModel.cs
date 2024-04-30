using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace CodeBuddies.ViewModels
{
    internal class SessionsListViewModel : ViewModelBase
    {
        private ObservableCollection<ISession> sessions;
        private SessionService sessionService;

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
            sessionService = new SessionService();
            Sessions = new ObservableCollection<ISession>(sessionService.getAllSessionsForCurrentBuddy());

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
                Sessions = new ObservableCollection<ISession>(sessionService.getAllSessionsForCurrentBuddy());
            }
            else
            {
                Sessions = new ObservableCollection<ISession>(sessionService.FilterSessionsBySessionName(SearchBySessionName));
            }
        }

        public void HandleBuddyAddedToSession(long buddyId, long sessionId)
        {
            Sessions = new ObservableCollection<ISession>(sessionService.getAllSessionsForCurrentBuddy());
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
