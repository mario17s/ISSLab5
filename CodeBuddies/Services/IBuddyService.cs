using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;

namespace CodeBuddies.Services
{
    public interface IBuddyService
    {
        List<IBuddy> ActiveBuddies { get; set; }
        IBuddyRepository BuddyRepository { get; set; }
        List<IBuddy> InactiveBuddies { get; set; }

        void changeBuddyStatus(IBuddy buddy);
        List<IBuddy> filterBuddies(string searchText);
        List<IBuddy> getAllBuddies();
        void refreshData();
    }
}