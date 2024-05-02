using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public class Buddy : IBuddy
    {
        #region Fields
        private long id;
        private string buddyName;
        private string profilePhotoUrl;
        private string status;
        private List<Notification> notifications;
        #endregion

        #region Properties
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string BuddyName
        {
            get { return buddyName; }
            set { buddyName = value; }
        }
        public string ProfilePhotoUrl
        {
            get { return profilePhotoUrl; }
            set { profilePhotoUrl = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public List<Notification> Notifications
        {
            get { return notifications; }
            set { notifications = value; }
        }
        #endregion

        public Buddy(long buddyId, string buddyName, string profilePhotoUrl, string status, List<Notification> notifications)
        {
            Id = buddyId;
            BuddyName = buddyName;
            ProfilePhotoUrl = profilePhotoUrl;
            Status = status;
            Notifications = notifications;
        }

        #region Methods

        /// <summary>
        /// Create a new session
        /// </summary>
        /// <param name="sessionName"></param>
        public void CreateNewSession(string sessionName)
        {
            // create a new session
        }

        /// <summary>
        /// Accept invite
        /// </summary>
        public void AcceptInvite()
        {
            // accept invite
        }

        /// <summary>
        /// Decline invite
        /// </summary>
        public void DeclineInvite()
        {
            // decline invite
        }

        /// <summary>
        /// Send invite
        /// </summary>
        public void SendInvite()
        {
            // send invite
        }
        #endregion
    }
}