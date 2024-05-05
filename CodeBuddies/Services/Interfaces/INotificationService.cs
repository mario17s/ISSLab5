using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;

namespace CodeBuddies.Services.Interfaces
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