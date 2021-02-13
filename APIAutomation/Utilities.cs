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
                            user.id = reader.GetInt32(0);
                            user.name = reader.GetString(1);
                            user.email = reader.GetString(2);
                            user.gender = reader.GetString(3);
                            user.status = reader.GetString(4);
                            user.created_at = reader.GetDateTime(5);
                            user.updated_at = reader.GetDateTime(6);
                        }
                    }
                }
            }
            return user;
        }
        public static Todo GetTodoListFromDB(int id)
        {
            Todo toDoList = new Todo();
            string querySelect = $@"select * from Todos where id = {id}";
            using (SqlConnection conn = Database.DatabaseConnect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(querySelect, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            toDoList.id = reader.GetInt32(0);
                            toDoList.user_id = reader.GetInt32(1);
                            toDoList.title = reader.GetString(2);
                            toDoList.completed = reader.GetBoolean(3);
                            toDoList.created_at = reader.GetDateTime(4);
                            toDoList.updated_at = reader.GetDateTime(5);
                        }
                    }
                }
            }
            return toDoList;
        }
    }
}
