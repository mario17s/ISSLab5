using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodeBuddies.Resources.Data.Constants;

namespace CodeBuddies.Models.Validators
{
    public class ValidationForNewSession : IValidationForNewSession
    {
        public void ValidateSessionName(string sessionName)
        {
            if (sessionName.Length < 3 || sessionName.Length > 50)
            {
                throw new ArgumentException("Session name must be between 3 and 50 characters long.");
            }
        }

        public void ValidateMaxNumberOfBuddies(string maxNumberOfBuddiesText)
        {
            int maxNumberOfBuddies;

            if (!int.TryParse(maxNumberOfBuddiesText, out maxNumberOfBuddies))
            {
                throw new ArgumentException("Maximum number of buddies must be a valid integer.");
            }
            else if (maxNumberOfBuddies < 0 || maxNumberOfBuddies > MAX_NUMBER_OF_BUDDIES_PER_SESSION)
            {
                throw new ArgumentOutOfRangeException("Maximum number of buddies must be between 0 and " + MAX_NUMBER_OF_BUDDIES_PER_SESSION + ".");
            }
        }

        public void ValidateBuddyId(long buddyId)
        {
            if (buddyId < 0)
            {
                throw new ArgumentOutOfRangeException("Buddy ID must be a non-negative integer.");
            }
        }

        public void ValidateSessionId(long sessionId)
        {
            if (sessionId < 0)
            {
                throw new ArgumentOutOfRangeException("Session ID must be a non-negative integer.");
            }
        }
    }
}