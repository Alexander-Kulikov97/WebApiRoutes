using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebApiRoutes.Core.Models
{
    public class ResponseUser
    {
        public ClaimsIdentity ClaimsIdentity { get; set; }

        public ResponseData data { get; set; }
    }
}
