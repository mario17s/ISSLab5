using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public class CodeReviewSection : ICodeReviewSection
    {
        #region Fields
        private long id;
        private long ownerId;
        private List<IMessage> messages;
        private string codeSection;
        private bool isClosed;
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
        public List<IMessage> Messages
        {
            get { return messages; }
            set { messages = value; }
        }
        public string CodeSection
        {
            get { return codeSection; }
            set { codeSection = value; }
        }
        public bool IsClosed
        {
            get { return isClosed; }
            set { isClosed = value; }
        }
        #endregion

        public CodeReviewSection(long codeReviewSectionId, long ownerId, List<IMessage> message, string codeSection, bool isClosed)
        {
            Id = codeReviewSectionId;
            OwnerId = ownerId;
            Messages = message;
            CodeSection = codeSection;
            IsClosed = isClosed;
        }
    }
}
