using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace APIAutomation
{
    public class Utilities
    {
        public static User GetUserFromDB(int userId)
        {
            User user = new User();
            string querySelect = $@"select u.ID, u.Name, u.Email, u.Gender, s.Name, u.CreatedAt, u.UpdatedAt
                                    from Users u inner join Statuses s on u.StatusID = s.ID
                                    where u.ID = {userId}";
            using (SqlConnection conn = Database.DatabaseConnect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(querySelect, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.Id = reader.GetInt32(0);
                            user.Name = reader.GetString(1);
                            user.Email = reader.GetString(2);
                            user.Gender = reader.GetString(3);
                            user.Status = reader.GetString(4);
                            user.CreatedAt = reader.GetDateTime(5);
                            user.UpdatedAt = reader.GetDateTime(6);
                        }
                    }
                }
            }
            return user;
        }
    }
}
