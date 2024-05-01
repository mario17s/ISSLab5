using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;
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
            var mockRepository = new Mock<INotificationRepository>();
            var expectedNotifications = new List<INotification> {
                new Mock<INotification>().SetupAllProperties().Object,
                new Mock<INotification>().SetupAllProperties().Object
            };
            expectedNotifications[0].NotificationId = 1;
            expectedNotifications[0].TimeStamp = DateTime.Now;
            expectedNotifications[0].Type = "invite";
            expectedNotifications[0].Status = "read";
            expectedNotifications[0].Description = "test";
            expectedNotifications[0].SenderId = 1;
            expectedNotifications[0].ReceiverId = 1;
            expectedNotifications[0].SessionId = 1;
            expectedNotifications[1].NotificationId = 2;
            expectedNotifications[1].TimeStamp = DateTime.Now;
            expectedNotifications[1].Type = "invite";
            expectedNotifications[1].Status = "read";
            expectedNotifications[1].Description = "test";
            expectedNotifications[1].SenderId = 1;
            expectedNotifications[1].ReceiverId = 1;
            expectedNotifications[1].SessionId = 1;

            mockRepository.Setup(repository => repository.GetAll()).Returns(expectedNotifications);
            var actualNotifications = mockRepository.Object.GetAll();
            Assert.AreEqual(actualNotifications, expectedNotifications);
        }

        [Test]
        public void GetAllByBuddyId_FilterNotificationsById_ReturnNotificationWithThatReceiverId()
        {
            long testId = 1;
            var mockRepository = new Mock<INotificationRepository>();
            var expectedNotifications = new List<INotification> {
                new Mock<INotification>().SetupAllProperties().Object
            };
            expectedNotifications[0].NotificationId = 1;
            expectedNotifications[0].TimeStamp = DateTime.Now;
            expectedNotifications[0].Type = "invite";
            expectedNotifications[0].Status = "read";
            expectedNotifications[0].Description = "test";
            expectedNotifications[0].SenderId = 1;
            expectedNotifications[0].ReceiverId = 1;
            expectedNotifications[0].SessionId = 1;
            mockRepository.Setup(repository => repository.GetAllByBuddyId(testId)).Returns(expectedNotifications);
            var actualNotifications = mockRepository.Object.GetAllByBuddyId(testId);
            Assert.AreEqual(actualNotifications, expectedNotifications);
        }

        [Test]
        public void RemoveById_DeleteNotificationWithIdGiven()
        {
            var mockRepository = new Mock<INotificationRepository>();
            mockRepository.Setup(repo => repo.RemoveById(It.IsAny<long>()));

            var notificationId = 1;
            mockRepository.Object.RemoveById(notificationId);

            mockRepository.Verify(repo => repo.RemoveById(notificationId), Times.Once);
        }

        [Test]
        public void GetFreeNotificationId_ReturnsTheNextValidFreeIdForNotification()
        {
            var mockRepository = new Mock<INotificationRepository>();
            var expectedNotifications = new List<INotification> {
                new Mock<INotification>().SetupAllProperties().Object
            };
            expectedNotifications[0].NotificationId = 1;
            expectedNotifications[0].TimeStamp = DateTime.Now;
            expectedNotifications[0].Type = "invite";
            expectedNotifications[0].Status = "read";
            expectedNotifications[0].Description = "test";
            expectedNotifications[0].SenderId = 1;
            expectedNotifications[0].ReceiverId = 1;
            expectedNotifications[0].SessionId = 1;
            long expectedResult = 2;
            mockRepository.Setup(repository => repository.GetFreeNotificationId()).Returns(expectedResult);
            long actualResult = mockRepository.Object.GetFreeNotificationId();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Save_AddNewNotificationToRepository()
        {
            var mockRepository = new Mock<INotificationRepository>();
            var notification = new InfoNotification(123, DateTime.Now, "info", "read", "njfk", 1, 2, 3);
            
            mockRepository.Object.Save(notification);

            mockRepository.Verify(repo => repo.Save(notification), Times.Once);
        }
    }
}
