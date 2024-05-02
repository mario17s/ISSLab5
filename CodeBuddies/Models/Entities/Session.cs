using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public class Session : ISession
    {
        #region Fields
        private long id;
        private long ownerId;
        private string name;
        private DateTime creationDate;
        private DateTime lastEditDate;
        private List<long> buddies;
        private List<IMessage> messages;
        private List<ICodeContribution> codeContributions;
        private List<ICodeReviewSection> codeReviewSections;
        private List<string> filePaths;
        private ITextEditor textEditor;
        private IDrawingBoard drawingBoard;
        #endregion

        #region Properties
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public long OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        public DateTime LastEditDate
        {
            get { return lastEditDate; }
            set { lastEditDate = value; }
        }
        public List<long> Buddies
        {
            get { return buddies; }
            set { buddies = value; }
        }
        public List<IMessage> Messages
        {
            get { return messages; }
            set { messages = value; }
        }
        public List<ICodeContribution> CodeContributions
        {
            get { return codeContributions; }
            set { codeContributions = value; }
        }
        public List<ICodeReviewSection> CodeReviewSections
        {
            get { return codeReviewSections; }
            set { codeReviewSections = value; }
        }
        public List<string> FilePaths
        {
            get { return filePaths; }
            set { filePaths = value; }
        }
        public ITextEditor TextEditor
        {
            get { return textEditor; }
            set { textEditor = value; }
        }
        public IDrawingBoard DrawingBoard
        {
            get { return drawingBoard; }
            set { drawingBoard = value; }
        }
        #endregion

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

        #region Methods

        /// <summary>
        /// Add buddy to the session
        /// </summary>
        /// <param name="buddyId"></param>
        public void AddBuddy(long buddyId)
        {
            // Add buddy to the session
            return;
        }

        /// <summary>
        /// Remove buddy from the session
        /// </summary>
        /// <param name="buddyId"></param>
        public void RemoveBuddy(long buddyId)
        {
            // Remove buddy from the session
            return;
        }

        /// <summary>
        /// Leave the session
        /// </summary>
        /// <param name="buddyId"></param>
        public void LeaveSession(long buddyId)
        {
            // Leave the session
            return;
        }

        /// <summary>
        /// Upload file to the session
        /// </summary>
        /// <param name="filePath"></param>
        public void UploadFile(string filePath)
        {
            FilePaths.Add(filePath);
        }

        /// <summary>
        /// Add code contribution
        /// </summary>
        /// <param name="buddyId"></param>
        /// <param name="date"></param>
        /// <param name="contributionValue"></param>
        public void AddCodeContribution(int buddyId, DateTime date, int contributionValue)
        {
            // Add code contribution
            return;
        }

        /// <summary>
        /// Post message to the session
        /// </summary>
        /// <param name="message"></param>
        public void PostMessage(IMessage message)
        {
            Messages.Add(message);
        }

        /// <summary>
        /// Post code review section
        /// </summary>
        /// <param name="codeReviewSection"></param>
        public void PostCodeReviewSection(ICodeReviewSection codeReviewSection)
        {
            CodeReviewSections.Add(codeReviewSection);
        }

        /// <summary>
        /// Post message to code review section
        /// </summary>
        /// <param name="codeReviewSectionId"></param>
        /// <param name="message"></param>
        public void PostCodeReviewSectionMessage(long codeReviewSectionId, IMessage message)
        {
            // Post message to code review section
            return;
        }
        #endregion
    }
}