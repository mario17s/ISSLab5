using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Repositories.Interfaces
{
    public interface IBuddyRepository
    {
        List<IBuddy> GetActiveBuddies();
        List<IBuddy> GetAllBuddies();
        List<IBuddy> GetInactiveBuddies();
        IBuddy UpdateBuddyStatus(IBuddy buddy);
    }
}