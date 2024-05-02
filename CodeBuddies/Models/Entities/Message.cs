using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public class Message : IMessage
    {
        #region Fields
        private long messageId;
        private DateTime timeStamp;
        private string content = string.Empty;
        private long senderId;
        #endregion

        #region Prperties
        public long MessageId
        {
            get { return messageId; }
            set { messageId = value; }
        }
        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public long SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }
        #endregion

        public Message(long messageId, DateTime timeStamp, string messageContent, long senderId)
        {
            MessageId = messageId;
            TimeStamp = timeStamp;
            Content = messageContent;
            SenderId = senderId;
        }
    }
}