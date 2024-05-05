using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
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
        public void GetAllBuddies_SelectAllBuddies_ReturnListOfAllBuddies()
        {
            IBuddyRepository buddyRepository = new BuddyRepository();
            buddyRepository.ClearDatabase();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            List<IBuddy> actualOutput = buddyRepository.GetAllBuddies();
            List<IBuddy> expectedOutput = new List<IBuddy> { new Buddy(1, "Mario", "mario.jpg", "active", null) };
            Assert.AreEqual(actualOutput[0].Id, expectedOutput[0].Id);
        }

        [Test]
        public void GetActiveBuddies_SelectAllActiveBuddies_ReturnListOfAllActiveBuddies()
        {
            IBuddyRepository buddyRepository = new BuddyRepository();
            buddyRepository.ClearDatabase();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Alex", "alex.jpg", "inactive");
            List<IBuddy> actualOutput = buddyRepository.GetActiveBuddies();
            List<IBuddy> expectedOutput = new List<IBuddy> { new Buddy(1, "Mario", "mario.jpg", "active", null) };
            Assert.AreEqual(actualOutput[0].Id, expectedOutput[0].Id);
        }


        [Test]
        public void GetInactiveBuddies_SelectAllInactiveBuddies_ReturnListOfAllInactiveBuddies()
        {
            IBuddyRepository buddyRepository = new BuddyRepository();
            buddyRepository.ClearDatabase();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Alex", "alex.jpg", "inactive");
            List<IBuddy> actualOutput = buddyRepository.GetInactiveBuddies();
            List<IBuddy> expectedOutput = new List<IBuddy> { new Buddy(2, "Alex", "alex.jpg", "inactive", null) };
            Assert.AreEqual(actualOutput[0].Id, expectedOutput[0].Id);
        }

        [Test]
        public void UpdateBuddyStatus_FromActiveToInactive_SetsBuddyStatusToInactive()
        {
            IBuddyRepository buddyRepository = new BuddyRepository();
            buddyRepository.ClearDatabase();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            IBuddy updatedBuddy = new Buddy(1, "Mario", "mario.jpg", "active", null);
            IBuddy returnedBuddy = buddyRepository.UpdateBuddyStatus(updatedBuddy);
            Assert.AreEqual(returnedBuddy.Status, "inactive");
        }

    }
}
