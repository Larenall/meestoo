using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;


namespace meestoo
{
    public partial class Feedback
    {
        public Feedback()
        {
            UserFeedbackReaction = new HashSet<UserFeedbackReaction>();
        }
        
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Karma { get; set; }
        public int FeedbackId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UserFeedbackReaction> UserFeedbackReaction { get; set; }
        public Feedback(int UserId, string Description, DateTime Date, int Karma)
        {
            this.UserId = UserId;
            this.Description = Description;
            this.Date = Date;
            this.Karma = Karma;
        }
    }
}
