using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;


namespace meestoo
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public string Feedback_ { get; set; }
        public string Date { get; set; }
        public string[] UserList { get; set; }
        [JsonIgnore]
        public virtual Users User { get; set; }

        public Feedback(int FeedbackId, int UserId, string Feedback_, string Date, string[] UserList)
        {
            this.FeedbackId = FeedbackId;
            this.UserId = UserId;
            this.Feedback_ = Feedback_;
            this.Date = Date;
            this.UserList = UserList;
        }
    }
}
