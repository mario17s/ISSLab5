using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Services;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Validators;
using CodeBuddies.Models.Exceptions;
using CodeBuddies.Views.UserControls;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Repositories.Interfaces;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;

namespace CodeBuddiesTests
{
    [TestFixture]
    public class SessionServiceTest
    {
        [Test]
        public void SessionRepository_Getter_ReturnsValueOfSessionRepository()
        {
            var mockSessionRepository = new Mock<ISessionRepository>();
            var sessionService = new SessionService(mockSessionRepository.Object);

            var sessionRepository = sessionService.SessionRepository;

            Assert.That(sessionRepository, Is.EqualTo(mockSessionRepository.Object));
        }

        [Test]
        public void SessionRepository_Setter_SetsValueOfSessionRepository()
        {
            var mockSessionRepository = new Mock<ISessionRepository>();
            var sessionService = new SessionService(mockSessionRepository.Object);
            var newSessionRepository = new Mock<ISessionRepository>().Object;

            sessionService.SessionRepository = newSessionRepository;

            Assert.That(sessionService.SessionRepository, Is.EqualTo(newSessionRepository));
        }

        [Test]
        public void Constructor_WithSessionRepository_InitializesSessionRepository()
        {
            var mockSessionRepository = new Mock<ISessionRepository>().Object;

            var sessionService = new SessionService(mockSessionRepository);

            Assert.That(sessionService.SessionRepository, Is.EqualTo(mockSessionRepository));
        }

        [Test]
        public void GetAllSessionsForCurrentBuddy_WithSomeSessions_ReturnsListOfSessionsForCurrentBuddy()
        {
            var mockSessionionRepository = new Mock<ISessionRepository>();
            var expectedSessions = new List<ISession>
            {
                new Mock<ISession>().SetupAllProperties().Object
            };
            expectedSessions[0].Id = 1;
            expectedSessions[0].OwnerId = 2;
            expectedSessions[0].Name = "name";
            expectedSessions[0].CreationDate = new DateTime(2024, 4, 30);
            expectedSessions[0].LastEditDate = new DateTime(2024, 5, 1);
            expectedSessions[0].Buddies = new List<long>();
            expectedSessions[0].Messages = new List<IMessage>();
            expectedSessions[0].CodeContributions = new List<ICodeContribution>();
            expectedSessions[0].CodeReviewSections = new List<ICodeReviewSection>();
            expectedSessions[0].FilePaths = new List<string>();
            expectedSessions[0].TextEditor = new TextEditor("color", new List<string>());
            expectedSessions[0].DrawingBoard = new CodeBuddies.Models.Entities.DrawingBoard("filepath");
            long buddyId = 2;
            mockSessionionRepository.Setup(repository => repository.GetAllSessionsOfABuddy(buddyId)).Returns(expectedSessions);
            var sessionService = new SessionService(mockSessionionRepository.Object);

            var notifications = sessionService.GetAllSessionsForCurrentBuddy();

            Assert.That(notifications, Is.EqualTo(expectedSessions));
        }

        [Test]
        public void GetAllSessionsForCurrentBuddy_WithNoSessions_ReturnsEmptyList()
        {
            var mockSessionRepository = new Mock<ISessionRepository>();
            long buddyId = 2;
            mockSessionRepository.Setup(repository => repository.GetAllSessionsOfABuddy(buddyId)).Returns(new List<ISession>());
            var sessionService = new SessionService(mockSessionRepository.Object);

            var sessions = sessionService.GetAllSessionsForCurrentBuddy();

            Assert.That(sessions, Is.Empty);
        }

        [Test]
        public void AddNewSession_WithValidSession_AddsANewSessionWithCorrectParameters()
        {
            string sessionName = "SessionName";
            string maxParticipants = "5";
            long expectedSessionId = 10;
            long buddyId = 2;
            var mockRepository = new Mock<ISessionRepository>();
            mockRepository.Setup(repository => repository.GetFreeSessionId()).Returns(expectedSessionId);
            mockRepository.Setup(repository => repository.AddNewSession(sessionName, buddyId, 5)).Returns(expectedSessionId);

            var sessionService = new SessionService(mockRepository.Object);

            long actualSessionId = sessionService.AddNewSession(sessionName, maxParticipants);

            Assert.That(actualSessionId, Is.EqualTo(expectedSessionId));
        }

        [Test]
        public void AddNewSession_WithInvalidSessionName_ThrowsArgumentException()
        {
            string invalidSessionName = "A";
            string maximumNumberOfParticipants = "5";
            var mockRepository = new Mock<ISessionRepository>();
            var mockValidator = new Mock<IValidationForNewSession>();
            mockValidator.Setup(validator => validator.ValidateSessionName(invalidSessionName)).Throws<ArgumentException>();
            var sessionService = new SessionService(mockRepository.Object);

            Assert.Throws<ArgumentException>(() => sessionService.AddNewSession(invalidSessionName, maximumNumberOfParticipants));
        }

