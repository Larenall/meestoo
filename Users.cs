﻿using System;
using System.Collections.Generic;

namespace meestoo
{
    public partial class Users
    {
        public Users()
        {
            Feedback = new HashSet<Feedback>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? Resident { get; set; }

        public virtual ICollection<Feedback> Feedback { get; set; }
    }
}