using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;
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
        public void GetMessagesForSpecificSession_SelectsMessagesForASection_ReturnsListOfMessagesOfThatSessionId()
        {
            long sessionId = 1;
            var mockRepository = new Mock<ISessionRepository>();
            var expectedOutput = new List<IMessage> { new Mock<IMessage>().SetupAllProperties().Object };
            expectedOutput[0].MessageId = 1;
            expectedOutput[0].TimeStamp = DateTime.Now;
            expectedOutput[0].Content = "njbfbg";
            expectedOutput[0].SenderId = 2;
            mockRepository.Setup(repository => repository.GetMessagesForSpecificSession(sessionId)).Returns(expectedOutput);
            var repositoryObject = mockRepository.Object;
            var actualOutput = repositoryObject.GetMessagesForSpecificSession(sessionId);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetCodeContributionsForSpecificSession_SelectsContributionsForASection_ReturnsListOfCodeContributionsOfThatSessionId()
        {
            long sessionId = 1;
            var mockRepository = new Mock<ISessionRepository>();
            var expectedOutput = new List<ICodeContribution> { new Mock<ICodeContribution>().SetupAllProperties().Object };
            expectedOutput[0].Contributor = 1;
            expectedOutput[0].ContributionDate = DateTime.Now;
            expectedOutput[0].ContributionValue = 10;
            mockRepository.Setup(repository => repository.GetCodeContributionsForSpecificSession(sessionId)).Returns(expectedOutput);
            var repositoryObject = mockRepository.Object;
            var actualOutput = repositoryObject.GetCodeContributionsForSpecificSession(sessionId);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetMessagesForSpecificCodeReview_SelectsMessagesForACodeReview_ReturnsListOfMessagesOfThatCodeReview()
        {
            long codeReviewId = 1;
            var mockRepository = new Mock<ISessionRepository>();
            var expectedOutput = new List<IMessage> { new Mock<IMessage>().SetupAllProperties().Object };
            expectedOutput[0].MessageId = 1;
            expectedOutput[0].TimeStamp = DateTime.Now;
            expectedOutput[0].Content = "njbfbg";
            expectedOutput[0].SenderId = 2;
            mockRepository.Setup(repository => repository.GetMessagesForSpecificCodeReview(codeReviewId)).Returns(expectedOutput);
            var repositoryObject = mockRepository.Object;
            var actualOutput = repositoryObject.GetMessagesForSpecificCodeReview(codeReviewId);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetCodeReviewSectionsForSpecificSession_SelectsCodeReviewSectionsForASections_ReturnsListOfThem()
        {
            long sessionId = 1;
            var mockRepository = new Mock<ISessionRepository>();
            var expectedOutput = new List<ICodeReviewSection> { new Mock<ICodeReviewSection>().SetupAllProperties().Object };
            expectedOutput[0].Id = 1;
            expectedOutput[0].OwnerId = 2;
            expectedOutput[0].Messages = new List<IMessage>();
            expectedOutput[0].CodeSection = "int a = 5;";
            expectedOutput[0].IsClosed = true;
            mockRepository.Setup(repository => repository.GetCodeReviewSectionsForSpecificSession(sessionId)).Returns(expectedOutput);
            var repositoryObject = mockRepository.Object;
            var actualOutput = repositoryObject.GetCodeReviewSectionsForSpecificSession(sessionId);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetBuddiesForSpecificSession_SelectsBuddiesIdsForASections_ReturnsListOfThem()
        {
            long sessionId = 1;
            var mockRepository = new Mock<ISessionRepository>();
            var expectedOutput = new List<long> { 1,2,3 };
            mockRepository.Setup(repository => repository.GetBuddiesForSpecificSession(sessionId)).Returns(expectedOutput);
            var repositoryObject = mockRepository.Object;
            var actualOutput = repositoryObject.GetBuddiesForSpecificSession(sessionId);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllSessionsOfABuddy_SelectsSessionsOfABuddy_ReturnsListOfThem()
        {
            long buddyId = 1;
            var mockRepository = new Mock<ISessionRepository>();
            var expectedOutput = new List<ISession> { new Mock<ISession>().SetupAllProperties().Object };
            expectedOutput[0].Id = 2;
            expectedOutput[0].OwnerId = 1;
            expectedOutput[0].Name = "nana";
            expectedOutput[0].CreationDate = DateTime.Now;
            expectedOutput[0].LastEditDate = DateTime.Now;
            expectedOutput[0].Buddies = new List<long> { 1, 2, 3 };
            expectedOutput[0].Messages = new List<IMessage>();
            expectedOutput[0].CodeContributions = new List<ICodeContribution>();
            expectedOutput[0].CodeReviewSections = new List<ICodeReviewSection>();
            expectedOutput[0].FilePaths = new List<string>();
            expectedOutput[0].TextEditor = null;
            expectedOutput[0].DrawingBoard = null;
            mockRepository.Setup(repository => repository.GetAllSessionsOfABuddy(buddyId)).Returns(expectedOutput);
            var repositoryObject = mockRepository.Object;
            var actualOutput = repositoryObject.GetAllSessionsOfABuddy(buddyId);
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [Test]
        public void AddBuddyMemberToSession_AddsRowInBuddySessionTable_InsertsNewBuddyInTheSession()
        {
            var mockRepository = new Mock<ISessionRepository>();
            long buddyId = 1;
            long sessionId = 2;

            mockRepository.Object.AddBuddyMemberToSession(buddyId, sessionId);

            mockRepository.Verify(repo => repo.AddBuddyMemberToSession(buddyId, sessionId), Times.Once);
        }

        [Test]
        public void GetSessionName_FindsNameBasedOnSessionId_ReturnsRgeFoundName()
        {
            var mockRepository = new Mock<ISessionRepository>();
            long sessionId = 2;
            string expectedOutput = "liga";
            mockRepository.Setup(repository => repository.GetSessionName(sessionId)).Returns(expectedOutput);
            var repositoryObject = mockRepository.Object;
            string actualOutput = repositoryObject.GetSessionName(sessionId);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetFreeSessionId_FindsTheSuccessorOfTheMaximumSessionId_ReturnsItAsTheNextFreeSessionId()
        {
            var mockRepository = new Mock<ISessionRepository>();
            long expectedOutput = 10;
            mockRepository.Setup(mockRepository => mockRepository.GetFreeSessionId()).Returns(expectedOutput);
            var repositoryObject = mockRepository.Object;
            long actualOutput = repositoryObject.GetFreeSessionId();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void AddNewSession_InsertsASessionInTheDatabase()
        {
            var mockRepository = new Mock<ISessionRepository>();
            string sessionName = "study";
            long ownerId = 1;
            int maximumNumberOfParticipants = 5;
            mockRepository.Object.AddNewSession(sessionName, ownerId, maximumNumberOfParticipants);
            mockRepository.Verify(repository => repository.AddNewSession(sessionName, ownerId, maximumNumberOfParticipants), Times.Once()); 
        }
    }
}
