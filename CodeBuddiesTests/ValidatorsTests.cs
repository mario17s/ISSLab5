using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CodeBuddies.Models.Validators;

namespace CodeBuddiesTests
{
    [TestFixture]
    internal class ValidatorsTests
    {

        [Test]
        public void ValidateSessionName_ValidSessionName_NoExceptionThrown()
        { 
            string validSessionName = "ValidSessionName";
            var validatorMock = new Mock<IValidationForNewSession>();
            validatorMock.Setup(x => x.ValidateSessionName(validSessionName));

            Assert.DoesNotThrow(() => validatorMock.Object.ValidateSessionName(validSessionName));
        }

        [Test]
        public void ValidateSessionName_InvalidSessionName_ThrowsArgumentException()
        {
            string invalidSessionName = "Sh";
            var validatorMock = new Mock<IValidationForNewSession>();
            validatorMock.Setup(x => x.ValidateSessionName(invalidSessionName)).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => validatorMock.Object.ValidateSessionName(invalidSessionName));
        }

        [Test]
        public void ValidateMaxNoOfBuddies_ValidValue_NoExceptionThrown()
        {
            string validMaxNoOfBuddies = "5";
            var validatorMock = new Mock<IValidationForNewSession>();
            validatorMock.Setup(x => x.ValidateMaxNumberOfBuddies(validMaxNoOfBuddies));

            Assert.DoesNotThrow(() => validatorMock.Object.ValidateMaxNumberOfBuddies(validMaxNoOfBuddies));
        }

        [Test]
        public void ValidateMaxNoOfBuddies_InvalidValue_ThrowsArgumentException()
        {
            string invalidMaxNoOfBuddies = "invalid";
            var validatorMock = new Mock<IValidationForNewSession>();
            validatorMock.Setup(x => x.ValidateMaxNumberOfBuddies(invalidMaxNoOfBuddies)).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => validatorMock.Object.ValidateMaxNumberOfBuddies(invalidMaxNoOfBuddies));
        }

        [Test]
        public void ValidateMaxNoOfBuddies_OutOfRange_ThrowsArgumentOutOfRangeException()
        {
            string outOfRangeMaxNoOfBuddies = "100";
            var validatorMock = new Mock<IValidationForNewSession>();
            validatorMock.Setup(x => x.ValidateMaxNumberOfBuddies(outOfRangeMaxNoOfBuddies)).Throws<ArgumentOutOfRangeException>();

            Assert.Throws<ArgumentOutOfRangeException>(() => validatorMock.Object.ValidateMaxNumberOfBuddies(outOfRangeMaxNoOfBuddies));
        }

        [Test]
        public void ValidateBuddyId_NegativeBuddyId_ThrowsArgumentOutOfRangeException()
        {
            long negativeBuddyId = -1;
            var validatorMock = new Mock<IValidationForNewSession>();
            validatorMock.Setup(x => x.ValidateBuddyId(negativeBuddyId)).Throws<ArgumentOutOfRangeException>();

            Assert.Throws<ArgumentOutOfRangeException>(() => validatorMock.Object.ValidateBuddyId(negativeBuddyId));
        }

        [Test]
        public void ValidateSessionId_NegativeSessionId_ThrowsArgumentOutOfRangeException()
        {
            long negativeSessionId = -1;
            var validatorMock = new Mock<IValidationForNewSession>();
            validatorMock.Setup(x => x.ValidateSessionId(negativeSessionId)).Throws<ArgumentOutOfRangeException>();

            Assert.Throws<ArgumentOutOfRangeException>(() => validatorMock.Object.ValidateSessionId(negativeSessionId));
        }
    }
}