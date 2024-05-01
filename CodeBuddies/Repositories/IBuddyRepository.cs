using CodeBuddies.Models.Entities;

namespace CodeBuddies.Repositories
{
    public interface IBuddyRepository
    {
        List<IBuddy> GetActiveBuddies();
        List<IBuddy> GetAllBuddies();
        List<IBuddy> GetInactiveBuddies();
        IBuddy UpdateBuddyStatus(IBuddy buddy);
    }
}