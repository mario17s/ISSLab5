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
            // Arrange
            string expectedMessage = "Entity already exists.";

            // Act
            EntityAlreadyExists exception = new EntityAlreadyExists(expectedMessage);

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }


        [Test]
        public void Constructor_WithInnerException_SetsInnerExceptionCorrectly()
        {
            // Arrange
            string expectedMessage = "Entity already exists.";
            var innerExceptionMock = new Mock<Exception>();
            Exception innerException = innerExceptionMock.Object;

            // Act
            EntityAlreadyExists exception = new EntityAlreadyExists(expectedMessage, innerException);

            // Assert
            Assert.That(exception.InnerException, Is.EqualTo(innerException));
        }
    }

    public class FileNotFoundTests
    {
        [Test]
        public void Constructor_WithMessage_SetsMessageCorrectly()
        {
            // Arrange
            string expectedMessage = "File not found.";

            // Act
            FileNotFound exception = new FileNotFound(expectedMessage);

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }


        [Test]
        public void Constructor_WithInnerException_SetsInnerExceptionCorrectly()
        {
            // Arrange
            string expectedMessage = "File not found.";
            var innerExceptionMock = new Mock<Exception>();
            Exception innerException = innerExceptionMock.Object;

            // Act
            FileNotFound exception = new FileNotFound(expectedMessage, innerException);

            // Assert
            Assert.That(exception.InnerException, Is.EqualTo(innerException));
        }
    }

    public class NullColumnTests
    {
        [Test]
        public void Constructor_WithMessage_SetsMessageCorrectly()
        {
            // Arrange
            string expectedMessage = "Null column.";

            // Act
            NullColumn exception = new NullColumn(expectedMessage);

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }


        [Test]
        public void Constructor_WithInnerException_SetsInnerExceptionCorrectly()
        {
            // Arrange
            string expectedMessage = "Null column.";
            var innerExceptionMock = new Mock<Exception>();
            Exception innerException = innerExceptionMock.Object;

            // Act
            NullColumn exception = new NullColumn(expectedMessage, innerException);

            // Assert
            Assert.That(exception.InnerException, Is.EqualTo(innerException));
        }
    }
}
