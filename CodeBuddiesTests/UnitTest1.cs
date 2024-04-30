using CodeBuddies.Models.Entities;

namespace CodeBuddiesTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Buddy buddy = new Buddy(1, "Buddy", "asdad", "Yo", null);

            Assert.AreEqual(1, buddy.Id);
        }
    }
}