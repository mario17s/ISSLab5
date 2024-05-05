using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;

namespace CodeBuddies.Services.Interfaces
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