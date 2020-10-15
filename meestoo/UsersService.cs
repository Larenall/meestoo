using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using meestoo.Models;
using System.Linq;

namespace meestoo
{

    public class UserService
    {
        private readonly postgresContext db;

        public UserService(postgresContext context)
        {
            db = context;
        }

        public void CreateOrUpdateUser(UserDTO userDto)
        {
            EscapeImageUrl(userDto);

            var user = db.Users.FirstOrDefault(el => el.Email == userDto.Email);

            if (user == null)
            {
                user = CreateUser(userDto);
            }
            else
            {
                UpdateUser(user, userDto);
            }
        }

        protected Users CreateUser(UserDTO userDto)
        {
            var newUser = new Users(userDto.Name, userDto.Email, userDto.ImgUrl);
            db.Users.Add(newUser);
            db.SaveChanges();
            return newUser;
        }

        protected void UpdateUser(Users user, UserDTO userDto)
        {
            bool hasUpdates = false;
            if (IsImageChanged(user, userDto))
            {
                user.ImgUrl = userDto.ImgUrl;
                hasUpdates = true;
            }

            if (IsNameChanged(user, userDto))
            {
                user.Name = userDto.Name;
                hasUpdates = true;
            }

            if (hasUpdates)
            {
                db.Users.Update(user);
                db.SaveChanges();
            }
        }

        private static bool IsNameChanged(Users user, UserDTO userDto)
        {
            return user.Name != null && !user.Name.Equals(userDto.Name, StringComparison.OrdinalIgnoreCase);
        }

        public bool IsImageChanged(Users user, UserDTO userDto)
        {
            return user.ImgUrl != userDto.ImgUrl || user.ImgUrl == null;
        }

        public void EscapeImageUrl(UserDTO userDto)
        {
            if (string.IsNullOrEmpty(userDto.ImgUrl))
            {
                return;
            }

            userDto.ImgUrl = userDto.ImgUrl.Replace('`', '/');
        }
    }

}
