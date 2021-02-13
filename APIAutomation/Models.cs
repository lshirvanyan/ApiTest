using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomation
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
    public class Todo
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
