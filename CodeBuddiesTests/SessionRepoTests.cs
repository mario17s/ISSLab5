using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddiesTests
{
    [TestFixture]
    internal class SessionRepoTests
    {

        [Test]
        public void GetBuddiesForSpecificSession_SelectsBuddiesIdsForASections_ReturnsListOfThem()
        {
            IBuddyRepository buddyRepository = new BuddyRepository();
            ISessionRepository sessionRepository = new SessionRepository();
            buddyRepository.ClearDatabase();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Alex", "alex.jpg", "inactive");
            sessionRepository.AddNewSession("nustiu", 1, 3);
            sessionRepository.AddNewSession("habarnam", 2, 3);
            List<long> actualOutput = sessionRepository.GetBuddiesForSpecificSession(2);
            List<long> expectedOutout = new List<long> { 2 };
            Assert.AreEqual(actualOutput[0], expectedOutout[0]);
        }

        [Test]
        public void GetAllSessionsOfABuddy_SelectsSessionsOfABuddy_ReturnsListOfThem()
        {
            IBuddyRepository buddyRepository = new BuddyRepository();
            ISessionRepository sessionRepository = new SessionRepository();
            buddyRepository.ClearDatabase();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Alex", "alex.jpg", "inactive");
            sessionRepository.AddNewSession("nustiu", 1, 3);
            sessionRepository.AddNewSession("habarnam", 2, 3);
            sessionRepository.AddNewSession("alabala", 1, 4);
            List<ISession> actualOutput = sessionRepository.GetAllSessionsOfABuddy(1);
            List<ISession> expectedOutput = new List<ISession>
            {
                new Session(1, 1, "nustiu", DateTime.Now, DateTime.Now, null, null, null, null, null, null, null),
                new Session(3, 1, "alabala", DateTime.Now, DateTime.Now, null, null, null, null, null, null, null)
            };
            Assert.AreEqual(expectedOutput[1].Id, actualOutput[1].Id);
        }

        [Test]
        public void AddBuddyMemberToSession_AddsRowInBuddySessionTable_InsertsNewBuddyInTheSession()
        {
            IBuddyRepository buddyRepository = new BuddyRepository();
            ISessionRepository sessionRepository = new SessionRepository();
            buddyRepository.ClearDatabase();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Alex", "alex.jpg", "inactive");
            sessionRepository.AddNewSession("nustiu", 1, 3);
            sessionRepository.AddBuddyMemberToSession(2, 1);
            List<long> actualOutput = sessionRepository.GetBuddiesForSpecificSession(1);
            List<long> expectedOutput = new List<long> { 1, 2 };
            Assert.AreEqual(actualOutput[0], expectedOutput[0]);
        }

        [Test]
        public void GetSessionName_FindsNameBasedOnSessionId_ReturnsTheFoundName()
        {
            IBuddyRepository buddyRepository = new BuddyRepository();
            ISessionRepository sessionRepository = new SessionRepository();
            buddyRepository.ClearDatabase();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Alex", "alex.jpg", "inactive");
            sessionRepository.AddNewSession("nustiu", 1, 3);
            string actualOutput = sessionRepository.GetSessionName(1);
            string expectedOutput = "nustiu";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetFreeSessionId_FindsTheSuccessorOfTheMaximumSessionId_ReturnsItAsTheNextFreeSessionId()
        {
            IBuddyRepository buddyRepository = new BuddyRepository();
            ISessionRepository sessionRepository = new SessionRepository();
            buddyRepository.ClearDatabase();
            buddyRepository.AddBuddy(1, "Mario", "mario.jpg", "active");
            buddyRepository.AddBuddy(2, "Alex", "alex.jpg", "inactive");
            sessionRepository.AddNewSession("nustiu", 1, 3);
            long actualOutput = sessionRepository.GetFreeSessionId();
            long expectedOutput = 2;
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
