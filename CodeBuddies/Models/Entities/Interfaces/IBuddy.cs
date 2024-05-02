namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IBuddy
    {
        string BuddyName { get; set; }
        long Id { get; set; }
        List<Notification> Notifications { get; set; }
        string ProfilePhotoUrl { get; set; }
        string Status { get; set; }

        void AcceptInvite();
        void CreateNewSession(string sessionName);
        void DeclineInvite();
        void SendInvite();
    }
}