        [Test]
        public void AddNewSession_WithInvalidMaximumNumberOfParticipants_ThrowsArgumentOutOfRangeException()
        {
            string invalidMaximumNumberOfParticipants = "-1";
            var mockRepository = new Mock<ISessionRepository>();
            var mockValidator = new Mock<IValidationForNewSession>();
            mockValidator.Setup(validator => validator.ValidateMaxNumberOfBuddies(invalidMaximumNumberOfParticipants)).Throws<ArgumentOutOfRangeException>();
            var sessionService = new SessionService(mockRepository.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => sessionService.AddNewSession("ValidName", invalidMaximumNumberOfParticipants));
        }

        [Test]
        public void AddNewSession_WhenSessionAlreadyExists_ThrowsEntityAlreadyExistsException()
        {
            string sessionName = "ExistingSession";
            string maxParticipants = "5";
            long buddyId = 2;
            var mockRepository = new Mock<ISessionRepository>();
            var mockValidation = new Mock<IValidationForNewSession>();
            mockValidation.Setup(validator => validator.ValidateSessionId(It.IsAny<long>()));
            mockValidation.Setup(validator => validator.ValidateSessionName(sessionName));
            mockValidation.Setup(validator => validator.ValidateMaxNumberOfBuddies(maxParticipants));
            mockValidation.Setup(validator => validator.ValidateBuddyId(buddyId));
            mockRepository.Setup(repository => repository.AddNewSession(sessionName, buddyId, It.IsAny<int>())).Throws(new EntityAlreadyExists("Session already exists."));
            var sessionService = new SessionService(mockRepository.Object);

            Assert.Throws<EntityAlreadyExists>(() => sessionService.AddNewSession(sessionName, maxParticipants));
        }

        [Test]
        public void AddBuddyMemberToSession_WhenBuddyAlreadyInSession_ThrowsEntityAlreadyExistsException()
        {
            long buddyId = 1;
            long sessionId = 1;
            var mockRepository = new Mock<ISessionRepository>();
            mockRepository.Setup(repository => repository.AddBuddyMemberToSession(buddyId, sessionId))
                          .Throws(new EntityAlreadyExists("Buddy already in session."));
            var sessionService = new SessionService(mockRepository.Object);

            Assert.Throws<EntityAlreadyExists>(() => sessionService.AddBuddyMemberToSession(buddyId, sessionId));
        }

        [Test]
        public void AddBuddyMemberToSession_WhenBuddyNotInSession_AddsBuddyMember()
        {
            long buddyId = 1;
            long sessionId = 1;
            var session = new Session(sessionId, 1, "Name", new DateTime(2024, 4, 30), new DateTime(2024, 5, 1), new List<long>(), new List<IMessage>(), new List<ICodeContribution>(), new List<ICodeReviewSection>(), new List<string>(), new TextEditor("color", new List<string>()), new CodeBuddies.Models.Entities.DrawingBoard("filepath"));
            var mockRepository = new Mock<ISessionRepository>();
            var sessionService = new SessionService(mockRepository.Object);
            
            sessionService.AddBuddyMemberToSession(buddyId, sessionId);

            mockRepository.Verify(repository => repository.AddBuddyMemberToSession(buddyId, sessionId), Times.Once);
        }

        [Test]
        public void GetSessionName_WithValidSessionName_ReturnsSessionName()
        {
            long sessionId = 1;
            string expectedSessionName = "Session";
            var mockRepository = new Mock<ISessionRepository>();
            mockRepository.Setup(repo => repo.GetSessionName(sessionId)).Returns(expectedSessionName);
            var sessionService = new SessionService(mockRepository.Object);

            string sessionName = sessionService.GetSessionName(sessionId);

            Assert.That(sessionName, Is.EqualTo(expectedSessionName));
        }

        [Test]
        public void GetSessionName_WithSessionNotFound_ReturnsNull()
        {
            long sessionId = 1;
            var mockRepository = new Mock<ISessionRepository>();
            mockRepository.Setup(repo => repo.GetSessionName(sessionId)).Returns((string)null);
            var sessionService = new SessionService(mockRepository.Object);

            string sessionName = sessionService.GetSessionName(sessionId);

            Assert.IsNull(sessionName);
        }

