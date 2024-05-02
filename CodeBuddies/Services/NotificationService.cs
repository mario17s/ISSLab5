using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Services
{
    public class NotificationService : INotificationService
    {
        private INotificationRepository notificationRepository;

        public INotificationRepository NotificationRepository
        {
            get { return notificationRepository; }
            set { notificationRepository = value; }
        }

        public NotificationService(INotificationRepository repo)
        {
            notificationRepository = repo;
        }

        public List<INotification> GetAllNotificationsForCurrentBuddy()
        {
            return notificationRepository.GetAllByBuddyId(Constants.CLIENT_BUDDY_ID);
        }

        public long GetFreeNotificationId()
        {
            return notificationRepository.GetFreeNotificationId();
        }

        public void RemoveNotification(INotification notification)
        {
            notificationRepository.RemoveById(notification.NotificationId);
        }

        public void AddNotification(INotification notification)
        {
            notificationRepository.Save(notification);
        }
    }
}
