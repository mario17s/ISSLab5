using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    public class Session : ISession
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long ownerId;

        public long OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime creationDate;

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        private DateTime lastEditDate;

        public DateTime LastEditDate
        {
            get { return lastEditDate; }
            set { lastEditDate = value; }
        }

        private List<long> buddies;

        public List<long> Buddies
        {
            get { return buddies; }
            set { buddies = value; }
        }

        private List<IMessage> messages;

        public List<IMessage> Messages
        {
            get { return messages; }
            set { messages = value; }
        }

        private List<ICodeContribution> codeContributions;

        public List<ICodeContribution> CodeContributions
        {
            get { return codeContributions; }
            set { codeContributions = value; }
        }

        private List<ICodeReviewSection> codeReviewSections;

        public List<ICodeReviewSection> CodeReviewSections
        {
            get { return codeReviewSections; }
            set { codeReviewSections = value; }
        }

        private List<string> filePaths;

        public List<string> FilePaths
        {
            get { return filePaths; }
            set { filePaths = value; }
        }

        private ITextEditor textEditor;

        public ITextEditor TextEditor
        {
            get { return textEditor; }
            set { textEditor = value; }
        }

        private IDrawingBoard drawingBoard;

        public IDrawingBoard DrawingBoard
        {
            get { return drawingBoard; }
            set { drawingBoard = value; }
        }

        public Session(long sessionId, long ownerId, string name, DateTime creationDate, DateTime lastEditedDate, List<long> buddies, List<IMessage> messages, List<ICodeContribution> codeContributions, List<ICodeReviewSection> codeReviewSections, List<string> filePaths, ITextEditor textEditor, IDrawingBoard drawingBoard)
        {
            Id = sessionId;
            OwnerId = ownerId;
            Name = name;
            CreationDate = creationDate;
            LastEditDate = lastEditedDate;
            Buddies = buddies;
            Messages = messages;
            CodeContributions = codeContributions;
            CodeReviewSections = codeReviewSections;
            FilePaths = filePaths;
            TextEditor = textEditor;
            DrawingBoard = drawingBoard;
        }

        public void AddBuddy(long buddyId)
        {
            // Add buddy to the session
            return;
        }

        public void RemoveBuddy(long buddyId)
        {
            // Remove buddy from the session
            return;
        }

        public void LeaveSession(long buddyId)
        {
            // Leave the session
            return;
        }

        public void UploadFile(string filePath)
        {
            FilePaths.Add(filePath);
        }

        public void addCodeContribution(int buddyId, DateTime date, int contributionValue)
        {
            // Add code contribution
            return;
        }

        public void PostMessage(IMessage message)
        {
            Messages.Add(message);
        }

        public void PostCodeReviewSection(ICodeReviewSection codeReviewSection)
        {
            CodeReviewSections.Add(codeReviewSection);
        }

        public void PostCodeReviewSectionMessage(long codeReviewSectionId, IMessage message)
        {
            // Post message to code review section
            return;
        }


    }
}
