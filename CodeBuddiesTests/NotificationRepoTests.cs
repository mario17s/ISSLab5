using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
using Moq;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddiesTests
{
    [TestFixture]
    internal class NotificationRepoTests
    {
        [Test]
        public void GetAllNotifications_SelectsAllNotifications_ReturnsListOfAllNotifications()
        {
            INotificationRepository notificationRepository = new NotificationRepository();
            notificationRepository.ClearDatabase();
            ISessionRepository sessionRepository = new SessionRepository();
            IBuddyRepository buddyRepository = new BuddyRepository();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Ana", "ana.jpg", "inactive");
            sessionRepository.AddNewSession("haha", 1, 3);
            INotification testedNotification = new InviteNotification(1, DateTime.Now, "invite", "pending", "nushh", 1, 2, 1, false);
            notificationRepository.Save(testedNotification);
            List<INotification> actualOutput = notificationRepository.GetAll();
            List<INotification> expectedOutput = new List<INotification> { testedNotification };
            Assert.AreEqual(actualOutput[0].NotificationId, expectedOutput[0].NotificationId);
        }


        [Test]
        public void GetAllByBuddyId_FilterNotificationsById_ReturnNotificationWithThatReceiverId()
        {
            INotificationRepository notificationRepository = new NotificationRepository();
            notificationRepository.ClearDatabase();
            ISessionRepository sessionRepository = new SessionRepository();
            IBuddyRepository buddyRepository = new BuddyRepository();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Ana", "ana.jpg", "inactive");
            sessionRepository.AddNewSession("haha", 1, 3);
            INotification testedNotification = new InviteNotification(1, DateTime.Now, "invite", "pending", "nushh", 1, 2, 1, false);
            notificationRepository.Save(testedNotification);
            INotification secondTestedNotification = new InfoNotification(2, DateTime.Now, "info", "pending", "kfdnd", 2, 1, 1);
            notificationRepository.Save(secondTestedNotification);
            List<INotification> actualOutput = notificationRepository.GetAllByBuddyId(2);
            List<INotification> expectedOutput = new List<INotification> { testedNotification };
            Assert.AreEqual(actualOutput[0].NotificationId, expectedOutput[0].NotificationId);
        }

        [Test]
        public void RemoveById_DeleteNotificationWithIdGiven()
        {
            INotificationRepository notificationRepository = new NotificationRepository();
            notificationRepository.ClearDatabase();
            ISessionRepository sessionRepository = new SessionRepository();
            IBuddyRepository buddyRepository = new BuddyRepository();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Ana", "ana.jpg", "inactive");
            sessionRepository.AddNewSession("haha", 1, 3);
            INotification testedNotification = new InviteNotification(1, DateTime.Now, "invite", "pending", "nushh", 1, 2, 1, false);
            notificationRepository.Save(testedNotification);
            INotification secondTestedNotification = new InfoNotification(2, DateTime.Now, "info", "pending", "kfdnd", 2, 1, 1);
            notificationRepository.Save(secondTestedNotification);
            notificationRepository.RemoveById(1);
            List<INotification> actualOutput = notificationRepository.GetAll();
            List<INotification> expectedOutput = new List<INotification> { secondTestedNotification };
            Assert.AreEqual(actualOutput[0].NotificationId, expectedOutput[0].NotificationId);
        }

        [Test]
        public void GetFreeNotificationId_ReturnsTheNextValidFreeIdForNotification()
        {
            INotificationRepository notificationRepository = new NotificationRepository();
            notificationRepository.ClearDatabase();
            ISessionRepository sessionRepository = new SessionRepository();
            IBuddyRepository buddyRepository = new BuddyRepository();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Ana", "ana.jpg", "inactive");
            sessionRepository.AddNewSession("haha", 1, 3);
            INotification testedNotification = new InviteNotification(1, DateTime.Now, "invite", "pending", "nushh", 1, 2, 1, false);
            notificationRepository.Save(testedNotification);
            INotification secondTestedNotification = new InfoNotification(2, DateTime.Now, "info", "pending", "kfdnd", 2, 1, 1);
            notificationRepository.Save(secondTestedNotification);
            long actualOutput = notificationRepository.GetFreeNotificationId();
            long expectedOutput = 3;
            Assert.AreEqual(actualOutput, expectedOutput);
        }

    }
}
