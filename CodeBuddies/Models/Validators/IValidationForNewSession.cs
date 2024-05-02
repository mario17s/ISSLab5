using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Validators
{
    public interface IValidationForNewSession
    {
        void ValidateSessionName(string sessionName);
        void ValidateMaxNumberOfBuddies(string maxNoOfBuddies);
        void ValidateBuddyId(long buddyId);
        void ValidateSessionId(long sessionId);
    }
}
