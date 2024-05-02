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
    public class CodeContributionEntityTests
    {
        private Mock<ICodeContribution> codeContributionMock;

        [SetUp]
        public void Setup()
        {
            codeContributionMock = new Mock<ICodeContribution>();
        }

        [Test]
        public void CodeContribution_GetContributor_ShouldReturnTheContributor()
        {
            long expectedContributor = 1;
            codeContributionMock.Setup(contribution => contribution.Contributor).Returns(expectedContributor);

            long actualContributor = codeContributionMock.Object.Contributor;

            Assert.AreEqual(expectedContributor, actualContributor);
        }

        [Test]
        public void CodeContribution_SetContributor_ShouldSetTheContributor()
        {
            long expectedContributor = 1;
            codeContributionMock.SetupSet(contribution => contribution.Contributor = expectedContributor);

            codeContributionMock.Object.Contributor = expectedContributor;

            codeContributionMock.VerifySet(contribution => contribution.Contributor = expectedContributor, Times.Once());
        }

        [Test]
        public void CodeContribution_GetContributionDate_ShouldReturnTheContributionDate()
        {
            DateTime expectedContributionDate = DateTime.Now;
            codeContributionMock.Setup(contribution => contribution.ContributionDate).Returns(expectedContributionDate);

            DateTime actualContributionDate = codeContributionMock.Object.ContributionDate;

            Assert.AreEqual(expectedContributionDate, actualContributionDate);
        }

        [Test]
        public void CodeContribution_SetContributionDate_ShouldSetTheContributionDate()
        {
            DateTime expectedContributionDate = DateTime.Now;
            codeContributionMock.SetupSet(contribution => contribution.ContributionDate = expectedContributionDate);

            codeContributionMock.Object.ContributionDate = expectedContributionDate;

            codeContributionMock.VerifySet(contribution => contribution.ContributionDate = expectedContributionDate, Times.Once());
        }

        [Test]
        public void CodeContribution_GetContributionValue_ShouldReturnTheContributionValue()
        {
            int expectedContributionValue = 5;
            codeContributionMock.Setup(contribution => contribution.ContributionValue).Returns(expectedContributionValue);

            int actualContributionValue = codeContributionMock.Object.ContributionValue;

            Assert.AreEqual(expectedContributionValue, actualContributionValue);
        }

        [Test]
        public void CodeContribution_SetContributionValue_ShouldSetTheContributionValue()
        {
            int expectedContributionValue = 5;
            codeContributionMock.SetupSet(contribution => contribution.ContributionValue = expectedContributionValue);

            codeContributionMock.Object.ContributionValue = expectedContributionValue;

            codeContributionMock.VerifySet(contribution => contribution.ContributionValue = expectedContributionValue, Times.Once());
        }
    }
}
