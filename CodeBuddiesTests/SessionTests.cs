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
    public class SessionTests
    {
        [Test]
        public void Session_GetId_ReturnsCorrectValue()
        {
            long expectedId = 123;
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.Id).Returns(expectedId);

            long id = sessionMock.Object.Id;
            
            Assert.AreEqual(expectedId, id);
        }

        [Test]
        public void Session_SetId_SetsCorrectValue()
        {
           
            long newId = 456;
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.Id);

            sessionMock.Object.Id = newId;

            Assert.AreEqual(newId, sessionMock.Object.Id);
        }

        
        [Test]
        public void Session_GetTextEditor_ReturnsCorrectValue()
        {
            
            var textEditorMock = new Mock<ITextEditor>();
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.TextEditor).Returns(textEditorMock.Object);

            var textEditor = sessionMock.Object.TextEditor;

           
            Assert.AreEqual(textEditorMock.Object, textEditor);
        }

        [Test]
        public void Session_SetTextEditor_SetsCorrectValue()
        {
          
            var newTextEditorMock = new Mock<ITextEditor>();
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.TextEditor);

           
            sessionMock.Object.TextEditor = newTextEditorMock.Object;

          
            Assert.AreEqual(newTextEditorMock.Object, sessionMock.Object.TextEditor);
        }

        [Test]
        public void Session_GetDrawingBoard_ReturnsCorrectValue()
        {
           
            var drawingBoardMock = new Mock<IDrawingBoard>();
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.DrawingBoard).Returns(drawingBoardMock.Object);

            
            var drawingBoard = sessionMock.Object.DrawingBoard;

           
            Assert.AreEqual(drawingBoardMock.Object, drawingBoard);
        }

        [Test]
        public void Session_SetDrawingBoard_SetsCorrectValue()
        {
           
            var newDrawingBoardMock = new Mock<IDrawingBoard>();
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.DrawingBoard);

           
            sessionMock.Object.DrawingBoard = newDrawingBoardMock.Object;

            
            Assert.AreEqual(newDrawingBoardMock.Object, sessionMock.Object.DrawingBoard);
        }

        [Test]
        public void Session_GetOwnerId_ReturnsCorrectValue()
        {
           
            long expectedOwnerId = 123;
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.OwnerId).Returns(expectedOwnerId);

            
            long ownerId = sessionMock.Object.OwnerId;

            Assert.AreEqual(expectedOwnerId, ownerId);
        }

        [Test]
        public void Session_SetOwnerId_SetsCorrectValue()
        {
          
            long newOwnerId = 456;
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.OwnerId);

           
            sessionMock.Object.OwnerId = newOwnerId;

          
            Assert.AreEqual(newOwnerId, sessionMock.Object.OwnerId);
        }

        [Test]
        public void Session_GetName_ReturnsCorrectValue()
        {
            
            string expectedName = "Test Session";
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.Name).Returns(expectedName);

           
            string name = sessionMock.Object.Name;

          
            Assert.AreEqual(expectedName, name);
        }

        [Test]
        public void Session_SetName_SetsCorrectValue()
        {
         
            string newName = "New Session";
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.Name);

         
            sessionMock.Object.Name = newName;

            Assert.AreEqual(newName, sessionMock.Object.Name);
        }

        [Test]
        public void Session_GetCreationDate_ReturnsCorrectValue()
        {
         
            DateTime expectedCreationDate = DateTime.Now;
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.CreationDate).Returns(expectedCreationDate);

            
            DateTime creationDate = sessionMock.Object.CreationDate;

          
            Assert.AreEqual(expectedCreationDate, creationDate);
        }

        [Test]
        public void Session_SetCreationDate_SetsCorrectValue()
        {
         
            DateTime newCreationDate = DateTime.Now.AddDays(-1);
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.CreationDate);

            sessionMock.Object.CreationDate = newCreationDate;

            
            Assert.AreEqual(newCreationDate, sessionMock.Object.CreationDate);
        }

        [Test]
        public void Session_GetLastEditDate_ReturnsCorrectValue()
        {
            DateTime expectedLastEditDate = DateTime.Now;
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.LastEditDate).Returns(expectedLastEditDate);

            DateTime lastEditDate = sessionMock.Object.LastEditDate;

            
            Assert.AreEqual(expectedLastEditDate, lastEditDate);
        }

        [Test]
        public void Session_SetLastEditDate_SetsCorrectValue()
        {
           
            DateTime newLastEditDate = DateTime.Now.AddDays(-1);
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.LastEditDate);

            
            sessionMock.Object.LastEditDate = newLastEditDate;

           
            Assert.AreEqual(newLastEditDate, sessionMock.Object.LastEditDate);
        }

        [Test]
        public void Session_GetBuddies_ReturnsCorrectValue()
        {
            
            List<long> expectedBuddies = new List<long> { 123, 456, 789 };
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.Buddies).Returns(expectedBuddies);

            List<long> buddies = sessionMock.Object.Buddies;

            
            Assert.AreEqual(expectedBuddies, buddies);
        }

        [Test]
        public void Session_SetBuddies_SetsCorrectValue()
        {
           
            List<long> newBuddies = new List<long> { 111, 222, 333 };
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.Buddies);

            sessionMock.Object.Buddies = newBuddies;

            Assert.AreEqual(newBuddies, sessionMock.Object.Buddies);
        }

        [Test]
        public void Session_GetMessages_ReturnsCorrectValue()
        {
           
            var expectedMessages = new List<IMessage> { new Mock<IMessage>().Object, new Mock<IMessage>().Object };
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.Messages).Returns(expectedMessages);

            var messages = sessionMock.Object.Messages;

            Assert.AreEqual(expectedMessages, messages);
        }

        [Test]
        public void Session_SetMessages_SetsCorrectValue()
        {
           
            var newMessages = new List<IMessage> { new Mock<IMessage>().Object, new Mock<IMessage>().Object };
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.Messages);

            sessionMock.Object.Messages = newMessages;

            Assert.AreEqual(newMessages, sessionMock.Object.Messages);
        }

        [Test]
        public void Session_GetCodeContributions_ReturnsCorrectValue()
        {
            
            var expectedCodeContributions = new List<ICodeContribution> { new Mock<ICodeContribution>().Object, new Mock<ICodeContribution>().Object };
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.CodeContributions).Returns(expectedCodeContributions);

          
            var codeContributions = sessionMock.Object.CodeContributions;

            
            Assert.AreEqual(expectedCodeContributions, codeContributions);
        }

        [Test]
        public void Session_SetCodeContributions_SetsCorrectValue()
        {
        
            var newCodeContributions = new List<ICodeContribution> { new Mock<ICodeContribution>().Object, new Mock<ICodeContribution>().Object };
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.CodeContributions);

            sessionMock.Object.CodeContributions = newCodeContributions;

           
            Assert.AreEqual(newCodeContributions, sessionMock.Object.CodeContributions);
        }

        [Test]
        public void Session_GetCodeReviewSections_ReturnsCorrectValue()
        {
         
            var expectedCodeReviewSections = new List<ICodeReviewSection> { new Mock<ICodeReviewSection>().Object, new Mock<ICodeReviewSection>().Object };
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.CodeReviewSections).Returns(expectedCodeReviewSections);

          
            var codeReviewSections = sessionMock.Object.CodeReviewSections;

          
            Assert.AreEqual(expectedCodeReviewSections, codeReviewSections);
        }

        [Test]
        public void Session_SetCodeReviewSections_SetsCorrectValue()
        {
         
            var newCodeReviewSections = new List<ICodeReviewSection> { new Mock<ICodeReviewSection>().Object, new Mock<ICodeReviewSection>().Object };
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.CodeReviewSections);

            sessionMock.Object.CodeReviewSections = newCodeReviewSections;

        
            Assert.AreEqual(newCodeReviewSections, sessionMock.Object.CodeReviewSections);
        }

        [Test]
        public void Session_GetFilePaths_ReturnsCorrectValue()
        {
          
            var expectedFilePaths = new List<string> { "path1", "path2", "path3" };
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupGet(s => s.FilePaths).Returns(expectedFilePaths);

            var filePaths = sessionMock.Object.FilePaths;

           
            Assert.AreEqual(expectedFilePaths, filePaths);
        }

        [Test]
        public void Session_SetFilePaths_SetsCorrectValue()
        {
        
            var newFilePaths = new List<string> { "newPath1", "newPath2", "newPath3" };
            var sessionMock = new Mock<ISession>();
            sessionMock.SetupProperty(s => s.FilePaths);

          
            sessionMock.Object.FilePaths = newFilePaths;

       
            Assert.AreEqual(newFilePaths, sessionMock.Object.FilePaths);
        }

    }
}
