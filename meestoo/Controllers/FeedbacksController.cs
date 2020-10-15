using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using meestoo;
using meestoo.Models;

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
        public List<FeedbackDTO> GetFeedbacks()
        {
            var feedbackList = db.Feedback.ToList();
            var userList = db.Users.ToList();
            List<FeedbackDTO> result = new List<FeedbackDTO>();
            feedbackList.ForEach(f => {
                var user = userList.FirstOrDefault(el => el.UserId == f.UserId);
                result.Add(new FeedbackDTO(f.FeedbackId, user.Name, user.ImgUrl, f.Description, f.Date, f.UserList));
            });


            return result;
        }
        [HttpGet("{email}")]
        public List<FeedbackDTO> GetMyFeedbacks(string email)
        {
            var feedbackList = db.Feedback.ToList();
            var user = db.Users.ToList().FirstOrDefault(el => el.Email == email);
            List<FeedbackDTO> result = new List<FeedbackDTO>();
            feedbackList.ForEach(f => {
                if (user.UserId == f.UserId) {
                    result.Add(new FeedbackDTO(f.FeedbackId, user.Name, user.ImgUrl, f.Description, f.Date, f.UserList));
                };
            });
            return result;
        }
        [HttpGet("confirm/{email}/{id}")]
        public Boolean FeedbackOfUser(string email, int id)
        {
            var feedbackUserId = db.Feedback.ToList().FirstOrDefault(el => el.FeedbackId == id).UserId;
            var userId = db.Users.ToList().FirstOrDefault(el => el.Email == email).UserId;
            return feedbackUserId == userId;

        }

        [HttpPut]
        public void LikeDislike([FromBody] KarmaDTO karma)
        {

            var feedback = db.Feedback.ToList().FirstOrDefault(el => el.FeedbackId == karma.Id);
            if (feedback.UserList.Contains(karma.Email))
            {
                feedback.UserList = feedback.UserList.Where(el => el != karma.Email).ToArray();
            }
            else
            {
                feedback.UserList = feedback.UserList.Concat(new string[] { karma.Email }).ToArray();
            }
            db.Feedback.Update(feedback);
            db.SaveChanges();
        }
        [HttpPost]
        public void AddFeedback([FromBody] Feedback newFeedback)
        {
            newFeedback.UserId = db.Users.ToList().FirstOrDefault(el => el.Email == newFeedback.UserList[0]).UserId;
            newFeedback.UserList =new string[] { };
            db.Feedback.Add(newFeedback);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteFeedback(int id)
        {
            var feedback = db.Feedback.ToList().FirstOrDefault(el => el.FeedbackId == id);
            db.Feedback.Remove(feedback);
            db.SaveChanges();
        }
    }
}
