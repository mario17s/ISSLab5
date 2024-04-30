using CodeBuddies.Models.Entities;

namespace CodeBuddies.Repositories
{
    internal interface INotificationRepository
    {
        List<INotification> GetAll();
        List<INotification> GetAllByBuddyId(long buddyId);
        long GetFreeNotificationId();
        void RemoveById(long notificationId);
        void Save(INotification notification);
    }
}