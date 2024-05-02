using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;

namespace CodeBuddies.Services
{
    public interface INotificationService
    {
        INotificationRepository NotificationRepository { get; set; }

        void AddNotification(INotification notification);
        List<INotification> GetAllNotificationsForCurrentBuddy();
        long GetFreeNotificationId();
        void RemoveNotification(INotification notification);
    }
}