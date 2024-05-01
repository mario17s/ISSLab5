using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddiesTests
{
    [TestFixture]
    internal class BuddyRepoTests
    {
        [Test]
        public void GetAllBuddies_CountBuddiesInRepository_ReturnNumberOfAllBuddies()
        {
            var mockRepository = new Mock<IBuddyRepository>();
            var expectedBuddies = new List<IBuddy>
            {
                new Mock<IBuddy>().SetupAllProperties().Object
            };
            expectedBuddies[0].Id = 1;
            expectedBuddies[0].BuddyName = "Mario";
            expectedBuddies[0].ProfilePhotoUrl = "mario.jpg";
            expectedBuddies[0].Status = "active";
            expectedBuddies[0].Notifications = new List<Notification>();
            mockRepository.Setup(repository => repository.GetAllBuddies()).Returns(expectedBuddies);
            var actualBuddies = mockRepository.Object.GetAllBuddies();
            Assert.AreEqual(1, actualBuddies.Count);
        }

        [Test]
        public void GetAllBuddies_SelectAllBuddies_ReturnListOfAllBuddies()
        {
            var mockRepository = new Mock<IBuddyRepository>();
            var expectedBuddies = new List<IBuddy>
            {
                new Mock<IBuddy>().SetupAllProperties().Object,
                new Mock<IBuddy>().SetupAllProperties().Object

            };
            expectedBuddies[0].Id = 1;
            expectedBuddies[0].BuddyName = "Mario";
            expectedBuddies[0].ProfilePhotoUrl = "mario.jpg";
            expectedBuddies[0].Status = "active";
            expectedBuddies[0].Notifications = new List<Notification>();
            expectedBuddies[1].Id = 2;
            expectedBuddies[1].BuddyName = "Ana";
            expectedBuddies[1].ProfilePhotoUrl = "ana.jpg";
            expectedBuddies[1].Status = "inactive";
            expectedBuddies[1].Notifications = new List<Notification>();
            mockRepository.Setup(repository => repository.GetAllBuddies()).Returns(expectedBuddies);
            var actualBuddies = mockRepository.Object.GetAllBuddies();

            Assert.AreEqual(expectedBuddies, actualBuddies);
        }

        [Test]
        public void GetActiveBuddies_SelectAllActiveBuddies_ReturnListOfAllActiveBuddies()
        {
            var mockRepository = new Mock<IBuddyRepository>();

            IBuddy activeBuddy = new Buddy(1, "Mario", "mario.jpg", "active", new List<Notification>());

            List<IBuddy> expectedBuddies = new List<IBuddy> { activeBuddy };

            mockRepository.Setup(repository => repository.GetActiveBuddies()).Returns(expectedBuddies);
            var objectRepository = mockRepository.Object;
            var actualBuddies = objectRepository.GetActiveBuddies();
            
            Assert.AreEqual(actualBuddies, expectedBuddies);
        }


        [Test]
        public void GetInactiveBuddies_SelectAllInactiveBuddies_ReturnListOfAllInactiveBuddies()
        {
            var mockRepository = new Mock<IBuddyRepository>();
            var expectedBuddies = new List<IBuddy>
            {
                new Mock<IBuddy>().SetupAllProperties().Object
            };
            expectedBuddies[0].Id = 1;
            expectedBuddies[0].BuddyName = "Mario";
            expectedBuddies[0].ProfilePhotoUrl = "mario.jpg";
            expectedBuddies[0].Status = "inactive";
            expectedBuddies[0].Notifications = new List<Notification>();
            mockRepository.Setup(repository => repository.GetInactiveBuddies()).Returns(expectedBuddies);
            var actualBuddies = mockRepository.Object.GetInactiveBuddies();

            Assert.AreEqual(expectedBuddies, actualBuddies);
        }


        [Test]
        public void UpdateBuddyStatus_FromActiveToInactive_SetsBuddyStatusToInactive()
        {
            var mockBuddy = new Mock<IBuddy>();
            mockBuddy.SetupProperty(buddy => buddy.Status, "active");
            var repository = new BuddyRepository();
            repository.UpdateBuddyStatus(mockBuddy.Object);
            Assert.AreEqual("inactive", mockBuddy.Object.Status);
        }
    }
}
