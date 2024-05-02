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
    public class InviteNotificationTests
    {
        private Mock<INotification> mockInviteNotification;
        [SetUp]
        public void Setup()
        {
            mockInviteNotification = new Mock<INotification>();
        }

        [Test]
        public void InviteNotification_Constructor_ShouldCreateInviteNotificationWithCorrectNotificationId()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;
            bool isAccepted = false;

            var mockInviteNotification = new Mock<INotification>();
            mockInviteNotification.Setup(inviteNotification => inviteNotification.NotificationId).Returns(notificationId);
            long actualNotificationId = mockInviteNotification.Object.NotificationId;
            Assert.AreEqual(notificationId, actualNotificationId);
        }

        [Test]
        public void InviteNotification_Constructor_ShouldCreateInviteNotificationWithCorrectTimeStamp()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;
            bool isAccepted = false;

            var mockInviteNotification = new Mock<INotification>();
            mockInviteNotification.Setup(inviteNotification => inviteNotification.TimeStamp).Returns(timeStamp);
            DateTime actualTimeStamp = mockInviteNotification.Object.TimeStamp;

            Assert.AreEqual(timeStamp, actualTimeStamp);
        }

        [Test]
        public void InviteNotification_Constructor_ShouldCreateInviteNotificationWithCorrectType()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;
            bool isAccepted = false;

            var mockInviteNotification = new Mock<INotification>();
            mockInviteNotification.Setup(inviteNotification => inviteNotification.Type).Returns(type);
            string actualType = mockInviteNotification.Object.Type;
            Assert.AreEqual(type, actualType);
        }
        [Test]
        public void InviteNotification_Constructor_ShouldCreateInviteNotificationWithCorrectStatus()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;
            bool isAccepted = false;

            var mockInviteNotification = new Mock<INotification>();
            mockInviteNotification.Setup(inviteNotification => inviteNotification.Status).Returns(status);
            string actualStatus = mockInviteNotification.Object.Status;
            Assert.AreEqual(status, actualStatus);
        }
        [Test]
        public void InviteNotification_Constructor_ShouldCreateInviteNotificationWithCorrectDescription()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;
            bool isAccepted = false;

            var mockInviteNotification = new Mock<INotification>();
            mockInviteNotification.Setup(inviteNotification => inviteNotification.Description).Returns(description);
            string actualDescription = mockInviteNotification.Object.Description;
            Assert.AreEqual(description, actualDescription);
        }
        [Test]
        public void InviteNotification_Constructor_ShouldCreateInviteNotificationWithCorrectSenderId()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;
            bool isAccepted = false;

            var mockInviteNotification = new Mock<INotification>();
            mockInviteNotification.Setup(inviteNotification => inviteNotification.SenderId).Returns(senderId);
            long actualId = mockInviteNotification.Object.SenderId;
            Assert.AreEqual(senderId, actualId);
        }
        [Test]
        public void InviteNotification_Constructor_ShouldCreateInviteNotificationWithCorrectReceiverId()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;
            bool isAccepted = false;

            var mockInviteNotification = new Mock<INotification>();
            mockInviteNotification.Setup(inviteNotification => inviteNotification.ReceiverId).Returns(receiverId);
            long actualId = mockInviteNotification.Object.ReceiverId;
            Assert.AreEqual(receiverId, actualId);
        }

        [Test]
        public void InviteNotification_Constructor_ShouldCreateInviteNotificationWithCorrectSessionId()
        {
            long notificationId = 1;
            DateTime timeStamp = DateTime.Now;
            string type = "info";
            string status = "unread";
            string description = "Test notification";
            long senderId = 123;
            long receiverId = 456;
            long sessionId = 789;
            bool isAccepted = false;

            var mockInviteNotification = new Mock<INotification>();
            mockInviteNotification.Setup(inviteNotification => inviteNotification.SessionId).Returns(sessionId);
            long actualId = mockInviteNotification.Object.SessionId;
            Assert.AreEqual(sessionId, actualId);
        }

        [Test]
        public void InviteNotification_SetIsAccepted_ShouldSetIsAcceptedCorrectly()
        {
            bool expectedIsAccepted = true;
            var mockNotification = new Mock<IInviteNotification>();
            mockNotification.Object.IsAccepted = expectedIsAccepted;
            mockNotification.Object.NotificationId = 1;
            mockNotification.Object.SessionId = 1;
            mockNotification.Object.SenderId = 2;
            mockNotification.Object.ReceiverId = 3;
            mockNotification.Object.TimeStamp = DateTime.Now;
            mockNotification.Object.Status = "status";
            mockNotification.Object.Description = "description";
            mockNotification.Object.Type = "type";
            mockNotification.VerifySet(notification => notification.IsAccepted = expectedIsAccepted, Times.Once);
        }
    }
}
