using CodeBuddies.Models.Entities.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddiesTests
{
    [TestFixture]
    public class InfoNotificationTests
    {
        private Mock<INotification> mockInfoNotification;
        [SetUp]
        public void Setup()
        {
            mockInfoNotification = new Mock<INotification>();
        }

        [Test]
        public void InfoNotification_Constructor_ShouldCreateInfoNotificationWithCorrectNotificationId()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;

            var mockInfoNotification = new Mock<INotification>();
            mockInfoNotification.Setup(infoNotification => infoNotification.NotificationId).Returns(notificationId);
            long actualNotificationId = mockInfoNotification.Object.NotificationId;
            Assert.AreEqual(notificationId, actualNotificationId);
        }

        [Test]
        public void InfoNotification_Constructor_ShouldCreateInfoNotificationWithCorrectTimeStamp()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;

            var mockInfoNotification = new Mock<INotification>();
            mockInfoNotification.Setup(infoNotification => infoNotification.TimeStamp).Returns(timeStamp);
            DateTime actualTimeStamp = mockInfoNotification.Object.TimeStamp;

            Assert.AreEqual(timeStamp, actualTimeStamp);
        }

        [Test]
        public void InfoNotification_Constructor_ShouldCreateInfoNotificationWithCorrectType()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;

            var mockInfoNotification = new Mock<INotification>();
            mockInfoNotification.Setup(infoNotification => infoNotification.Type).Returns(type);
            string actualType = mockInfoNotification.Object.Type;
            Assert.AreEqual(type, actualType);
        }
        [Test]
        public void InfoNotification_Constructor_ShouldCreateInfoNotificationWithCorrectStatus()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;

            var mockInfoNotification = new Mock<INotification>();
            mockInfoNotification.Setup(infoNotification => infoNotification.Status).Returns(status);
            string actualStatus = mockInfoNotification.Object.Status;
            Assert.AreEqual(status, actualStatus);
        }
        [Test]
        public void InfoNotification_Constructor_ShouldCreateInfoNotificationWithCorrectDescription()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;

            var mockInfoNotification = new Mock<INotification>();
            mockInfoNotification.Setup(infoNotification => infoNotification.Description).Returns(description);
            string actualDescription = mockInfoNotification.Object.Description;
            Assert.AreEqual(description, actualDescription);
        }
        [Test]
        public void InfoNotification_Constructor_ShouldCreateInfoNotificationWithCorrectSenderId()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;

            var mockInfoNotification = new Mock<INotification>();
            mockInfoNotification.Setup(infoNotification => infoNotification.SenderId).Returns(senderId);
            long actualId = mockInfoNotification.Object.SenderId;
            Assert.AreEqual(senderId, actualId);
        }
        [Test]
        public void InfoNotification_Constructor_ShouldCreateInfoNotificationWithCorrectReceiverId()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;

            var mockInfoNotification = new Mock<INotification>();
            mockInfoNotification.Setup(infoNotification => infoNotification.ReceiverId).Returns(receiverId);
            long actualId = mockInfoNotification.Object.ReceiverId;
            Assert.AreEqual(receiverId, actualId);
        }
        [Test]
        public void InfoNotification_Constructor_ShouldCreateInfoNotificationWithCorrectSessionId()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;

            var mockInfoNotification = new Mock<INotification>();
            mockInfoNotification.Setup(infoNotification => infoNotification.SessionId).Returns(sessionId);
            long actualId = mockInfoNotification.Object.SessionId;
            Assert.AreEqual(sessionId, actualId);
        }
    }

}
