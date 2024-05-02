using CodeBuddies.Models.Entities;
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
    public class BuddyEntityTests
    {
        private Mock<IBuddy> buddyMock;

        [SetUp]
        public void Setup()
        {
            buddyMock = new Mock<IBuddy>();
        }

        [Test]
        public void Buddy_GetId_ShouldReturnTheIdOfBuddy()
        {
            long expectedId = 123;
            buddyMock.Setup(buddy => buddy.Id).Returns(expectedId);

            long actualId = buddyMock.Object.Id;

            Assert.AreEqual(expectedId, actualId);

        }

        [Test]
        public void Buddy_SetId_ShouldSetTheBuddyId()
        {
            long expectedId = 123;
            buddyMock.SetupSet(buddy => buddy.Id = expectedId);

            buddyMock.Object.Id = expectedId;

            buddyMock.VerifySet(buddy => buddy.Id = expectedId, Times.Once());
        }

        [Test]
        public void Buddy_GetName_ShouldReturnTheBuddyName()
        {
            string expectedBuddyName = "John Doe";
            buddyMock.Setup(buddy => buddy.BuddyName).Returns(expectedBuddyName);

            string actualBuddyName = buddyMock.Object.BuddyName;

            Assert.AreEqual(expectedBuddyName, actualBuddyName);
        }

        [Test]
        public void Buddy_SetName_ShouldSetTheBuddyName()
        {
            string expectedBuddyName = "John Doe";
            buddyMock.SetupSet(buddy => buddy.BuddyName = expectedBuddyName);

            buddyMock.Object.BuddyName = expectedBuddyName;

            buddyMock.VerifySet(buddy => buddy.BuddyName = expectedBuddyName, Times.Once());
        }

        [Test]
        public void Buddy_GetProfilePhotoUrl_ShouldReturnTheProfilePhotoUrl()
        {
            string expectedProfilePhotoUrl = "https://www.example.com/profile.jpg";
            buddyMock.Setup(buddy => buddy.ProfilePhotoUrl).Returns(expectedProfilePhotoUrl);

            string actualProfilePhotoUrl = buddyMock.Object.ProfilePhotoUrl;

            Assert.AreEqual(expectedProfilePhotoUrl, actualProfilePhotoUrl);
        }

        [Test]
        public void Buddy_SetProfilePhotoUrl_ShouldSetTheProfilePhotoUrl()
        {
            string expectedProfilePhotoUrl = "https://www.example.com/profile.jpg";
            buddyMock.SetupSet(buddy => buddy.ProfilePhotoUrl = expectedProfilePhotoUrl);

            buddyMock.Object.ProfilePhotoUrl = expectedProfilePhotoUrl;

            buddyMock.VerifySet(buddy => buddy.ProfilePhotoUrl = expectedProfilePhotoUrl, Times.Once());
        }

        [Test]
        public void Buddy_GetStatus_ShouldReturnTheStatus()
        {
            string expectedStatus = "Available";
            buddyMock.Setup(buddy => buddy.Status).Returns(expectedStatus);

            string actualStatus = buddyMock.Object.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void Buddy_SetStatus_ShouldSetTheStatus()
        {
            string expectedStatus = "Available";
            buddyMock.SetupSet(buddy => buddy.Status = expectedStatus);

            buddyMock.Object.Status = expectedStatus;

            buddyMock.VerifySet(buddy => buddy.Status = expectedStatus, Times.Once());
        }

        [Test]
        public void Buddy_GetNotifications_ShouldReturnTheNotifications()
        {
            List<Notification> expectedNotifications = new List<Notification>();
            buddyMock.Setup(buddy => buddy.Notifications).Returns(expectedNotifications);

            List<Notification> actualNotifications = buddyMock.Object.Notifications;

            Assert.AreEqual(expectedNotifications, actualNotifications);
        }

        [Test]
        public void Buddy_SetNotifications_ShouldSetTheNotifications()
        {
            List<Notification> expectedNotifications = new List<Notification>();
            buddyMock.SetupSet(buddy => buddy.Notifications = expectedNotifications);

            buddyMock.Object.Notifications = expectedNotifications;

            buddyMock.VerifySet(buddy => buddy.Notifications = expectedNotifications, Times.Once());
        }
    }
}
