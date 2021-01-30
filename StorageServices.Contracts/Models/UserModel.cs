﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StorageServices.Contracts.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }
    }
}
