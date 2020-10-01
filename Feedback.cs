using System;
using System.Collections.Generic;

namespace meestoo
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public string Feedback1 { get; set; }
        public string Date { get; set; }
        public int? Karma { get; set; }

        public virtual Users User { get; set; }
    }
}