        [Test]
        public void FilterSessionsBySessionName_WithSessionInName_ReturnsFilteredSessionsOfCurrentBuddy()
        {
            string sessionName = "Session";
            long currentBuddyId = 2;
            var sessions = new List<ISession>
            {
                new Session(1, 2, "Session1", DateTime.Now, DateTime.Now, new List<long>(), new List<IMessage>(), new List<ICodeContribution>(), new List<ICodeReviewSection>(), new List<string>(), new TextEditor("color", new List<string>()), new CodeBuddies.Models.Entities.DrawingBoard("filepath")),
                new Session(2, 2, "Session2", DateTime.Now, DateTime.Now, new List<long>(), new List<IMessage>(), new List<ICodeContribution>(), new List<ICodeReviewSection>(), new List<string>(), new TextEditor("color", new List<string>()), new CodeBuddies.Models.Entities.DrawingBoard("filepath")),
            };
            var mockSessionRepository = new Mock<ISessionRepository>();
            mockSessionRepository.Setup(repo => repo.GetAllSessionsOfABuddy(currentBuddyId)).Returns(sessions);
            var sessionService = new SessionService(mockSessionRepository.Object);

            var filteredSessions = sessionService.FilterSessionsBySessionName(sessionName);

            Assert.That(filteredSessions.All(session => session.Name.Contains(sessionName)), Is.True);
        }

        [Test]
        public void FilterSessionsBySessionName_WhenNoSessionsInRepository_ReturnsEmptyList()
        {
            string sessionName = "Session";
            long currentBuddyId = 2;
            var mockSessionRepository = new Mock<ISessionRepository>();
            mockSessionRepository.Setup(repo => repo.GetAllSessionsOfABuddy(currentBuddyId)).Returns(new List<ISession>());
            var sessionService = new SessionService(mockSessionRepository.Object);

            var sessionsOfCurrentBuddy = sessionService.FilterSessionsBySessionName(sessionName);

            Assert.That(sessionsOfCurrentBuddy, Is.Empty);
        }

        [Test]
        public void FilterSessionsBySessionName_WithEmptySessionName_ReturnsAllSessionsOfCurrentBuddy()
        {
            var sessionName = "";
            long currentBuddyId = 2;
            var mockSessionRepository = new Mock<ISessionRepository>();
            var sessions = new List<ISession>
            {
                new Mock<ISession>().SetupAllProperties().Object
            };
            sessions[0].Id = 1;
            sessions[0].OwnerId = 2;
            sessions[0].Name = "name";
            sessions[0].CreationDate = new DateTime(2024, 4, 30);
            sessions[0].LastEditDate = new DateTime(2024, 5, 1);
            sessions[0].Buddies = new List<long>();
            sessions[0].Messages = new List<IMessage>();
            sessions[0].CodeContributions = new List<ICodeContribution>();
            sessions[0].CodeReviewSections = new List<ICodeReviewSection>();
            sessions[0].FilePaths = new List<string>();
            sessions[0].TextEditor = new TextEditor("color", new List<string>());
            sessions[0].DrawingBoard = new CodeBuddies.Models.Entities.DrawingBoard("filepath");
            mockSessionRepository.Setup(repo => repo.GetAllSessionsOfABuddy(currentBuddyId)).Returns(sessions);
            var sessionService = new SessionService(mockSessionRepository.Object);

            var result = sessionService.FilterSessionsBySessionName(sessionName);

            CollectionAssert.AreEqual(sessions, result);
        }

        [Test]
        public void FilterSessionsBySessionName_WithWrongSessionName_ReturnsEmptyList()
        {
            var sessionName = "wrong";
            long currentBuddyId = 2;
            var mockSessionRepository = new Mock<ISessionRepository>();
            var sessions = new List<ISession>
            {
                new Mock<ISession>().SetupAllProperties().Object
            };
            sessions[0].Id = 1;
            sessions[0].OwnerId = 2;
            sessions[0].Name = "name";
            sessions[0].CreationDate = new DateTime(2024, 4, 30);
            sessions[0].LastEditDate = new DateTime(2024, 5, 1);
            sessions[0].Buddies = new List<long>();
            sessions[0].Messages = new List<IMessage>();
            sessions[0].CodeContributions = new List<ICodeContribution>();
            sessions[0].CodeReviewSections = new List<ICodeReviewSection>();
            sessions[0].FilePaths = new List<string>();
            sessions[0].TextEditor = new TextEditor("color", new List<string>());
            sessions[0].DrawingBoard = new CodeBuddies.Models.Entities.DrawingBoard("filepath");
            mockSessionRepository.Setup(repo => repo.GetAllSessionsOfABuddy(currentBuddyId)).Returns(sessions);
            var sessionService = new SessionService(mockSessionRepository.Object);

            var result = sessionService.FilterSessionsBySessionName(sessionName);

            Assert.That(result, Is.Empty);
        }
    }
}
