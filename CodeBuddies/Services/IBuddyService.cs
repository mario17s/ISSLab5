using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;

namespace CodeBuddies.Services
{
    public interface IBuddyService
    {
        List<IBuddy> ActiveBuddies { get; set; }
        IBuddyRepository BuddyRepository { get; set; }
        List<IBuddy> InactiveBuddies { get; set; }
        IBuddy ChangeBuddyStatus(IBuddy buddy);
        List<IBuddy> FilterBuddies(string searchText);
        List<IBuddy> GetAllBuddies();
        void RefreshData();
    }
}