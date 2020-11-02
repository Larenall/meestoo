using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meestoo.Models
{
    public class GetFeedbackDTO
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId{ get; set; }

        public GetFeedbackDTO(string Description, DateTime Date, int UserId) //get from website
        {
            this.Description = Description;
            this.Date = Date;
            this.UserId = UserId;
        }
    }
    
}
