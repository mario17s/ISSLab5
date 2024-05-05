using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Services;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Repositories;

namespace CodeBuddiesTests
{
    [TestFixture]
    public class NotificationServiceTest
    {
        [Test]
        public void NotificationRepository_Getter_ReturnsValueOfNotificationRepository()
        {
            var mockNotificationRepository = new Mock<INotificationRepository>();
            var notificationService = new NotificationService(mockNotificationRepository.Object);

            var notificationRepository = notificationService.NotificationRepository;

            Assert.That(notificationRepository, Is.EqualTo(mockNotificationRepository.Object));
        }

        [Test]
        public void NotificationRepository_Setter_SetsValueOfNotificationRepository()
        {
            var mockNotificationRepository = new Mock<INotificationRepository>();
            var buddyService = new NotificationService(mockNotificationRepository.Object);
            var newNotificationRepository = new Mock<INotificationRepository>().Object;

            buddyService.NotificationRepository = newNotificationRepository;

            Assert.That(buddyService.NotificationRepository, Is.EqualTo(newNotificationRepository));
        }

        [Test]
        public void Constructor_WithNotificationRepository_InitializesNotificationRepository()
        {
            var mockNotificationRepository = new Mock<INotificationRepository>().Object;

            var notificationService = new NotificationService(mockNotificationRepository);

            Assert.That(notificationService.NotificationRepository, Is.EqualTo(mockNotificationRepository));
        }

        [Test]
        public void GetAllNotificationsForCurrentBuddy_WithSomeNotifications_ReturnsListOfNotificationsForCurrentBuddy()
        {
            var mockNotificationRepository = new Mock<INotificationRepository>();
            var expectedNotifications = new List<INotification>
            {
                new Mock<INotification>().SetupAllProperties().Object
            };
            expectedNotifications[0].NotificationId = 1;
            expectedNotifications[0].TimeStamp = new DateTime(2024, 4, 30);
            expectedNotifications[0].Type = "type";
            expectedNotifications[0].Status = "status";
            expectedNotifications[0].Description = "description";
            expectedNotifications[0].SenderId = 1;
            expectedNotifications[0].ReceiverId = 2;
            expectedNotifications[0].SessionId = 1;
            long buddyId = 2;
            mockNotificationRepository.Setup(repository => repository.GetAllByBuddyId(buddyId)).Returns(expectedNotifications);
            var notificationService = new NotificationService(mockNotificationRepository.Object);

            var notifications = notificationService.GetAllNotificationsForCurrentBuddy();

            Assert.That(notifications, Is.EqualTo(expectedNotifications));
        }

        [Test]
        public void GetAllNotificationsForCurrentBuddy_WithNoNotifications_ReturnsEmptyList()
        {
            var mockNotificationRepository = new Mock<INotificationRepository>();
            long buddyId = 2;
            mockNotificationRepository.Setup(repository => repository.GetAllByBuddyId(buddyId)).Returns(new List<INotification>());
            var notificationService = new NotificationService(mockNotificationRepository.Object);

            var notifications = notificationService.GetAllNotificationsForCurrentBuddy();

            Assert.That(notifications, Is.Empty);
        }

        [Test]
        public void GetFreeNotificationId_FromNotificationRepository_ReturnsTheCorrectFreeNotificationId()
        {
            long expectedId = 10;
            var mockRepository = new Mock<INotificationRepository>();
            mockRepository.Setup(repository => repository.GetFreeNotificationId()).Returns(expectedId);
            var notificationService = new NotificationService(mockRepository.Object);

            long actualId = notificationService.GetFreeNotificationId();

            Assert.That(actualId, Is.EqualTo(expectedId));
        }

        [Test]
        public void RemoveNotification_WithId10ForBuddyWithId2_ResultsEmptyNotificationList()
        {
            long notificationId = 10;
            long buddyId = 2;
            var mockNotificationRepository = new Mock<INotificationRepository>();
            var notification = new Mock<INotification>();
            notification.SetupGet(notification => notification.NotificationId).Returns(notificationId);
            notification.SetupGet(notification => notification.ReceiverId).Returns(buddyId);
            mockNotificationRepository.Setup(repository => repository.GetAllByBuddyId(buddyId)).Returns((List<INotification>)null);
            var notificationService = new NotificationService(mockNotificationRepository.Object);

            notificationService.RemoveNotification(notification.Object);

            Assert.IsNull(mockNotificationRepository.Object.GetAllByBuddyId(notificationId));
        }

        [Test]
        public void AddNotification_ToRepository_SavesNotificationToRepository()
        {
            long buddyId = 2;
            var mockNotificationRepository = new Mock<INotificationRepository>();
            var notifications = new List<INotification>
            {
                new Mock<INotification>().Object,
            };
            notifications[0].NotificationId = 1;
            notifications[0].ReceiverId = buddyId;
            var notification = notifications[0];
            mockNotificationRepository.Setup(repository => repository.GetAllByBuddyId(buddyId)).Returns(notifications);
            var notificationService = new NotificationService(mockNotificationRepository.Object);

            notificationService.AddNotification(notification);

            Assert.Contains(notification, mockNotificationRepository.Object.GetAllByBuddyId(buddyId));
        }
    }
}
