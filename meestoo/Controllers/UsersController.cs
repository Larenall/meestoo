using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meestoo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace meestoo
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly postgresContext db;

        public UsersController(postgresContext context)
        {
            db = context;
        }
        [HttpPost]
        public void OnLogin(UserDTO getUser)
        {
            var userList = db.Users.ToList();
            getUser.ImgUrl = getUser.ImgUrl.Replace('`', '/');
            var user = userList.Where(el => el.Email == getUser.Email).ToList();
            if (user.Count == 0)
            {
                int maxId = 0;
                foreach (Users u in userList)
                {
                    maxId = Math.Max(maxId, u.UserId);
                }
                Users newUser = new Users(maxId + 1, getUser.Name, getUser.Email, getUser.ImgUrl);
                db.Users.Add(newUser);
                db.SaveChanges();
                return;
            }
            if (user[0].ImgUrl != getUser.ImgUrl || user[0].ImgUrl==null) user[0].ImgUrl = getUser.ImgUrl;
            
            if (user[0].Name != getUser.Name) user[0].Name = getUser.Name;
            
            db.Users.Update(user[0]);
            db.SaveChanges();
        }
    }
}




