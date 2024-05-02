using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IInviteNotification : INotification
    {
        bool IsAccepted { get; set; }

        void MarkNotification();
    }
}
