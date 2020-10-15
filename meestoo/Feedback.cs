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
        public string Description { get; set; }
        public string Date { get; set; }
        public string[] UserList { get; set; }
        [JsonIgnore]
        public virtual Users User { get; set; }

        public Feedback(int UserId, string Description, string Date, string[] UserList)
        {
            this.UserId = UserId;
            this.Description = Description;
            this.Date = Date;
            this.UserList = UserList;
        }
    }
}
