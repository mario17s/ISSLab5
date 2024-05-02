using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    public class InviteNotification : Notification
    {
        #region Fields
        private bool isAccepted;
        #endregion

        #region Properties
        public bool IsAccepted
        {
            get { return isAccepted; }
            set { isAccepted = value; }
        }
        #endregion

        #region Constructors
        public InviteNotification(long notificationId, DateTime timeStamp, string type, string status, string description, long senderId, long receiverId, long sessionId, bool isAccepted) : base(notificationId, timeStamp, type, status, description, senderId, receiverId, sessionId)
        {
            IsAccepted = isAccepted;
        }

        public InviteNotification()
        {
        }
        #endregion

        #region Methods

        /// <summary>
        /// Mark the notification as declined/accepted
        /// </summary>
        protected override void MarkNotification()
        {
            // mark as declined/accepted
        }
        #endregion
    }
}
