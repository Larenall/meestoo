using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using meestoo;
using meestoo.Models;
using Microsoft.AspNetCore.Authorization;

namespace meestoo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly postgresContext db;

        public FeedbacksController(postgresContext context)
        {
            db = context;
        }
        [HttpGet("{id}")]
        public List<SendFeedbackDTO> GetFeedbacks(int id)
        {
            var feedbackList = db.Feedback.ToList();
            var userList = db.Users;
            var reactionList = db.UserFeedbackReaction;
            List<SendFeedbackDTO> result = new List<SendFeedbackDTO>();
            feedbackList.ForEach(f => {
                var user = userList.FirstOrDefault(el => el.UserId == f.UserId);
                var reaction = reactionList.FirstOrDefault(el => el.UserId == id && el.FeedbackId == f.FeedbackId);
                result.Add(new SendFeedbackDTO(f.FeedbackId, user.Name, user.ImgUrl, f.Description, f.Date, f.Karma, reaction != null ,f.UserId==id));
            });
            return result;
        }
        [HttpPut]
        public void LikeDislike([FromBody] KarmaDTO karma)
        {

            var feedback = db.Feedback.FirstOrDefault(el => el.FeedbackId == karma.Id);
            var reaction = db.UserFeedbackReaction.FirstOrDefault(el => karma.Id == el.FeedbackId && karma.UserId==el.UserId);
            if (reaction == null)
            {
                feedback.Karma = feedback.Karma + 1;
                db.UserFeedbackReaction.Add(new UserFeedbackReaction(karma.Id, karma.UserId));
            }
            else
            {
                feedback.Karma = feedback.Karma - 1;
                db.UserFeedbackReaction.Remove(reaction);
            }
            db.Feedback.Update(feedback);
            db.SaveChanges();
        }
        [HttpPost]
        public void AddFeedback([FromBody] GetFeedbackDTO getFeedback)
        {
            db.Feedback.Add(new Feedback(getFeedback.UserId, getFeedback.Description, getFeedback.Date, 0));
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteFeedback(int id)
        {
            var feedback = db.Feedback.FirstOrDefault(el => el.FeedbackId == id);
            var reactions = db.UserFeedbackReaction.Where(el => el.FeedbackId == id);
            db.UserFeedbackReaction.RemoveRange(reactions);
            db.Feedback.Remove(feedback);
            db.SaveChanges();
        }
    }
}
