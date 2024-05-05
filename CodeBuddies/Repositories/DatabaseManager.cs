using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Resources.Data;
using static CodeBuddies.Resources.Data.Constants;

namespace CodeBuddies.Repositories
{
    public static class DatabaseManager
    {
        private static void SetupDatabase()
        {
            ClearDatabase();
            PopulateDatabase();
        }

        private static void ClearDatabase()
        {
            SqlConnection sqlConnection = new SqlConnection(Constants.CONNECTION_STRING);
            sqlConnection.Open();
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
            sqlConnection.Close();
        }

        private static void PopulateDatabase()
        {
            InsertBuddies();
            InsertSessions();
            InsertBuddiesSessions();
            InsertNotifications();
            InsertCodeReviews();
            InsertCodeReviewsSessions();
            InsertMessages();
            InsertMessagesCodeReviews();
            InsertMessagesSessions();
        }

        /*INSERT INTO Buddies VALUES
        (1, 'Raul', 'pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png', 'active'),
        (2, 'Beti', 'pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png', 'inactive'),
        (3, 'Deni', 'pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png', 'active'),
        (4, 'Cosmin',  'pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png', 'inactive'),
        (5, 'Dragos',  'pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png', 'inactive')*/
        private static void InsertBuddies()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO Buddies (id, buddy_name, profile_photo_url, buddy_status)
                VALUES
                (@Id1, @Name1, @Picture1, @Status1),
                (@Id2, @Name2, @Picture2, @Status2),
                (@Id3, @Name3, @Picture3, @Status3),
                (@Id4, @Name4, @Picture4, @Status4),
                (@Id5, @Name5, @Picture5, @Status5)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Id1", 1);
                command.Parameters.AddWithValue("@Name1", "Raul");
                command.Parameters.AddWithValue("@Picture1", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png");
                command.Parameters.AddWithValue("@Status1", "active");

                command.Parameters.AddWithValue("@Id2", 2);
                command.Parameters.AddWithValue("@Name2", "Beti");
                command.Parameters.AddWithValue("@Picture2", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png");
                command.Parameters.AddWithValue("@Status2", "inactive");

                command.Parameters.AddWithValue("@Id3", 3);
                command.Parameters.AddWithValue("@Name3", "Deni");
                command.Parameters.AddWithValue("@Picture3", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png");
                command.Parameters.AddWithValue("@Status3", "active");

                command.Parameters.AddWithValue("@Id4", 4);
                command.Parameters.AddWithValue("@Name4", "Cosmin");
                command.Parameters.AddWithValue("@Picture4", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png");
                command.Parameters.AddWithValue("@Status4", "inactive");

                command.Parameters.AddWithValue("@Id5", 5);
                command.Parameters.AddWithValue("@Name5", "Dragos");
                command.Parameters.AddWithValue("@Picture5", "pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png");
                command.Parameters.AddWithValue("@Status5", "inactive");

                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully.");
            }
        }

        /*INSERT INTO Sessions VALUES
        (1, 1, 'session1', '2024-03-21T10:15:00', '2024-04-21T10:45:00'),
        (2, 2, 'session2', '2024-02-21T10:15:00', '2024-04-21T10:55:00'),
        (3, 3, 'session3', '2024-01-21T10:15:00', '2024-04-21T10:35:00')*/
        public static void InsertSessions()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO Sessions (id, owner_id, session_name, creation_date, last_edit_date)
                VALUES
                (@Id1, @BuddyId1, @Name1, @StartDate1, @EndDate1),
                (@Id2, @BuddyId2, @Name2, @StartDate2, @EndDate2),
                (@Id3, @BuddyId3, @Name3, @StartDate3, @EndDate3)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Id1", 1);
                command.Parameters.AddWithValue("@BuddyId1", 1);
                command.Parameters.AddWithValue("@Name1", "session1");
                command.Parameters.AddWithValue("@StartDate1", new DateTime(2024, 03, 21, 10, 15, 00));
                command.Parameters.AddWithValue("@EndDate1", new DateTime(2024, 04, 21, 10, 45, 00));

                command.Parameters.AddWithValue("@Id2", 2);
                command.Parameters.AddWithValue("@BuddyId2", 2);
                command.Parameters.AddWithValue("@Name2", "session2");
                command.Parameters.AddWithValue("@StartDate2", new DateTime(2024, 02, 21, 10, 15, 00));
                command.Parameters.AddWithValue("@EndDate2", new DateTime(2024, 04, 21, 10, 55, 00));

                command.Parameters.AddWithValue("@Id3", 3);
                command.Parameters.AddWithValue("@BuddyId3", 3);
                command.Parameters.AddWithValue("@Name3", "session3");
                command.Parameters.AddWithValue("@StartDate3", new DateTime(2024, 01, 21, 10, 15, 00));
                command.Parameters.AddWithValue("@EndDate3", new DateTime(2024, 04, 21, 10, 35, 00));

                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully.");
            }
        }

