using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace meestoo
{
    public partial class User
    {
        public User()
        {
            Feedback = new HashSet<Feedback>();
            UserFeedbackReaction = new HashSet<UserFeedbackReaction>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImgUrl{ get; set; }

        public virtual ICollection<Feedback> Feedback { get; set; }
        public virtual ICollection<UserFeedbackReaction> UserFeedbackReaction { get; set; }
        public User(string Name,string Email,string ImgUrl)
        {
            this.Name = Name;
            this.Email = Email;
            this.ImgUrl = ImgUrl;
        }
    }
}
