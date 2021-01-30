using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRoutes.Core.Test.Models
{
    public class UserModel
    {
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string middle_name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string login { get; set; }
    }
}
