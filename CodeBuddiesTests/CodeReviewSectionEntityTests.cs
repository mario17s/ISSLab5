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
    public class CodeReviewSectionEntityTests
    {
        private Mock<ICodeReviewSection> codeReviewSectionMock;

        [SetUp]
        public void Setup()
        {
            codeReviewSectionMock = new Mock<ICodeReviewSection>();
        }

        [Test]
        public void CodeReviewSection_GetId_ShouldReturnTheId()
        {
            long expectedId = 1;
            codeReviewSectionMock.Setup(section => section.Id).Returns(expectedId);

            long actualId = codeReviewSectionMock.Object.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void CodeReviewSection_SetId_ShouldSetTheId()
        {
            long expectedId = 1;
            codeReviewSectionMock.SetupSet(section => section.Id = expectedId);

            codeReviewSectionMock.Object.Id = expectedId;

            codeReviewSectionMock.VerifySet(section => section.Id = expectedId, Times.Once());
        }

        [Test]
        public void CodeReviewSection_GetOwnerId_ShouldReturnTheOwnerId()
        {
            long expectedOwnerId = 1;
            codeReviewSectionMock.Setup(section => section.OwnerId).Returns(expectedOwnerId);

            long actualOwnerId = codeReviewSectionMock.Object.OwnerId;

            Assert.AreEqual(expectedOwnerId, actualOwnerId);
        }

        [Test]
        public void CodeReviewSection_SetOwnerId_ShouldSetTheOwnerId()
        {
            long expectedOwnerId = 1;
            codeReviewSectionMock.SetupSet(section => section.OwnerId = expectedOwnerId);

            codeReviewSectionMock.Object.OwnerId = expectedOwnerId;

            codeReviewSectionMock.VerifySet(section => section.OwnerId = expectedOwnerId, Times.Once());
        }

        [Test]
        public void CodeReviewSection_GetMessages_ShouldReturnTheMessages()
        {
            List<IMessage> expectedMessages = new List<IMessage>();
            codeReviewSectionMock.Setup(section => section.Messages).Returns(expectedMessages);

            List<IMessage> actualMessages = codeReviewSectionMock.Object.Messages;

            Assert.AreEqual(expectedMessages, actualMessages);
        }

        [Test]
        public void CodeReviewSection_SetMessages_ShouldSetTheMessages()
        {
            List<IMessage> expectedMessages = new List<IMessage>();
            codeReviewSectionMock.SetupSet(section => section.Messages = expectedMessages);

            codeReviewSectionMock.Object.Messages = expectedMessages;

            codeReviewSectionMock.VerifySet(section => section.Messages = expectedMessages, Times.Once());
        }

        [Test]
        public void CodeReviewSection_GetCodeSection_ShouldReturnTheCodeSection()
        {
            string expectedCodeSection = "public void Main()";
            codeReviewSectionMock.Setup(section => section.CodeSection).Returns(expectedCodeSection);

            string actualCodeSection = codeReviewSectionMock.Object.CodeSection;

            Assert.AreEqual(expectedCodeSection, actualCodeSection);
        }

        [Test]
        public void CodeReviewSection_SetCodeSection_ShouldSetTheCodeSection()
        {
            string expectedCodeSection = "public void Main()";
            codeReviewSectionMock.SetupSet(section => section.CodeSection = expectedCodeSection);

            codeReviewSectionMock.Object.CodeSection = expectedCodeSection;

            codeReviewSectionMock.VerifySet(section => section.CodeSection = expectedCodeSection, Times.Once());
        }

        [Test]
        public void CodeReviewSection_GetIsClosed_ShouldReturnTheIsClosed()
        {
            bool expectedIsClosed = false;
            codeReviewSectionMock.Setup(section => section.IsClosed).Returns(expectedIsClosed);

            bool actualIsClosed = codeReviewSectionMock.Object.IsClosed;

            Assert.AreEqual(expectedIsClosed, actualIsClosed);
        }

        [Test]
        public void CodeReviewSection_SetIsClosed_ShouldSetTheIsClosed()
        {
            bool expectedIsClosed = false;
            codeReviewSectionMock.SetupSet(section => section.IsClosed = expectedIsClosed);

            codeReviewSectionMock.Object.IsClosed = expectedIsClosed;

            codeReviewSectionMock.VerifySet(section => section.IsClosed = expectedIsClosed, Times.Once());
        }
    }
}
