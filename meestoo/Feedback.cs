using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace meestoo
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public string Feedback_ { get; set; }
        public string Date { get; set; }
        public int? Karma { get; set; }
        [JsonIgnore]
        public virtual Users User { get; set; }
    }
}
