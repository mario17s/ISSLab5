using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities;
using CodeBuddies.Services;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Repositories.Interfaces;

namespace CodeBuddiesTests
{
    public class BuddyServiceTest
    {
        [TestFixture]
        public class BuddyServiceTests
        {
            [Test]
            public void BuddyRepository_Getter_ReturnsValueOfBuddyRepository()
            {
                var mockBuddyRepository = new Mock<IBuddyRepository>();
                var buddyService = new BuddyService(mockBuddyRepository.Object);

                var buddyRepository = buddyService.BuddyRepository;

                Assert.That(buddyRepository, Is.EqualTo(mockBuddyRepository.Object));
            }

            [Test]
            public void BuddyRepository_Setter_SetsValueOfBuddyRepository()
            {
                var mockBuddyRepository = new Mock<IBuddyRepository>();
                var buddyService = new BuddyService(mockBuddyRepository.Object);
                var newBuddyRepository = new Mock<IBuddyRepository>().Object;

                buddyService.BuddyRepository = newBuddyRepository;

                Assert.That(buddyService.BuddyRepository, Is.EqualTo(newBuddyRepository));
            }

            [Test]
            public void ActiveBuddies_Getter_ReturnsListOfActiveBuddies()
            {
                var expectedBuddies = new List<IBuddy>
                {
                    new Mock<IBuddy>().SetupAllProperties().Object
                };
                expectedBuddies[0].Id = 1;
                expectedBuddies[0].BuddyName = "Buddy1";
                expectedBuddies[0].ProfilePhotoUrl = "profile1.jpg";
                expectedBuddies[0].Status = "active";
                expectedBuddies[0].Notifications = new List<Notification>();
                var buddyService = new BuddyService(new Mock<IBuddyRepository>().Object);
                buddyService.ActiveBuddies = expectedBuddies;

                var activeBuddies = buddyService.ActiveBuddies;

                Assert.That(activeBuddies, Is.EqualTo(expectedBuddies));
            }

            [Test]
            public void ActiveBuddies_Setter_SetsTheListOfActiveBuddies()
            {
                var buddyService = new BuddyService(new Mock<IBuddyRepository>().Object);
                var newBuddies = new List<IBuddy>
                {
                    new Mock<IBuddy>().SetupAllProperties().Object
                };
                newBuddies[0].Id = 1;
                newBuddies[0].BuddyName = "Buddy1";
                newBuddies[0].ProfilePhotoUrl = "profile1.jpg";
                newBuddies[0].Status = "active";
                newBuddies[0].Notifications = new List<Notification>();

                buddyService.ActiveBuddies = newBuddies;

                Assert.That(buddyService.ActiveBuddies, Is.EqualTo(newBuddies));
            }

            [Test]
            public void InactiveBuddies_Getter_ReturnsListOfInactiveBuddies()
            {
                var expectedBuddies = new List<IBuddy>
                {
                    new Mock<IBuddy>().SetupAllProperties().Object
                };
                expectedBuddies[0].Id = 1;
                expectedBuddies[0].BuddyName = "Buddy1";
                expectedBuddies[0].ProfilePhotoUrl = "profile1.jpg";
                expectedBuddies[0].Status = "inactive";
                expectedBuddies[0].Notifications = new List<Notification>();
                var buddyService = new BuddyService(new Mock<IBuddyRepository>().Object);
                buddyService.ActiveBuddies = expectedBuddies;

                var activeBuddies = buddyService.ActiveBuddies;

                Assert.That(activeBuddies, Is.EqualTo(expectedBuddies));
            }

            [Test]
            public void InactiveBuddies_Setter_SetsTheListOfInactiveBuddies()
            {
                var buddyService = new BuddyService(new Mock<IBuddyRepository>().Object);
                var newBuddies = new List<IBuddy>
                {
                    new Mock<IBuddy>().SetupAllProperties().Object
                };
                newBuddies[0].Id = 1;
                newBuddies[0].BuddyName = "Buddy1";
                newBuddies[0].ProfilePhotoUrl = "profile1.jpg";
                newBuddies[0].Status = "active";
                newBuddies[0].Notifications = new List<Notification>();

                buddyService.ActiveBuddies = newBuddies;

                Assert.That(buddyService.ActiveBuddies, Is.EqualTo(newBuddies));
            }

