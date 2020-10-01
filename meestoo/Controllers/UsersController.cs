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
        [HttpGet]
        public IEnumerable<Feedback> Get()
        {
            var getEmail = "volodamvs@gmail.com";
            var user = db.Users.ToList().Where(el => el.Email == getEmail).ToList()[0].UserId;
            var feedlist = db.Feedback.ToList().Where(el => el.UserId == user).ToList();
            return feedlist;
        }
        [HttpPost]
        public void HttpPost()
        {

        }
        [HttpPatch]
        public void HttpPatch()
        {
             
        }
    }
}




