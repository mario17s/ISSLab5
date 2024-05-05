using System.Data;
using System.Data.SqlClient;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Models.Exceptions;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories.Interfaces;
namespace CodeBuddies.Repositories
{
    public class BuddyRepository : DBRepositoryBase, IBuddyRepository
    {
        public BuddyRepository() : base()
        {
        }

        public List<IBuddy> GetAllBuddies()
        {
            List<IBuddy> buddies = new List<IBuddy>();

            DataSet buddyDataSet = new DataSet();
            string selectAllBuddies = "SELECT * FROM Buddies";
            SqlCommand selectAllBuddiesCommand = new SqlCommand(selectAllBuddies, sqlConnection);
            dataAdapter.SelectCommand = selectAllBuddiesCommand;
            buddyDataSet.Clear();
            dataAdapter.Fill(buddyDataSet, "Buddies");

            foreach (DataRow buddyRow in buddyDataSet.Tables["Buddies"].Rows)
            {
                SqlDataAdapter notificationsDataAdapter = new SqlDataAdapter();

                DataSet notificationDataSet = new DataSet();
                string notificationQuery = "SELECT * FROM Notifications where receiver_id = @id";
                SqlCommand selectAllNotificationsForSpecificBuddyCommand = new SqlCommand(notificationQuery, sqlConnection);
                notificationsDataAdapter.SelectCommand = selectAllNotificationsForSpecificBuddyCommand;
                selectAllNotificationsForSpecificBuddyCommand.Parameters.AddWithValue("@id", buddyRow["id"]);
                notificationDataSet.Clear();
                notificationsDataAdapter.Fill(notificationDataSet, "Notifications");

                List<Notification> notifications = new List<Notification>();

                foreach (DataRow notificationRow in notificationDataSet.Tables["Notifications"].Rows)
                {
                    Notification currentNotification;

                    if (notificationRow["notification_type"].ToString() == "invite")
                    {
                        currentNotification = new InviteNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["sender_id"], (long)notificationRow["receiver_id"], (long)notificationRow["session_id"], false);
                    }
                    else
                    {
                        currentNotification = new InfoNotification((long)notificationRow["id"], (DateTime)notificationRow["notification_timestamp"], notificationRow["notification_type"].ToString(), notificationRow["notification_status"].ToString(), notificationRow["notification_description"].ToString(), (long)notificationRow["sender_id"], (long)notificationRow["receiver_id"], (long)notificationRow["session_id"]);
                    }

                    notifications.Add(currentNotification);
                }

                IBuddy currentBudy = new Buddy((long)buddyRow["id"], buddyRow["buddy_name"].ToString(), buddyRow["profile_photo_url"].ToString(), buddyRow["buddy_status"].ToString(), notifications);
                buddies.Add(currentBudy);
            }

            return buddies;
        }

        public List<IBuddy> GetActiveBuddies()
        {
            return GetAllBuddies().Where(buddy => buddy.Status == "active").ToList();
        }

        public List<IBuddy> GetInactiveBuddies()
        {
            return GetAllBuddies().Where(buddy => buddy.Status == "inactive").ToList();
        }

        public IBuddy UpdateBuddyStatus(IBuddy buddy)
        {
            buddy.Status = buddy.Status == "active" ? "inactive" : "active";
            return buddy;
        }

        public void ClearDatabase()
        {
            List<string> tables = new List<string>
            {
                "BuddiesSessions", "MessagesCodeReviews", "MessagesSessions", "CodeReviewsSessions",
                "Notifications", "Sessions", "Messages", "CodeReviews", "CodeContributions", "Buddies"
            };
            foreach (string table in tables)
            {
                string deleteNotificationQuery = $"DELETE FROM {table}";
                using (SqlCommand deleteCommand = new SqlCommand(deleteNotificationQuery, sqlConnection))
                {
                    deleteCommand.ExecuteNonQuery();
                }
            }
        }

        public void AddBuddy(long buddyId, string buddyName, string buddyProfile, string status)
        {
            string insertQuery = "INSERT INTO Buddies VALUES (@BuddyId, @BuddyName, @BuddyProfile, @Status)";
            try
            {
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
                {
                    insertCommand.Parameters.AddWithValue("@BuddyId", buddyId);
                    insertCommand.Parameters.AddWithValue("@BuddyName", buddyName);
                    insertCommand.Parameters.AddWithValue("@BuddyProfile", buddyProfile);
                    insertCommand.Parameters.AddWithValue("@Status", status);

                    insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new EntityAlreadyExists(ex.Message);
            }
        }
    }
}