            [Test]
            public void Constructor_WithActiveBuddies_InitializesActiveBuddiesFromBuddyRepository()
            {
                var expectedActiveBuddies = new List<IBuddy>
                {
                    new Mock<IBuddy>().SetupAllProperties().Object
                };
                expectedActiveBuddies[0].Id = 1;
                expectedActiveBuddies[0].BuddyName = "Buddy1";
                expectedActiveBuddies[0].ProfilePhotoUrl = "profile1.jpg";
                expectedActiveBuddies[0].Status = "active";
                expectedActiveBuddies[0].Notifications = new List<Notification>();
                var mockRepository = new Mock<IBuddyRepository>();
                mockRepository.Setup(repository => repository.GetActiveBuddies()).Returns(expectedActiveBuddies);

                var buddyService = new BuddyService(mockRepository.Object);

                Assert.That(buddyService.ActiveBuddies, Is.EqualTo(expectedActiveBuddies));
            }

            [Test]
            public void Constructor_WithInactiveBuddies_InitializesInactiveBuddiesFromBuddyRepository()
            {
                var expectedInactiveBuddies = new List<IBuddy>
                {
                    new Mock<IBuddy>().SetupAllProperties().Object
                };
                expectedInactiveBuddies[0].Id = 1;
                expectedInactiveBuddies[0].BuddyName = "Buddy1";
                expectedInactiveBuddies[0].ProfilePhotoUrl = "profile1.jpg";
                expectedInactiveBuddies[0].Status = "inactive";
                expectedInactiveBuddies[0].Notifications = new List<Notification>();
                var mockRepository = new Mock<IBuddyRepository>();
                mockRepository.Setup(repository => repository.GetInactiveBuddies()).Returns(expectedInactiveBuddies);

                var buddyService = new BuddyService(mockRepository.Object);

                Assert.That(buddyService.InactiveBuddies, Is.EqualTo(expectedInactiveBuddies));
            }

            [Test]
            public void GetAllBuddies_FromBuddyRepository_ReturnsAllBuddies()
            {
                var expectedBuddies = new List<IBuddy>
                {
                    new Mock<IBuddy>().SetupAllProperties().Object,
                    new Mock<IBuddy>().SetupAllProperties().Object
                };
                expectedBuddies[0].Id = 1;
                expectedBuddies[0].BuddyName = "Buddy1";
                expectedBuddies[0].ProfilePhotoUrl = "profile1.jpg";
                expectedBuddies[0].Status = "inactive";
                expectedBuddies[0].Notifications = new List<Notification>();
                expectedBuddies[1].Id = 2;
                expectedBuddies[1].BuddyName = "Buddy2";
                expectedBuddies[1].ProfilePhotoUrl = "profile2.jpg";
                expectedBuddies[1].Status = "active";
                expectedBuddies[1].Notifications = new List<Notification>();
                var mockBuddyRepository = new Mock<IBuddyRepository>();
                mockBuddyRepository.Setup(repository => repository.GetAllBuddies()).Returns(expectedBuddies);
                var buddyService = new BuddyService(mockBuddyRepository.Object);

                var allBuddies = buddyService.GetAllBuddies();

                Assert.That(allBuddies, Is.EqualTo(expectedBuddies));
            }

            [Test]
            public void FilterBuddies_WithBuddyInName_ReturnsBuddiesContainingBuddy()
            {
                string searchText = "Buddy";
                var allBuddies = new List<IBuddy>
                {
                    new Mock<IBuddy>().SetupAllProperties().Object,
                    new Mock<IBuddy>().SetupAllProperties().Object
                };
                allBuddies[0].Id = 1;
                allBuddies[0].BuddyName = "Buddy1";
                allBuddies[0].ProfilePhotoUrl = "profile1.jpg";
                allBuddies[0].Status = "inactive";
                allBuddies[0].Notifications = new List<Notification>();
                allBuddies[1].Id = 2;
                allBuddies[1].BuddyName = "Buddy2";
                allBuddies[1].ProfilePhotoUrl = "profile2.jpg";
                allBuddies[1].Status = "active";
                allBuddies[1].Notifications = new List<Notification>();
                var mockRepository = new Mock<IBuddyRepository>();
                mockRepository.Setup(repository => repository.GetAllBuddies()).Returns(allBuddies);
                var buddyService = new BuddyService(mockRepository.Object);

                var resultedBuddies = buddyService.FilterBuddies(searchText);

                Assert.IsTrue(resultedBuddies.TrueForAll(buddy => buddy.BuddyName.Contains(searchText)));
            }

