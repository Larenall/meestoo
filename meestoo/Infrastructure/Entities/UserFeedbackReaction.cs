using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace meestoo
{
    public partial class UserFeedbackReaction
    {
        public int Id { get; set; }
        public int FeedbackId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Feedback Feedback { get; set; }
        public UserFeedbackReaction(int Id,int FeedbackId, int UserId)
        {
            this.Id = Id;
            this.FeedbackId = FeedbackId;
            this.UserId = UserId;
        }
        public UserFeedbackReaction() { }
    }
}
