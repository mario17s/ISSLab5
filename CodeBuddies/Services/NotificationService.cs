﻿using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Services
{
    internal class NotificationService
    {
        private INotificationRepository notificationRepository;

        public INotificationRepository NotificationRepository { 
            get { return notificationRepository; }
            set { notificationRepository = value; }
        }
            
        public NotificationService()
        {
            notificationRepository = new NotificationRepository();
        }

        public List<INotification> getAllNotificationsForCurrentBuddy()
        {
            return notificationRepository.GetAllByBuddyId(Constants.CLIENT_BUDDY_ID);
        }

        public long getFreeNotificationId()
        {
            return notificationRepository.GetFreeNotificationId();
        }

        public void removeNotification(INotification notification)
        {
            notificationRepository.RemoveById(notification.NotificationId);
        }

        public void addNotification(INotification notification)
        {
            notificationRepository.Save(notification);
        }
    }
}