            [Test]
            public void RefreshData_WithActiveBuddies_UpdatesActiveBuddies()
            {
                var expectedActiveBuddies = new List<IBuddy>
                {
                    new Mock<IBuddy>().SetupAllProperties().Object
                };
                expectedActiveBuddies[0].Id = 1;
                expectedActiveBuddies[0].BuddyName = "Buddy1";
                expectedActiveBuddies[0].ProfilePhotoUrl = "profile1.jpg";
                expectedActiveBuddies[0].Status = "active";
                expectedActiveBuddies[0].Notifications = new List<Notification>();
                var mockBuddyRepository = new Mock<IBuddyRepository>();
                mockBuddyRepository.Setup(repository => repository.GetActiveBuddies()).Returns(expectedActiveBuddies);
                var buddyService = new BuddyService(mockBuddyRepository.Object);

                buddyService.RefreshData();

                Assert.That(buddyService.ActiveBuddies, Is.EqualTo(expectedActiveBuddies));
            }

            [Test]
            public void RefreshData_WithActiveBuddies_UpdatesInactiveBuddies()
            {
                var expectedInactiveBuddies = new List<IBuddy>
                {
                    new Mock<IBuddy>().SetupAllProperties().Object
                };
                expectedInactiveBuddies[0].Id = 1;
                expectedInactiveBuddies[0].BuddyName = "Buddy1";
                expectedInactiveBuddies[0].ProfilePhotoUrl = "profile1.jpg";
                expectedInactiveBuddies[0].Status = "inactive";
                expectedInactiveBuddies[0].Notifications = new List<Notification>();
                var mockBuddyRepository = new Mock<IBuddyRepository>();
                mockBuddyRepository.Setup(repository => repository.GetInactiveBuddies()).Returns(expectedInactiveBuddies);
                var buddyService = new BuddyService(mockBuddyRepository.Object);

                buddyService.RefreshData();

                Assert.That(buddyService.InactiveBuddies, Is.EqualTo(expectedInactiveBuddies));
            }

            [Test]
            public void ChangeBuddyStatus_FromInactiveToActive_UpdatesBuddyStatusToActive()
            {
                var buddyToUpdate = new Mock<IBuddy>();
                buddyToUpdate.SetupProperty(buddy => buddy.Status, "inactive");
                var mockBuddyRepository = new Mock<IBuddyRepository>();
                mockBuddyRepository.Setup(repository => repository.UpdateBuddyStatus(buddyToUpdate.Object))
                              .Returns((IBuddy buddy) =>
                              {
                                  buddy.Status = "active";
                                  return buddy;
                              });
                var buddyService = new BuddyService(mockBuddyRepository.Object);

                var changedBuddy = buddyService.ChangeBuddyStatus(buddyToUpdate.Object);

                Assert.That(changedBuddy.Status, Is.EqualTo("active"));
            }

            [Test]
            public void ChangeBuddyStatus_FromActiveToInactive_UpdatesBuddyStatusToInactive()
            {
                var buddyToUpdate = new Mock<IBuddy>();
                buddyToUpdate.SetupProperty(buddy => buddy.Status, "active");
                var mockBuddyRepository = new Mock<IBuddyRepository>();
                mockBuddyRepository.Setup(repository => repository.UpdateBuddyStatus(buddyToUpdate.Object))
                              .Returns((IBuddy buddy) =>
                              {
                                  buddy.Status = "inactive";
                                  return buddy;
                              });
                var buddyService = new BuddyService(mockBuddyRepository.Object);

                var changedBuddy = buddyService.ChangeBuddyStatus(buddyToUpdate.Object);

                Assert.That(changedBuddy.Status, Is.EqualTo("inactive"));
            }

        }
    }
}
