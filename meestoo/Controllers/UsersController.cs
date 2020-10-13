using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet("{getEmail}/{getName}/{getImgUrl}")]
        public void OnLogin(string getEmail, string getName,string getImgUrl)
        {
            var userList = db.Users.ToList();
            getImgUrl = getImgUrl.Replace('`', '/');
            var user = userList.Where(el => el.Email == getEmail).ToList();
            if (user.Count == 0)
            {
                int maxId = 0;
                foreach (Users u in userList)
                {
                    maxId = Math.Max(maxId, u.UserId);
                }
                Users newUser = new Users(maxId + 1, getName, getEmail, getImgUrl);
                db.Users.Add(newUser);
                db.SaveChanges();
                return;
            }
            if (user[0].ImgUrl != getImgUrl || user[0].ImgUrl==null) user[0].ImgUrl = getImgUrl;
            
            if (user[0].Name != getName)user[0].Name = getName;
            
            db.Users.Update(user[0]);
            db.SaveChanges();
        }
    }
}




