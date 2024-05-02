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
    public class MessageTests
    {
        [Test]
        public void Message_GetMessageId_ReturnsCorrectValue()
        {
         
            long expectedMessageId = 123;
            var messageMock = new Mock<IMessage>();
            messageMock.SetupGet(m => m.MessageId).Returns(expectedMessageId);

           
            long messageId = messageMock.Object.MessageId;

            Assert.AreEqual(expectedMessageId, messageId);
        }

        [Test]
        public void Message_SetMessageId_SetsCorrectValue()
        {
            
            long newMessageId = 456;
            var messageMock = new Mock<IMessage>();
            messageMock.SetupProperty(m => m.MessageId);

            messageMock.Object.MessageId = newMessageId;

            
            Assert.AreEqual(newMessageId, messageMock.Object.MessageId);
        }

        [Test]
        public void Message_GetTimeStamp_ReturnsCorrectValue()
        {
            
            DateTime expectedTimeStamp = DateTime.Now;
            var messageMock = new Mock<IMessage>();
            messageMock.SetupGet(m => m.TimeStamp).Returns(expectedTimeStamp);

           
            DateTime timeStamp = messageMock.Object.TimeStamp;
            Assert.AreEqual(expectedTimeStamp, timeStamp);
        }

        [Test]
        public void Message_SetTimeStamp_SetsCorrectValue()
        {
        
            DateTime newTimeStamp = DateTime.Now.AddDays(-1);
            var messageMock = new Mock<IMessage>();
            messageMock.SetupProperty(m => m.TimeStamp);

            messageMock.Object.TimeStamp = newTimeStamp;

            Assert.AreEqual(newTimeStamp, messageMock.Object.TimeStamp);
        }

        [Test]
        public void Message_GetContent_ReturnsCorrectValue()
        {
       
            string expectedContent = "Test message";
            var messageMock = new Mock<IMessage>();
            messageMock.SetupGet(m => m.Content).Returns(expectedContent);

            string content = messageMock.Object.Content;

            Assert.AreEqual(expectedContent, content);
        }

        [Test]
        public void Message_SetContent_SetsCorrectValue()
        {
           
            string newContent = "New test message";
            var messageMock = new Mock<IMessage>();
            messageMock.SetupProperty(m => m.Content);

            messageMock.Object.Content = newContent;

          
            Assert.AreEqual(newContent, messageMock.Object.Content);
        }

        [Test]
        public void Message_GetSenderId_ReturnsCorrectValue()
        {
         
            long expectedSenderId = 456;
            var messageMock = new Mock<IMessage>();
            messageMock.SetupGet(m => m.SenderId).Returns(expectedSenderId);

            long senderId = messageMock.Object.SenderId;

            Assert.AreEqual(expectedSenderId, senderId);
        }

        [Test]
        public void Message_SetSenderId_SetsCorrectValue()
        {
            long newSenderId = 789;
            var messageMock = new Mock<IMessage>();
            messageMock.SetupProperty(m => m.SenderId);

            messageMock.Object.SenderId = newSenderId;

            Assert.AreEqual(newSenderId, messageMock.Object.SenderId);
        }
    }
}
