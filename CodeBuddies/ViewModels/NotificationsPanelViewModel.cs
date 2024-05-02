using System.Collections.ObjectModel;
using System.Windows;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Models.Exceptions;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.ViewModels
{
    public class NotificationsPanelViewModel : ViewModelBase
    {
        #region Fields
        private ObservableCollection<INotification> notifications;
        private INotificationService notificationService;
        private ISessionService sessionService;
        #endregion

        #region Commands
        public RelayCommand<INotification> AcceptCommand => new RelayCommand<INotification>(AcceptInvite);
        public RelayCommand<INotification> DeclineCommand => new RelayCommand<INotification>(DeclineInvite);
        public RelayCommand<INotification> MarkReadCommand => new RelayCommand<INotification>(MarkReadNotification);
        #endregion

        #region Properties
        public ObservableCollection<INotification> Notifications
        {
            get
            {
                return notifications;
            }
            set
            {
                notifications = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public NotificationsPanelViewModel()
        {
            // TODO inject these more cleanly
            INotificationRepository notificationRepository = new NotificationRepository();
            notificationService = new NotificationService(notificationRepository);
            ISessionRepository sessionRepository = new SessionRepository();
            sessionService = new SessionService(sessionRepository);
            Notifications = new ObservableCollection<INotification>(notificationService.GetAllNotificationsForCurrentBuddy());
        }

        #region Methods
        private void AcceptInvite(INotification notification)
        {
            SendAcceptedInfoNotification(notification);
            // save the new member
            try
            {
                sessionService.AddBuddyMemberToSession(notification.ReceiverId, notification.SessionId);
                // Raise the event to notify the other components they need to update their sessions list
                GlobalEvents.RaiseBuddyAddedToSessionEvent(notification.ReceiverId, notification.SessionId);
            }
            catch (EntityAlreadyExists error)
            {
                ShowErrorPopup("You are already a member of the session " + sessionService.GetSessionName(notification.SessionId));
            }
            finally
            {
                RemoveNotification(notification);
            }
        }
        private void DeclineInvite(INotification notification)
        {
            // send an information notification informing the inviter that the user declined
            SendDeclinedInfoNotification(notification);
            RemoveNotification(notification);
        }
        private void MarkReadNotification(INotification notification)
        {
            RemoveNotification(notification);
        }
        private void SendDeclinedInfoNotification(INotification notification)
        {
            // Reverse sender and receiver ids because this notification goes backwards
            INotification declinedNotification = new InfoNotification(notificationService.GetFreeNotificationId(), DateTime.Now, "rejectInformation", "pending", Constants.CLIENT_NAME + " rejected your invitation", notification.ReceiverId, notification.SenderId, notification.SessionId);
            notificationService.AddNotification(declinedNotification);
        }
        private void SendAcceptedInfoNotification(INotification notification)
        {
            // Reverse sender and receiver ids because this notification goes backwards
            INotification acceptedNotification = new InfoNotification(notificationService.GetFreeNotificationId(), DateTime.Now, "successInformation", "pending", Constants.CLIENT_NAME + " accepted your invitation!", notification.ReceiverId, notification.SenderId, notification.SessionId);
            notificationService.AddNotification(acceptedNotification);
        }
        private void ShowErrorPopup(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void RemoveNotification(INotification notification)
        {
            // update optimistically
            notifications.Remove(notification);
            // remove from db
            try
            {
                notificationService.RemoveNotification(notification);
            }
            catch (Exception ex)
            {
                // if failure, fetch again
                Notifications = new ObservableCollection<INotification>(notificationService.GetAllNotificationsForCurrentBuddy());
            }
        }
        #endregion
    }
}