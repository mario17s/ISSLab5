using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    public static class GlobalEvents
    {
        public static event BuddyPinnedHandler BuddyPinned;

        public delegate void BuddyPinnedHandler();

        public delegate void BuddyAddedToSessionEventHandler(long buddyId, long sessionId);

        public static event BuddyAddedToSessionEventHandler BuddyAddedToSession;

        #region Methods

        /// <summary>
        /// Raise the BuddyAddedToSession event
        /// </summary>
        /// <param name="buddyId"></param>
        /// <param name="sessionId"></param>
        public static void RaiseBuddyAddedToSessionEvent(long buddyId, long sessionId)
        {
            BuddyAddedToSession?.Invoke(buddyId, sessionId);
        }

        /// <summary>
        /// Raise the BuddyPinned event
        /// </summary>
        public static void RaiseBuddyPinned()
        {
            BuddyPinned?.Invoke();
        }
        #endregion
    }
}
