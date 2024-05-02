using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public abstract class Notification : INotification
    {
        #region Fields
        protected long notificationId;
        protected DateTime timeStamp;
        protected string type;
        protected string status;
        protected string description;
        protected long senderId;
        protected long receiverId;
        protected long sessionId;
        #endregion

        #region
        public long NotificationId
        {
            get { return notificationId; }
            set { notificationId = value; }
        }
        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public long SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }
        public long ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }
        public long SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
        #endregion

        #region Constructors
        public Notification(long notificationId, DateTime timeStamp, string type, string status, string description, long senderId, long receiverId, long sessionId)
        {
            NotificationId = notificationId;
            TimeStamp = timeStamp;
            Type = type;
            Status = status;
            Description = description;
            SenderId = senderId;
            ReceiverId = receiverId;
            SessionId = sessionId;
        }

        public Notification()
        {
        }
        #endregion

        protected abstract void MarkNotification();
    }
}