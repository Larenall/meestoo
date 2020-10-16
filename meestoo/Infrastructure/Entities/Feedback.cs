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
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int[] UserList { get; set; }
        
        public virtual User User { get; set; }
        public virtual ICollection<UserFeedbackReaction> UserFeedbackReaction { get; set; }
        public Feedback(int UserId, string Description, DateTime Date, int[] UserList)
        {
            this.UserId = UserId;
            this.Description = Description;
            this.Date = Date;
            this.UserList = UserList;
        }
    }
}
