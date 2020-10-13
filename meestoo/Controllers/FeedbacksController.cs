using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using meestoo;

namespace meestoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly postgresContext db;

        public FeedbacksController(postgresContext context)
        {
            db = context;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public List<object> GetFeedbacks()
        {
            var feedbackList = db.Feedback.ToList();
            var userList = db.Users.ToList();
            List<object> result = new List<object>();
            feedbackList.ForEach(f => {
                var user = userList.Where(el => el.UserId == f.UserId).ToList()[0];
                result.Add(new { id = f.FeedbackId, name = user.Name, imgUrl = user.ImgUrl, text = f.Feedback_, date = f.Date, userlist = f.UserList });
            });


            return result;
        }
        [HttpGet("{email}")]
        public List<object> GetMyFeedbacks(string email)
        {
            var feedbackList = db.Feedback.ToList();
            var user = db.Users.ToList().Where(el=>el.Email==email).ToList()[0];
            List<object> result = new List<object>();
            feedbackList.ForEach(f => {
                if (user.UserId==f.UserId) { 
                result.Add(new { id = f.FeedbackId, name = user.Name, imgUrl = user.ImgUrl, text = f.Feedback_, date = f.Date, userlist = f.UserList });
                };
            });
            return result;
        }
        [HttpGet("confirm/{email}/{id}")]
        public Boolean FeedbackOfUser(string email,int id)
        {
            var feedbackUserId = db.Feedback.ToList().Where(el=>el.FeedbackId==id).ToList()[0].UserId;
            var userId = db.Users.ToList().Where(el => el.Email == email).ToList()[0].UserId;
            return feedbackUserId == userId ? true : false;

        }
        [HttpGet("{email}/{id}")]
        public void LikeDislike(string email, int id)
        {
            var feedback = db.Feedback.ToList().Where(el => el.FeedbackId == id).ToList()[0];
            if (feedback.UserList.Contains(email))
            {
                feedback.UserList = feedback.UserList.Where(el => el != email).ToArray();
            }
            else
            {
                feedback.UserList = feedback.UserList.Concat(new string[] { email }).ToArray();
            }
            db.Feedback.Update(feedback);
            db.SaveChanges();
        }
        [HttpPost("{email}")]
        public void AddFeedback(string email,[FromBody]Feedback newFeedback)
        {
            newFeedback.UserId = db.Users.Where(el => el.Email == email).ToList()[0].UserId;
            db.Feedback.Add(newFeedback);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteFeedback(int id)
        {
            var feedback = db.Feedback.ToList().Where(el => el.FeedbackId == id).ToList()[0];
            db.Feedback.Remove(feedback);
            db.SaveChanges();
        }
    }
}
