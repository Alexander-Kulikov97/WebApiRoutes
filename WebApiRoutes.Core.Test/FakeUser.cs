using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRoutes.Core.Test
{
    public class FakeUser
    {
        public static UserEntity User => new UserEntity
        {
            email = "Kuz@mail.ru",
            first_name = "Кузьма",
            last_name = "Кузницов",
            middle_name = "Сергеевич",
            login = "Kuz",
            password = "12345"
        };
    }
}
