using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRoutes.Data.Test
{
    public class FackeUser
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

        public static List<UserEntity> Users(int count)
        {
            var lst = new List<UserEntity>();
            for (var i = 0; i < count; i++)
                lst.Add(User);
            return lst;
        }
    }
}