        /*INSERT INTO BuddiesSessions VALUES
        (1, 1),
        (2, 1),
        (3, 1),
        (2, 2),
        (5, 2),
        (1, 2)*/
        public static void InsertBuddiesSessions()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO BuddiesSessions (buddy_id, session_id)
                VALUES
                (@BuddyId1, @SessionId1),
                (@BuddyId2, @SessionId2),
                (@BuddyId3, @SessionId3),
                (@BuddyId4, @SessionId4),
                (@BuddyId5, @SessionId5),
                (@BuddyId6, @SessionId6)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@BuddyId1", 1);
                command.Parameters.AddWithValue("@SessionId1", 1);

                command.Parameters.AddWithValue("@BuddyId2", 2);
                command.Parameters.AddWithValue("@SessionId2", 1);

                command.Parameters.AddWithValue("@BuddyId3", 3);
                command.Parameters.AddWithValue("@SessionId3", 1);

                command.Parameters.AddWithValue("@BuddyId4", 2);
                command.Parameters.AddWithValue("@SessionId4", 2);

                command.Parameters.AddWithValue("@BuddyId5", 5);
                command.Parameters.AddWithValue("@SessionId5", 2);

                command.Parameters.AddWithValue("@BuddyId6", 1);
                command.Parameters.AddWithValue("@SessionId6", 2);

                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully.");
            }
        }

        /*INSERT INTO Notifications VALUES
        (1, '2024-04-21T08:30:00', 'successInformation', 'delivered', 'Cosmin accepted your invitation', 4, 1, 1),
        (2, '2024-04-20T14:45:00', 'rejectInformation', 'delivered', 'Beti rejected your invitation', 2, 1, 1),
        (3, '2024-04-21T10:15:00', 'invite',  'pending', 'Invited by Beti - Accept or Decline', 2, 1, 1),
        (4, '2024-04-21T10:15:00', 'invite',  'pending', 'Invited by Cosmin - Accept or Decline', 4, 1, 3),
        (5, '2024-04-21T10:15:00', 'invite',  'pending', 'Invited by Dragos - Accept or Decline', 5, 1, 2),
        (6, '2024-04-21T10:15:00', 'invite',  'pending', 'Invited by Raul - Accept or Decline', 1, 2, 2)*/
        public static void InsertNotifications()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO Notifications (id, notification_timestamp, notification_type, notification_status, notification_description, sender_id, receiver_id, session_id)
                VALUES
                (@Id1, @Timestamp1, @Type1, @Status1, @Description1, @SenderId1, @ReceiverId1, @SessionId1),
                (@Id2, @Timestamp2, @Type2, @Status2, @Description2, @SenderId2, @ReceiverId2, @SessionId2),
                (@Id3, @Timestamp3, @Type3, @Status3, @Description3, @SenderId3, @ReceiverId3, @SessionId3),
                (@Id4, @Timestamp4, @Type4, @Status4, @Description4, @SenderId4, @ReceiverId4, @SessionId4),
                (@Id5, @Timestamp5, @Type5, @Status5, @Description5, @SenderId5, @ReceiverId5, @SessionId5),
                (@Id6, @Timestamp6, @Type6, @Status6, @Description6, @SenderId6, @ReceiverId6, @SessionId6)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Id1", 1);
                command.Parameters.AddWithValue("@Timestamp1", new DateTime(2024, 04, 21, 08, 30, 00));
                command.Parameters.AddWithValue("@Type1", "successInformation");
                command.Parameters.AddWithValue("@Status1", "delivered");
                command.Parameters.AddWithValue("@Description1", "Cosmin accepted your invitation");
                command.Parameters.AddWithValue("@SenderId1", 4);
                command.Parameters.AddWithValue("@ReceiverId1", 1);
                command.Parameters.AddWithValue("@SessionId1", 1);

                command.Parameters.AddWithValue("@Id2", 2);
                command.Parameters.AddWithValue("@Timestamp2", new DateTime(2024, 04, 20, 14, 45, 00));
                command.Parameters.AddWithValue("@Type2", "rejectInformation");
                command.Parameters.AddWithValue("@Status2", "delivered");
                command.Parameters.AddWithValue("@Description2", "Beti rejected your invitation");
                command.Parameters.AddWithValue("@SenderId2", 2);
                command.Parameters.AddWithValue("@ReceiverId2", 1);
                command.Parameters.AddWithValue("@SessionId2", 1);

                command.Parameters.AddWithValue("@Id3", 3);
                command.Parameters.AddWithValue("@Timestamp3", new DateTime(2024, 04, 21, 10, 15, 00));
                command.Parameters.AddWithValue("@Type3", "invite");
                command.Parameters.AddWithValue("@Status3", "pending");
                command.Parameters.AddWithValue("@Description3", "Invited by Beti - Accept or Decline");
                command.Parameters.AddWithValue("@SenderId3", 2);
                command.Parameters.AddWithValue("@ReceiverId3", 1);
                command.Parameters.AddWithValue("@SessionId3", 1);

                command.Parameters.AddWithValue("@Id4", 4);
                command.Parameters.AddWithValue("@Timestamp4", new DateTime(2024, 04, 21, 10, 15, 00));
                command.Parameters.AddWithValue("@Type4", "invite");
                command.Parameters.AddWithValue("@Status4", "pending");
                command.Parameters.AddWithValue("@Description4", "Invited by Cosmin - Accept or Decline");
                command.Parameters.AddWithValue("@SenderId4", 4);
                command.Parameters.AddWithValue("@ReceiverId4", 1);
                command.Parameters.AddWithValue("@SessionId4", 3);

                command.Parameters.AddWithValue("@Id5", 5);
                command.Parameters.AddWithValue("@Timestamp5", new DateTime(2024, 04, 21, 10, 15, 00));
                command.Parameters.AddWithValue("@Type5", "invite");
                command.Parameters.AddWithValue("@Status5", "pending");
                command.Parameters.AddWithValue("@Description5", "Invited by Dragos - Accept or Decline");
                command.Parameters.AddWithValue("@SenderId5", 5);
                command.Parameters.AddWithValue("@ReceiverId5", 1);
                command.Parameters.AddWithValue("@SessionId5", 2);

                command.Parameters.AddWithValue("@Id6", 6);
                command.Parameters.AddWithValue("@Timestamp6", new DateTime(2024, 04, 21, 10, 15, 00));
                command.Parameters.AddWithValue("@Type6", "invite");
                command.Parameters.AddWithValue("@Status6", "pending");
                command.Parameters.AddWithValue("@Description6", "Invited by Raul - Accept or Decline");
                command.Parameters.AddWithValue("@SenderId6", 1);
                command.Parameters.AddWithValue("@ReceiverId6", 2);
                command.Parameters.AddWithValue("@SessionId6", 2);

                command.ExecuteNonQuery();
            }
        }

        /*INSERT INTO CodeContributions VALUES
        (1, 1, 44, '2024-01-15T10:15:00', 1),
        (2, 1, 55, '2024-01-19T10:15:00', 1),
        (3, 2, 66, '2024-01-20T10:15:00', 1)*/
        public static void InsertCodeContributions()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO CodeContributions (id, buddy_id, contribution_value, contribution_date, session_id)
                VALUES
                (@Id1, @BuddyId1, @LinesAdded1, @Timestamp1, @SessionId1),
                (@Id2, @BuddyId2, @LinesAdded2, @Timestamp2, @SessionId2),
                (@Id3, @BuddyId3, @LinesAdded3, @Timestamp3, @SessionId3)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Id1", 1);
                command.Parameters.AddWithValue("@BuddyId1", 1);
                command.Parameters.AddWithValue("@LinesAdded1", 44);
                command.Parameters.AddWithValue("@Timestamp1", new DateTime(2024, 01, 15, 10, 15, 00));
                command.Parameters.AddWithValue("@SessionId1", 1);

                command.Parameters.AddWithValue("@Id2", 2);
                command.Parameters.AddWithValue("@BuddyId2", 1);
                command.Parameters.AddWithValue("@LinesAdded2", 55);
                command.Parameters.AddWithValue("@Timestamp2", new DateTime(2024, 01, 19, 10, 15, 00));
                command.Parameters.AddWithValue("@SessionId2", 1);

                command.Parameters.AddWithValue("@Id3", 3);
                command.Parameters.AddWithValue("@BuddyId3", 2);
                command.Parameters.AddWithValue("@LinesAdded3", 66);
                command.Parameters.AddWithValue("@Timestamp3", new DateTime(2024, 01, 20, 10, 15, 00));
                command.Parameters.AddWithValue("@SessionId3", 1);

                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully.");
            }
        }

        /*INSERT INTO CodeReviews VALUES
        (1, 1, 'section1', 'open'),
        (2, 2, 'section2', 'closed'),
        (3, 1, 'section3', 'open')*/
        public static void InsertCodeReviews()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO CodeReviews (id, owner_id, code_section, code_review_status)
                VALUES
                (@Id1, @BuddyId1, @Name1, @Status1),
                (@Id2, @BuddyId2, @Name2, @Status2),
                (@Id3, @BuddyId3, @Name3, @Status3)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Id1", 1);
                command.Parameters.AddWithValue("@BuddyId1", 1);
                command.Parameters.AddWithValue("@Name1", "section1");
                command.Parameters.AddWithValue("@Status1", "open");

                command.Parameters.AddWithValue("@Id2", 2);
                command.Parameters.AddWithValue("@BuddyId2", 2);
                command.Parameters.AddWithValue("@Name2", "section2");
                command.Parameters.AddWithValue("@Status2", "closed");

                command.Parameters.AddWithValue("@Id3", 3);
                command.Parameters.AddWithValue("@BuddyId3", 1);
                command.Parameters.AddWithValue("@Name3", "section3");
                command.Parameters.AddWithValue("@Status3", "open");

                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully.");
            }
        }

        /*INSERT INTO CodeReviewsSessions VALUES
        (1, 1),
        (2, 1),
        (3, 2)*/
        public static void InsertCodeReviewsSessions()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO CodeReviewsSessions (code_review_id, session_id)
                VALUES
                (@CodeReviewId1, @SessionId1),
                (@CodeReviewId2, @SessionId2),
                (@CodeReviewId3, @SessionId3)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@CodeReviewId1", 1);
                command.Parameters.AddWithValue("@SessionId1", 1);

                command.Parameters.AddWithValue("@CodeReviewId2", 1);
                command.Parameters.AddWithValue("@SessionId2", 2);

                command.Parameters.AddWithValue("@CodeReviewId3", 2);
                command.Parameters.AddWithValue("@SessionId3", 3);

                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully.");
            }
        }

        /*INSERT INTO Messages VALUES
        (1, '2024-01-11T10:15:00', 'message1', 1),
        (2, '2024-01-12T10:15:00', 'message2', 2),
        (3, '2024-01-13T10:15:00', 'message3', 1),
        (4, '2024-01-14T10:15:00', 'message4', 1),
        (5, '2024-01-15T10:15:00', 'message5', 1),
        (6, '2024-01-16T10:15:00', 'message6', 1)*/
        public static void InsertMessages()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO Messages (id, message_timestamp, content, sender_id)
                VALUES
                (@Id1, @Timestamp1, @Content1, @SessionId1),
                (@Id2, @Timestamp2, @Content2, @SessionId2),
                (@Id3, @Timestamp3, @Content3, @SessionId3),
                (@Id4, @Timestamp4, @Content4, @SessionId4),
                (@Id5, @Timestamp5, @Content5, @SessionId5),
                (@Id6, @Timestamp6, @Content6, @SessionId6)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Id1", 1);
                command.Parameters.AddWithValue("@Timestamp1", new DateTime(2024, 01, 11, 10, 15, 00));
                command.Parameters.AddWithValue("@Content1", "message1");
                command.Parameters.AddWithValue("@SessionId1", 1);

                command.Parameters.AddWithValue("@Id2", 2);
                command.Parameters.AddWithValue("@Timestamp2", new DateTime(2024, 01, 12, 10, 15, 00));
                command.Parameters.AddWithValue("@Content2", "message2");
                command.Parameters.AddWithValue("@SessionId2", 2);

                command.Parameters.AddWithValue("@Id3", 3);
                command.Parameters.AddWithValue("@Timestamp3", new DateTime(2024, 01, 13, 10, 15, 00));
                command.Parameters.AddWithValue("@Content3", "message3");
                command.Parameters.AddWithValue("@SessionId3", 1);

                command.Parameters.AddWithValue("@Id4", 4);
                command.Parameters.AddWithValue("@Timestamp4", new DateTime(2024, 01, 14, 10, 15, 00));
                command.Parameters.AddWithValue("@Content4", "message4");
                command.Parameters.AddWithValue("@SessionId4", 1);

                command.Parameters.AddWithValue("@Id5", 5);
                command.Parameters.AddWithValue("@Timestamp5", new DateTime(2024, 01, 15, 10, 15, 00));
                command.Parameters.AddWithValue("@Content5", "message5");
                command.Parameters.AddWithValue("@SessionId5", 1);

                command.Parameters.AddWithValue("@Id6", 6);
            }
        }

        /*INSERT INTO MessagesCodeReviews VALUES
        (1, 1),
        (1, 2),
        (2, 3)*/
        public static void InsertMessagesCodeReviews()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO MessagesCodeReviews (code_review_id, message_id)
                VALUES
                (@MessageId1, @CodeReviewId1),
                (@MessageId2, @CodeReviewId2),
                (@MessageId3, @CodeReviewId3)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@MessageId1", 1);
                command.Parameters.AddWithValue("@CodeReviewId1", 1);

                command.Parameters.AddWithValue("@MessageId2", 1);
                command.Parameters.AddWithValue("@CodeReviewId2", 2);

                command.Parameters.AddWithValue("@MessageId3", 2);
                command.Parameters.AddWithValue("@CodeReviewId3", 3);

                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully.");
            }
        }

        /*INSERT INTO MessagesSessions VALUES
        (1, 4),
        (1, 5),
        (2, 6)*/
        public static void InsertMessagesSessions()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO MessagesSessions (session_id, message_id)
                VALUES
                (@MessageId1, @SessionId1),
                (@MessageId2, @SessionId2),
                (@MessageId3, @SessionId3)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@MessageId1", 1);
                command.Parameters.AddWithValue("@SessionId1", 4);

                command.Parameters.AddWithValue("@MessageId2", 1);
                command.Parameters.AddWithValue("@SessionId2", 5);

                command.Parameters.AddWithValue("@MessageId3", 2);
                command.Parameters.AddWithValue("@SessionId3", 6);

                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully.");
            }
        }
    }
}
