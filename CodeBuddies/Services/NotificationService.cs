using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Services
{
    public class NotificationService : INotificationService
    {
        #region Fields
        private INotificationRepository notificationRepository;
        #endregion

        #region Properties
        public INotificationRepository NotificationRepository
        {
            get { return notificationRepository; }
            set { notificationRepository = value; }
        }
        #endregion

        public NotificationService(INotificationRepository repo)
        {
            notificationRepository = repo;
        }

        #region Getters
        public List<INotification> GetAllNotificationsForCurrentBuddy()
        {
            return notificationRepository.GetAllByBuddyId(Constants.CLIENT_BUDDY_ID);
        }

        public long GetFreeNotificationId()
        {
            return notificationRepository.GetFreeNotificationId();
        }
        #endregion

        #region Methods
        public void RemoveNotification(INotification notification)
        {
            notificationRepository.RemoveById(notification.NotificationId);
        }

        public void AddNotification(INotification notification)
        {
            notificationRepository.Save(notification);
        }
        #endregion
    }
}
