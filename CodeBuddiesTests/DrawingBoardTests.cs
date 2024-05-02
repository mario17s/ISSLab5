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
    public class DrawingBoardTests
    {
        [Test]
        public void DrawingBoard_SetFilePath_ShouldSetFilePathCorrectly()
        {
            string expectedFilePath = "exampleFilePath";
            var mockDrawingBoard = new Mock<IDrawingBoard>();
            mockDrawingBoard.Object.FilePath = expectedFilePath;
            mockDrawingBoard.VerifySet(board => board.FilePath = expectedFilePath, Times.Once);
        }

        [Test]
        public void DrawingBoard_GetFilePath_ShouldReturnCorrectFilePath()
        {
            string expectedFilePath = "exampleFilePath";
            var mockDrawingBoard = new Mock<IDrawingBoard>();
            mockDrawingBoard.SetupGet(board => board.FilePath).Returns(expectedFilePath);
            string actualFilePath = mockDrawingBoard.Object.FilePath;
            Assert.AreEqual(expectedFilePath, actualFilePath);
        }
    }
}
