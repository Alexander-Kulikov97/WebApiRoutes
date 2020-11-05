using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebApiRoutes.Core.Models
{
    public class ResponseData
    {
        public string AccessToken { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }

        public LoginModel User { get; set;}
    }
}
