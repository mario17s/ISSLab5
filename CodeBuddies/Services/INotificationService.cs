using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;

namespace CodeBuddies.Services
{
    public interface INotificationService
    {
        INotificationRepository NotificationRepository { get; set; }

        void addNotification(INotification notification);
        List<INotification> getAllNotificationsForCurrentBuddy();
        long getFreeNotificationId();
        void removeNotification(INotification notification);
    }
}