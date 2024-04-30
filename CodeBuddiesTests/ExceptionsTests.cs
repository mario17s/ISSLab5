using CodeBuddies.Models.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddiesTests
{
    [TestFixture]
    public class ExceptionsTests
    {
        [Test]
        public void Constructor_WithMessage_SetsMessageCorrectly()
        {
            string expectedMessage = "Entity already exists.";

            EntityAlreadyExists exception = new EntityAlreadyExists(expectedMessage);

            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }


        [Test]
        public void Constructor_WithInnerException_SetsInnerExceptionCorrectly()
        {
            string expectedMessage = "Entity already exists.";
            var innerExceptionMock = new Mock<Exception>();
            Exception innerException = innerExceptionMock.Object;

            EntityAlreadyExists exception = new EntityAlreadyExists(expectedMessage, innerException);

            Assert.That(exception.InnerException, Is.EqualTo(innerException));
        }
    }

    public class FileNotFoundTests
    {
        [Test]
        public void Constructor_WithMessage_SetsMessageCorrectly()
        {
            string expectedMessage = "File not found.";

            FileNotFound exception = new FileNotFound(expectedMessage);

            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }


        [Test]
        public void Constructor_WithInnerException_SetsInnerExceptionCorrectly()
        {
            string expectedMessage = "File not found.";
            var innerExceptionMock = new Mock<Exception>();
            Exception innerException = innerExceptionMock.Object;

            FileNotFound exception = new FileNotFound(expectedMessage, innerException);

            Assert.That(exception.InnerException, Is.EqualTo(innerException));
        }
    }

    public class NullColumnTests
    {
        [Test]
        public void Constructor_WithMessage_SetsMessageCorrectly()
        {
            string expectedMessage = "Null column.";

            NullColumn exception = new NullColumn(expectedMessage);

            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }


        [Test]
        public void Constructor_WithInnerException_SetsInnerExceptionCorrectly()
        {
            string expectedMessage = "Null column.";
            var innerExceptionMock = new Mock<Exception>();
            Exception innerException = innerExceptionMock.Object;

            NullColumn exception = new NullColumn(expectedMessage, innerException);

            Assert.That(exception.InnerException, Is.EqualTo(innerException));
        }
    }
}
