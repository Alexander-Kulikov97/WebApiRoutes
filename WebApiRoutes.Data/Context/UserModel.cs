using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRoutes.Data.Context
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
