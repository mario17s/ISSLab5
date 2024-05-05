using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Repositories
{
    public interface INotificationRepository
    {
        List<INotification> GetAll();
        List<INotification> GetAllByBuddyId(long buddyId);
        long GetFreeNotificationId();
        void RemoveById(long notificationId);
        void Save(INotification notification);
        void ClearDatabase();
    }
}